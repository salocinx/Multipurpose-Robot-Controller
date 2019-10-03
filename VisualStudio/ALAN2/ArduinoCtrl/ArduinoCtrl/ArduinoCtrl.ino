#include <I2C.h>
#include <LED.h>
#include <Wire.h>
#include <IRremote.h>
#include <TinyGPS.h>
#include <HCSR04.h>
#include <DHT11.h>
#include <Analog.h>
#include <PCA9685.h>
#include <MPU6500.h>
#include <QueueList.h>
#include <CmdMessenger.h>
#include <SimpleTimer.h>


// ------------------------------------------------------------
// ---------- T I M E R S  &  I N T E R R U P T S -------------
// ------------------------------------------------------------

/*    
 *    Timer 0  (8-bit): millis() / micros() / Serial Ports
 *    Timer 1 (16-bit): currently unused
 *    Timer 2  (8-bit): sonar library
 *    Timer 3 (16-bit): infrared library
 *    Timer 4 (16-bit): currently unused
 *    Timer 5 (16-bit): currently unused
 *    
 *    External Interrupts: Open = 2/3; Serial1 = 18/19; I2C = 20/21
 */

// ------------------------------------------------------------
// ---------------- D E F I N I T I O N S ---------------------
// ------------------------------------------------------------

// TODO: try single-pin sonar sensor system !
// TODO: humidity sensor breaks things ?!?
// TODO: pull-up/-down + dangling analog inputs ?

#define DEBUGGING                   1         // DEBUG has name-conflict with other library

#define BAUDRATE_0                  115200    // communication host <-> atmel
#define BAUDRATE_1                  9600      // gps sensor
#define BAUDRATE_2                  19200     // motor driver
#define BAUDRATE_3                  115200    // debug output

#define MPU6500_ADDRESS             0x68      // i2c bus address
#define GYROSCOPE_SCALE             0x18      // 2000_DPS = 0x18; 1000_DPS = 0x10; 500_DPS = 0x08; 250_DPS = 0x00
#define ACCELEROMETER_SCALE         0x18      // 16_G = 0x18; 8_G = 0x10; 4_G = 0x08; 2_G = 0x00

#define HUMIDITY_SENSOR_MAX         1         // max amount of humidity sensors available
#define GYROSCOPE_SENSORS_MAX       1         // max amount of gyroscope and accelerometer sensors available
#define ANALOG_SENSORS_MAX          8         // max amount of analog sensors available (batteries, thermistors, photoresistors, etc.)
#define SONAR_SENSORS_MAX           8         // max amount of sonar sensors available
#define SERVO_MOTORS_MAX            16        // max amount of servo motors available

#define BLINK                       250       // blink interval for leds (wait for connection/loop-time warning)

boolean running = false;

/* monitor healthy loop times */
uint32_t loopTime = 0;                        // time in [us] a loop takes
uint32_t loopCount = 0;                       // monitoring loop performance
uint32_t maxLoopTime = 0;                     // maximal loop time before warning is displayed [us]
uint32_t lastAliveMessage;                    // timestamp for last alive sign from host

/* timers for asynchronous task management */
SimpleTimer timerId;
SimpleTimer timerLoop;
SimpleTimer timerAutoShutdown;
SimpleTimer timerSequentialRelays;

uint16_t indexTimerGps;
SimpleTimer timerGps;
uint16_t indexTimerServo;
SimpleTimer timerServo;
SimpleTimer timerSonar;

/* i2c bus */
I2C* i2c;

/* single GPS module */
TinyGPSPlus* gps;

/* infrared receiver and transceiver */
IRrecv* irRx;
IRsend* irTx;
decode_results irResults;                             // complete 24-bit signal including inverted checksum representation

/* main sensor and actuator objects */
LED led;
Analog sensors[ANALOG_SENSORS_MAX];
DHT11 humidities[HUMIDITY_SENSOR_MAX];
HCSR04 sonar[SONAR_SENSORS_MAX];
PCA9685 servos[SERVO_MOTORS_MAX];
MPU6500 gyroscopes[GYROSCOPE_SENSORS_MAX];

/* host communication */
CmdMessenger host = CmdMessenger(Serial);             // attach to the default serial port

typedef struct {                                      // use volatile queues to decouple ISR calls from main program, asynchronous
  uint16_t cid;                                       // callback from ISR could otherwise courrupt/intersect serial data transmission
  int16_t value;
} SonarSignal;

QueueList <SonarSignal> sonarQueue;

/* used to setup timers only once (servo, etc.) */
uint8_t servoReady = false;
                                                      
/* object counters for static allocation */
uint8_t relayCount = 0;                               // current index of relay that started up
uint8_t sensorCount = 0;                              // current amount of active battery sensors
uint8_t sonarCount = 0;                               // current amount of active sonar sensors
uint8_t servoCount = 0;                               // current amount of active servo motors
uint8_t humidityCount = 0;                            // current amount of active humidity sensors
uint8_t gyroscopeCount = 0;                           // current amount of active gyroscope sensors

/* asynchronous sonar array fields */
volatile uint8_t csi = 0;                             // current sonar sensor index; keeps track of which sensor is active/triggered
volatile uint8_t sonarReady = true;                   // false if currently any sonar is in the process of measuring
unsigned long lastSonarPing = 0;                      // timestamp when the last sonar was triggered (to determine timeouts)

// list of recognisable commands for host <-> arduino communication
enum {
  kError                          , // report errors
  kStartup                        , // set properties such as intervals etc.
  kShutdown                       , // sent before host goes offline to clean up this stack & heap
  kKeepAlive                      , // auto shutdown if host isn't alive anymore
  kRttRequest                     , // measure round trip time
  kInitGpsModule                  , // init GPS module
  kChangeGpsInterval              , // change GPS module read interval
  kReadGpsSignal                  , // send GPS data (long/lat) to host
  kInitGyroscope                  , // init gyroscope and accelerometer
  kChangeGyroscopeInterval        , // change interval at which gyroscope data is sent to host
  kReadGyroscope                  , // called if gyro and accelerometer data is available
  kInitInfraredRx                 , // init infrared receiver
  kReadInfraredSignal             , // event when ir signal has been received
  kInitInfraredTx                 , // init infrared transceiver
  kSendInfraredSignal             , // send ir signal
  kInitAnalogSensor               , // init analog sensor (batteries, thermistors, photoresistors, etc.)
  kReadAnalogSensor               , // reporting analog sensor state to host
  kChangeAnalogSensorPin          , // change analog sensor pin
  kChangeAnalogSensorInterval     , // change analog sensor read interval
  kInitHumidity                   , // init humidity sensor
  kChangeHumidityPin              , // change pin on humidity sensor
  kChangeHumidityInterval         , // change read interval on humidity sensor
  kInitSonar                      , // init sonar sensor
  kChangeSonarPins                , // change pins on sonar sensor
  kChangeSonarInterval            , // change sonar interval (interval between a batch of singular sonar calls)
  kInitServo                      , // init servo charateristics
  kChangeServoPin                 , // change servo pin or/and board
  kUpdateServo                    , // update servo charateristics
  kSetServoSignal                 , // set servo position in microseconds
  kSetServoPosition               , // set servo position in degrees
  kTargetServoValue               , // set servo position within a certain time frame
};

int freeRam();
// called when gps timer elapsed
void onReadGps();
// called when gyroscope timer elapsed
void onReadGyroscope();
// called by servo timer every 10ms
void onUdpateServoTargeting();
// asynchronously reading out sonar sensors
void onTriggerSonar();
void onCheckEchoSonar();
void incrementSonarCounter();
// logging and debugging
void logStartup();
void logGpsInit();
void logGpsReset();
void logGyroscopeSensorInit(uint8_t address);
void logGyroscopeSensorReset();
void logInfraredRxInit(uint16_t pin);
void logInfraredTxInit(uint16_t pin);
void logInfraredReset();
void logServoInit(uint16_t pin, uint16_t address);
void logServoInit(uint16_t pin, uint16_t address);
void logServoReset(uint16_t cid);
void logAnalogSensorInit(uint16_t pin);
void logAnalogSensorReset(uint16_t cid);
void logSonarInit(uint16_t pin1, uint16_t pin2);
void logSonarReset(uint16_t cid);
void logHumidityInit(uint16_t pin);
void logHumidityReset(uint16_t cid);
// send error message to host
void sendMaximumAmountError(const String& type);

// ------------------------------------------------------------
// ------------- I N I T I A L I Z A T I O N ------------------
// ------------------------------------------------------------

void setup() {
  // initialize i2c bus
  i2c = new I2C();
  // data exchange between host and atmel
  Serial.begin(BAUDRATE_0);
  // TODO: place to initMotors() / motor driver
  //Serial2.begin(BAUDRATE_2);
  // debug output to host
  Serial3.begin(BAUDRATE_3);
  // adds newline to every command
  host.printLfCr();   
  // attach user-defined callback methods
  attachCommandCallbacks();
  // start identifying myself
  timerId.setInterval(100, onIdentification);
  // start measuring loop time
  timerLoop.setInterval(100, onMeausreLoopTime);
  // check round-robin sonar time-table and trigger sonar sensors
  timerSonar.setInterval(5, onTriggerSonar);
  // check for auto shutdown in case host was not shutdown correctly
  timerAutoShutdown.setInterval(1000, onAutoShutdownCheck);
  // enables different ports sequentially (e.g. for starting up power-intensive devices by relays)
  initSequentialRelays();
  timerSequentialRelays.setInterval(2000, onSequentialRelays);
  // indicate ready for startup
  led.blink(YELLOW, BLINK);
}

void attachCommandCallbacks() {
  host.attach(onUnknownCommand);
  host.attach(kStartup, onStartup);
  host.attach(kShutdown, onShutdown);
  host.attach(kKeepAlive, onKeepAlive);
  host.attach(kRttRequest, onRttRequest);
  host.attach(kInitGpsModule, onInitGpsModule);
  host.attach(kChangeGpsInterval, onChangeGpsInterval);
  host.attach(kInitGyroscope, onInitGyroscope);
  host.attach(kChangeGyroscopeInterval, onChangeGyroscopeInterval);
  host.attach(kInitInfraredRx, onInitInfraredRx);
  host.attach(kInitInfraredTx, onInitInfraredTx);
  host.attach(kSendInfraredSignal, onSendInfraredSignal);
  host.attach(kInitAnalogSensor, onInitAnalogSensor);
  host.attach(kChangeAnalogSensorPin, onChangeAnalogSensorPin);
  host.attach(kChangeAnalogSensorInterval, onChangeAnalogSensorInterval);
  host.attach(kInitHumidity, onInitHumidity);
  host.attach(kChangeHumidityPin, onChangeHumidityPin);
  host.attach(kChangeHumidityInterval, onChangeHumidityInterval);
  host.attach(kInitSonar, onInitSonar);
  host.attach(kChangeSonarPins, onChangeSonarPins);
  host.attach(kChangeSonarInterval, onChangeSonarInterval);
  host.attach(kInitServo, onInitServo);
  host.attach(kChangeServoPin, onChangeServoPin);
  host.attach(kUpdateServo, onUpdateServo);
  host.attach(kSetServoSignal, onSetServoSignal);
  host.attach(kSetServoPosition, onSetServoPosition);
  host.attach(kTargetServoValue, onTargetServoValue);
}

// ------------------------------------------------------------
// ------------------ C A L L B A C K S -----------------------
// ------------------------------------------------------------

void onIdentification() {
  if(!running) {
    Serial.println(F("[c#0]"));
    Serial3.println(F("[m#3]"));
  }
}

int freeRam ()  {
  extern int __heap_start, *__brkval; 
  int v; 
  return (int) &v - (__brkval == 0 ? (int) &__heap_start : (int) __brkval); 
}

void onStartup() {
  // maximal loop time before warning is displayed [us]
  maxLoopTime = host.readInt32Arg();                            
  // reset status led
  led.reset();
  led.on(GREEN);
  led.blink(BLUE, BLINK);
  // update auto shutdown timer
  lastAliveMessage = millis();
  // update runtime timers
  running = true;
  // logbook
  logStartup();
}

void onShutdown() {
  // don't run serial i/o that might conflict 
  // with auto detection of com ports ...
  running = false;
  // release gps module
  if(gps!=NULL) {
    Serial1.end();
    delete(gps);
    gps = NULL;
    logGpsReset();
  }
  // release infrared devices
  if(irRx!=NULL) {
    delete(irRx);
    irRx = NULL;
    logInfraredReset();
  }
  if(irTx!=NULL) {
    delete(irTx);
    irTx = NULL;
    logInfraredReset();
  }
  // reset gyroscope sensor array
  for(uint8_t i=0; i<gyroscopeCount; i++) {
    gyroscopes[i].reset();
    logGyroscopeSensorReset(gyroscopes[i].cid);
  }
  // reset analog sensor array
  for(uint8_t i=0; i<sensorCount; i++) {
    sensors[i].reset();
    logAnalogSensorReset(sensors[i].cid);
  }
  // reset humidity array
  for(uint8_t i=0; i<humidityCount; i++) {
    if(humidities[i].inited) {
      humidities[i].reset();
      logHumidityReset(humidities[i].cid);
    }
  }
  // reset servo array
  for(uint8_t i=0; i<servoCount; i++) {
    servos[i].reset();
    logServoReset(servos[i].cid);
  }
  // reset sonar array
  for(uint8_t i=0; i<sonarCount; i++) {
    sonar[i].reset();
    logSonarReset(sonar[i].cid);
  }
  // re-initialize counters
  gyroscopeCount = 0;
  humidityCount = 0;
  sensorCount = 0;
  sonarCount = 0;
  servoCount = 0;
  csi = 0;
  sonarReady = true;
  // delete timers for re-use
  timerGps.deleteTimer(indexTimerGps);
  timerServo.deleteTimer(indexTimerServo);
  servoReady = false;
  // indicate successful shutdown
  led.reset();
  led.blink(YELLOW, BLINK);
}

void onKeepAlive() {
  lastAliveMessage = millis();
}

void onAutoShutdownCheck() {
  if(running) {
    if(millis()-lastAliveMessage>5000) {
      onShutdown();
    }
  }
}

void initSequentialRelays() {
  pinMode(A12, OUTPUT);
  digitalWrite(A12, LOW);
  pinMode(A13, OUTPUT);
  digitalWrite(A13, LOW);
  pinMode(A14, OUTPUT);
  digitalWrite(A14, LOW);
  pinMode(A15, OUTPUT);
  digitalWrite(A15, LOW);
}

void onSequentialRelays() {
  switch(relayCount) {
    case 0:
      digitalWrite(A12, HIGH);
      #if DEBUGGING == 1
        Serial3.println(F("Relay on port A12 enabled."));
      #endif
      break;
    case 1:
      digitalWrite(A13, HIGH);
      #if DEBUGGING == 1
        Serial3.println(F("Relay on port A13 enabled."));
      #endif
      break;
    case 2:
      digitalWrite(A14, HIGH);
      #if DEBUGGING == 1
        Serial3.println(F("Relay on port A14 enabled."));
      #endif
      break;
    case 3:
      digitalWrite(A15, HIGH);
      #if DEBUGGING == 1
        Serial3.println(F("Relay on port A15 enabled."));
      #endif
      break;
  }
  relayCount++;
}

void onMeausreLoopTime() {
  // calculate time used for one loop cycle
  loopTime = 100000UL/loopCount;
  // let red led blink if exceeded
  if(maxLoopTime>0) {
    if(loopTime>=maxLoopTime) {
      led.blink(RED, BLINK);
    } else {
      led.stop(RED);
    }
  }
  // reset counter for next cycle
  loopCount = 0UL;
}

void onRttRequest() {
  host.sendCmdStart((byte)kRttRequest);
  host.sendCmdArg(loopTime);
  host.sendCmdArg(freeRam());
  host.sendCmdEnd();
}

void sendSensorData(uint16_t cid, int16_t value) {
  host.sendCmdStart((byte)kReadAnalogSensor);
  host.sendCmdArg(cid);
  host.sendCmdArg(value);
  host.sendCmdEnd();
}

void onInitGpsModule() {
  // decode input arguments
  uint32_t argInterval = host.readInt32Arg();                // read interval at which gps data is sent to host
  // begin serial communication with gps sensor
  Serial1.begin(BAUDRATE_1);
  // init gps module
  gps = new TinyGPSPlus();
  // initialize gps timer
  indexTimerGps = timerGps.setInterval(argInterval, onReadGps);
}

void onChangeGpsInterval() {
  // decode input arguments
  uint32_t argInterval = host.readInt32Arg();                // read interval at which gps data is sent to host
  // change read interval
  timerGps.deleteTimer(indexTimerGps);
  indexTimerGps = timerGps.setInterval(argInterval, onReadGps);
}

void onReadGps() {
  if(gps!=NULL) {
    if(gps->location.isValid()) {
      host.sendCmdStart((byte)kReadGpsSignal);
      if(gps->satellites.isValid()) {
        host.sendCmdArg((uint16_t)gps->satellites.value());
      } else {
        host.sendCmdArg(0);
      }
      if(gps->location.isValid()) {
        host.sendCmdArg(gps->location.lat(), 5);
        host.sendCmdArg(gps->location.lng(), 5);
      } else {
        host.sendCmdArg(0.0, 1);
        host.sendCmdArg(0.0, 1);
      }
      if(gps->altitude.isValid()) {
        host.sendCmdArg(gps->altitude.meters(), 2);
      } else {
        host.sendCmdArg(0.0, 1);
      }
      if(gps->speed.isValid()) {
        host.sendCmdArg(gps->speed.mps(), 2);
      } else {
        host.sendCmdArg(0.0, 1);
      }
      host.sendCmdEnd();
    }
    if(gps->satellites.isValid()) {
      led.on(ORANGE);
    } else {
      led.off(ORANGE);
    }
  }
}

void onInitGyroscope() {
  // decode input arguments
  uint16_t argCompId = host.readInt16Arg();                   // gyroscope sensor component id
  uint32_t argInterval = host.readInt32Arg();                 // interval at which sensor is read out [ms]
  uint16_t argAddress = host.readInt16Arg();                  // device address on the i2c bus
  // init gyroscope sensors
  for(uint8_t i=0; i<GYROSCOPE_SENSORS_MAX; i++) {
    if(!gyroscopes[i].inited) {
      gyroscopes[i].init(argCompId, argAddress, argInterval, onReadGyroscope);
      gyroscopeCount++;
      logGyroscopeSensorInit(argAddress);
      return;
    }
  }
  // throw error if no more free servo objects available
  sendMaximumAmountError(F("gyroscope"));
}

void onChangeGyroscopeInterval() {
  // decode input arguments
  uint16_t argCompId = host.readInt16Arg();                // gyroscope sensor component id
  uint32_t argInterval = host.readInt32Arg();              // interval at which sensor is read out [ms]
  // change gyroscope read interval
  for(uint8_t i=0; i<gyroscopeCount; i++) {
      if(gyroscopes[i].cid==argCompId) {
          gyroscopes[i].changeInterval(argInterval);
      }
  }
}

void onReadGyroscope(uint16_t cid, MPU6500_Result result) {
  host.sendCmdStart((byte)kReadGyroscope);
  host.sendCmdArg(result.ax);
  host.sendCmdArg(result.ay);
  host.sendCmdArg(result.az);
  host.sendCmdArg(result.gx);
  host.sendCmdArg(result.gy);
  host.sendCmdArg(result.gz);
  host.sendCmdEnd();
}

void onInitInfraredRx() {
  if(irRx==NULL) {
    // decode input arguments
    uint16_t argPin = host.readInt16Arg();                   // digital pin for timer-based signal readings
    // init infrared receiver
    irRx = new IRrecv(argPin);
    irRx->enableIRIn();
    logInfraredRxInit(argPin);
  } else {
    sendMaximumAmountError(F("infrared receiver"));
  }
}

void onInitInfraredTx() {
  if(irTx==NULL) {
    // init infrared transceiver
    irTx = new IRsend();                                    // transceiver pin is fixed to pin 5 by IRremote library
    logInfraredTxInit(5);
  } else {
    sendMaximumAmountError(F("infrared transceiver"));
  }
}

void onSendInfraredSignal() {
  if(irTx==NULL) {
    // decode input arguments
    uint16_t argSignal = host.readInt16Arg();               // binary ir signal to send
    uint16_t argBits = host.readInt16Arg();                 // amount of bits the signal consists of
    // init infrared transceiver
    irTx->sendCDTV(argSignal, argBits);                     // TODO: append inverse 12-bits as checksum ?
  }
}

void onInitAnalogSensor() {
  // decode input arguments
  uint16_t argCompId = host.readInt16Arg();                 // analog sensor component id
  uint16_t argPin = host.readInt16Arg();                    // analog pin used to read analog sensor
  uint32_t argInterval = host.readInt32Arg();               // interval at which sensor is read out [ms]
  // init battery sensors
  for(uint8_t i=0; i<ANALOG_SENSORS_MAX; i++) {
    if(!sensors[i].inited) {
      sensors[i].init(argCompId, argPin, argInterval, sendSensorData);
      sensorCount++;
      logAnalogSensorInit(argPin);
      return;
    }
  }
  // throw error if no more free servo objects available
  sendMaximumAmountError(F("analog sensor"));
}

void onChangeAnalogSensorPin() {
  // decode input arguments
  uint16_t argCompId = host.readInt16Arg();                // analog sensor component id
  uint16_t argPin = host.readInt16Arg();                   // analog pin used to read analog sensor
  // change battery characteristics
  for(uint8_t i=0; i<sensorCount; i++) {
    if(sensors[i].cid==argCompId) {
      sensors[i].changePin(argPin);
    }
  }
}

void onChangeAnalogSensorInterval() {
  // decode input arguments
  uint16_t argCompId = host.readInt16Arg();                // analog sensor component id
  uint32_t argInterval = host.readInt32Arg();              // interval at which sensor is read out [ms]
  // change battery characteristics
  for(uint8_t i=0; i<sensorCount; i++) {
    if(sensors[i].cid==argCompId) {
      sensors[i].changeInterval(argInterval);
    }
  }
}

void onInitHumidity() {
  // decode input arguments
  uint16_t argCompId = host.readInt16Arg();                // sensor component id
  uint16_t argPin = host.readInt16Arg();                   // analog pin used to read values
  uint32_t argInterval = host.readInt32Arg();              // interval at which sensor is read out [ms]
  // init sonar sensors
  for(uint8_t i=0; i<HUMIDITY_SENSOR_MAX; i++) {
    if(!humidities[i].inited) {
      humidities[i].init(argCompId, argPin, argInterval, sendSensorData);
      humidityCount++;
      logHumidityInit(argPin);
      return;
    }
  }
  // throw error if no more free servo objects available
  sendMaximumAmountError(F("humidity"));
}

void onChangeHumidityPin() {
  // decode input arguments
  uint16_t argCompId = host.readInt16Arg();                // humidity component id
  uint16_t argPin = host.readInt16Arg();                   // analog pin used read humidity
  // change battery characteristics
  for(uint8_t i=0; i<humidityCount; i++) {
    if(humidities[i].cid==argCompId) {
      humidities[i].changePin(argPin);
    }
  }
}

void onChangeHumidityInterval() {
  // decode input arguments
  uint16_t argCompId = host.readInt16Arg();                // humidity component id
  uint32_t argInterval = host.readInt32Arg();              // analog pin used read humidity
  // change battery characteristics
  for(uint8_t i=0; i<humidityCount; i++) {
    if(humidities[i].cid==argCompId) {
      humidities[i].changeInterval(argInterval);
    }
  }
}

void onInitSonar() {
  // decode input arguments
  uint16_t argCompId = host.readInt16Arg();               // sonar sensor component id
  uint16_t argTrigPin = host.readInt16Arg();              // pin used to trigger a ultrasonic wave
  uint16_t argEchoPin = host.readInt16Arg();              // pin to retrieve the ultrasonic echo
  uint16_t argMaxDist = host.readInt16Arg();              // maximal distance to be read out
  uint32_t argInterval = host.readInt32Arg();             // next point in time this sonar is triggered
  // init sonar sensors
  for(uint8_t i=0; i<SONAR_SENSORS_MAX; i++) {
    if(!sonar[i].inited) {
      sonar[i].init(argCompId, argTrigPin, argEchoPin, argInterval, argMaxDist);
      sonarCount++;
      logSonarInit(argTrigPin, argEchoPin);
      return;
    }
  }
  // throw error if no more free servo objects available
  sendMaximumAmountError(F("sonar"));
}

void onChangeSonarPins() {
  // decode input arguments
  uint16_t argCompId = host.readInt16Arg();                            // sonar sensor component id
  uint16_t argTriggerPin = host.readInt16Arg();                        // pin used to trigger a ultrasonic wave
  uint16_t argEchoPin = host.readInt16Arg();                           // pin to retrieve the ultrasonic echo
  // change sonar pins
  for(uint8_t i=0; i<sonarCount; i++) {
    if(sonar[i].cid==argCompId) {
      sonar[i].changePins(argTriggerPin, argEchoPin);
    }
  }
}

void onChangeSonarInterval() {
  // decode input arguments
  uint16_t argCompId = host.readInt16Arg();                           // sonar sensor component id
  uint32_t argInterval = host.readInt32Arg();                         // read interval of the sensor
  // change sonar interval
  for(uint8_t i=0; i<sonarCount; i++) {
    if(sonar[i].cid==argCompId) {
      sonar[i].changeInterval(argInterval);
    }
  }
}

void onTriggerSonar() {
   if(sonarCount>0) {                                                 // avoid endless recursive loop if no sensors are attached
     if(sonarReady) {                                                 // was last trigger successful or timed-out ?
       for(uint8_t i=csi; i<sonarCount; i++) {                        // check the time-table and pick next sonar sensor to be triggered (avoid live-lock)
         if(millis()>=sonar[i].nextTrigger) {                         // is this sensor ready to be triggered ?
           csi = i;                                                   // cache current sonar index for identifying it on the echo callback function
           sonar[csi].timer_stop();
           sonar[csi].ping_timer(onCheckEchoSonar);                   // do the ping (processing continues, interrupt will call onCheckEchoSonar() to look for echo)
           lastSonarPing = millis();
           sonarReady = false;                                        // do not trigger any sonar sensor as long as the previous did return successfully or timed-out 
           return;
         }
       }
       csi = 0;                                                       // reset current sonar if every sensor had the chance to ping once (avoid live-lock)
     } else {
       if(millis()-lastSonarPing>=35) {                               // time-out occured (too near or too far)
         sonar[csi].timer_stop();
         if(sonar[csi].distance<sonar[csi].maxDistance/3) {           // no need for decoupling here, since this time-out was NOT triggered by ISR -> relieve ISR call
           host.sendCmdStart((byte)kReadAnalogSensor);
           host.sendCmdArg(sonar[csi].cid);
           host.sendCmdArg(sonar[csi].distance);                      // take last valid value
           host.sendCmdEnd();
         } else {
           host.sendCmdStart((byte)kReadAnalogSensor);
           host.sendCmdArg(sonar[csi].cid);
           host.sendCmdArg(sonar[csi].maxDistance);                   // take max distance
           host.sendCmdEnd();
         }
         sonar[csi].updateNextTrigger();                              // update next trigger interval
         incrementSonarCounter();                                     // reset current sonar if every sensor had the chance to ping once (avoid live-lock)
         sonarReady = true;                                           // ready for next sonar trigger
         onTriggerSonar();                                            // re-call this function
       }
     }
   }
}

/* ISR */
void onCheckEchoSonar() {
  if(sonar[csi].check_timer()) {                                      // returns true only if ping returned successfully (time-outs are handled in onTriggerSonar())
    cli();
    SonarSignal packet = { sonar[csi].cid,                            // decouple ISR from main loop
                           sonar[csi].distance };
    sonarQueue.push(packet);                                          // enqueue measured distance for sending to host later on
    sei();
  }
}

void incrementSonarCounter() {
  csi++;                                                              // increment sonar index to ping next sonar sensor
  if(csi==sonarCount) {
    csi = 0;                                                          // reset current sonar if every sensor had the chance to ping once (avoid live-lock)
  }
}

void onInitServo() {
  // decode input arguments
  uint16_t argCompId = host.readInt16Arg();                           // servo component id
  uint16_t argPin = host.readInt16Arg();                              // giop pin servo is attached to
  uint16_t argBoard = host.readInt16Arg();                            // board type servo is attached to (arduino=0x20, adafruit-pwm= [0x40, 0x43])
  uint16_t argMin = host.readInt16Arg();                              // min position in [us]
  uint16_t argMax = host.readInt16Arg();                              // max position in [us]
  uint16_t argTime = host.readInt16Arg();                             // time in ms for a full turning angle at 100% speed
  uint16_t argInterval = host.readInt16Arg();                         // interval at which servo motors are updated when automatic targeting is enabled (10ms=100Hz)
  float argPosition = host.readFloatArg();                            // initial servo position in [%]               
  // setup servo targeting timer only once
  if(!servoReady) {
    indexTimerServo = timerServo.setInterval(argInterval, onUdpateServoTargeting);
    servoReady = true;
  }
  // init servo characteristics
  for(uint8_t i=0; i<SERVO_MOTORS_MAX; i++) {
    if(!servos[i].inited) {
      servos[i].init(argCompId, argPin, argBoard, argMin, argMax, argTime, argInterval, argPosition);
      servoCount++;
      logServoInit(argPin, argBoard);
      return;
    }
  }
  // throw error if no more free servo objects available
  sendMaximumAmountError(F("servo"));
}


void onChangeServoPin() {
  // decode input arguments
  uint16_t argCompId = host.readInt16Arg();        // servo component id
  uint16_t argPin = host.readInt16Arg();           // giop pin servo is attached to
  uint16_t argBoard = host.readInt16Arg();         // board type servo is attached to (arduino=0x20, adafruit-pwm= [0x40, 0x43])
  // change servo characteristics
  for(uint8_t i=0; i<servoCount; i++) {
    if(servos[i].cid==argCompId) {
      servos[i].change(argPin, argBoard);
    }
  }
}

void onUpdateServo() {
  // decode input arguments
  uint16_t argCompId = host.readInt16Arg();        // servo component id
  uint16_t argPin = host.readInt16Arg();           // giop pin servo is attached to
  uint16_t argBoard = host.readInt16Arg();         // board type servo is attached to (arduino=0x20, adafruit-pwm= [0x40, 0x43])
  uint16_t argMin = host.readInt16Arg();           // min position in [us]
  uint16_t argMax = host.readInt16Arg();           // max position in [us]
  uint16_t argTime = host.readInt16Arg();          // time in ms for a full turning angle at 100% speed
  // update servo characteristics
  for(uint8_t i=0; i<servoCount; i++) {
    if(servos[i].cid==argCompId) {
      servos[i].update(argMin, argMax, argTime);
    }
  }
}

void onSetServoPosition() {
  // decode input arguments
  uint16_t argCompId = host.readInt16Arg();        // servo component id
  uint16_t argPin = host.readInt16Arg();           // giop pin servo is attached to
  uint16_t argBoard = host.readInt16Arg();         // board type servo is attached to (arduino=0x20, adafruit-pwm= [0x40, 0x43])
  float argPosition = host.readFloatArg();         // target position in [%]
  // set servo position
  for(uint8_t i=0; i<servoCount; i++) {
    if(servos[i].cid==argCompId) {
      servos[i].write(argPosition);
      short result = servos[i].position_us;
    }
  }
}

void onSetServoSignal() {
  // decode input arguments
  uint16_t argCompId = host.readInt16Arg();        // servo component id
  uint16_t argPin = host.readInt16Arg();           // giop pin servo is attached to
  uint16_t argBoard = host.readInt16Arg();         // board type servo is attached to (arduino=0x20, adafruit-pwm= [0x40, 0x43])
  uint16_t argSignal = host.readInt16Arg();        // target position in [us]
  // set servo position
  for(uint8_t i=0; i<servoCount; i++) {
    if(servos[i].cid==argCompId) {
      servos[i].writeMicro(argSignal);
    }
  }
}

void onTargetServoValue() {
  // decode input arguments
  uint16_t argCompId = host.readInt16Arg();        // servo component id
  uint16_t argPin = host.readInt16Arg();           // giop pin servo is attached to
  uint16_t argBoard = host.readInt16Arg();         // board type servo is attached to (arduino=0x20, adafruit-pwm= [0x40, 0x43])
  float argPosition = host.readFloatArg();         // target position in [%]
  uint32_t argTime = host.readInt32Arg();          // time available to reach target position in [ms]
  // start servo controlling
  for(uint8_t i=0; i<servoCount; i++) {
    if(servos[i].cid==argCompId) {
      servos[i].target(argPosition, argTime);
    }
  }
}

void onUnknownCommand() {
  // called when a received command has no attached function
  host.sendCmd(kError, F("Unknown command from host received."));
}

void onUdpateServoTargeting() {
  for(uint8_t i=0; i<servoCount; i++) {
    servos[i].updateTargeting();
  }
}

// ------------------------------------------------------------
// ------------------- M A I N L O O P ------------------------
// ------------------------------------------------------------

void loop() {

  // update LED state machine
  led.update();
  // wait for auto com port detector requests
  timerId.run();
  // measure loop time every 100 [ms]
  timerLoop.run();
  // starting power-intensive devices sequentially
  if(relayCount<4) {
    timerSequentialRelays.run();
  }
  // process incoming serial data and perform callbacks
  host.feedinSerialData();

  // monitor loop performance
  loopCount++;
  
  // agent related processing
  if(running) {

    // read gps module
    if(gps!=NULL) {
      while(Serial1.available()>0) {
        gps->encode(Serial1.read());
      }
    }

    // read infrared sensor
    if(irRx!=NULL) {
      if(irRx->decode(&irResults)) {
        // only check for new non-repeated signals
        if(irResults.value != 0xFFFFFF) {
          // extracted higher 12-bits without inverted checksum
          //  represenation and enqueue for sending to host later on
          uint16_t code = irResults.value >> 12;
          // send ir signal to host
          host.sendCmdStart((byte)kReadInfraredSignal);
          host.sendCmdArg(code);
          host.sendCmdArg(12);
          host.sendCmdEnd();
        }
        // prepare to receive next ir signal
        irRx->resume();
      }
    }
    
    // process and send gps data
    timerGps.run();
    // process servo targeting
    timerServo.run();
    // process sonar sensors
    timerSonar.run();
    // check if auto shutdown is needed
    timerAutoShutdown.run();
    
    // update sensor values
    for(uint8_t i=0; i<gyroscopeCount; i++) {
      if(gyroscopes[i].inited) {
        gyroscopes[i].update();
      }
    }
    for(uint8_t i=0; i<sensorCount; i++) {
      if(sensors[i].inited) {
        sensors[i].update();
      }
    }
    for(uint8_t i=0; i<humidityCount; i++) {
      if(humidities[i].inited) {
        humidities[i].update();
      }
    }
    
    if(!sonarQueue.isEmpty()) {
      // relieve ISR method call
      sonar[csi].updateNextTrigger();                                   // update next trigger interval
      incrementSonarCounter();                                          // reset current sonar if every sensor had the chance to ping once (avoid live-lock)
      sonarReady = true;                                                // ready for next sonar trigger
      // send sonar readings to host
      while(!sonarQueue.isEmpty()) {
        SonarSignal packet = sonarQueue.pop();
        host.sendCmdStart((byte)kReadAnalogSensor);
        host.sendCmdArg(packet.cid);
        host.sendCmdArg(packet.value);
        host.sendCmdEnd();
      }
    }
  }

}

// ------------------------------------------------------------
// -------------------- L O G G I N G -------------------------
// ------------------------------------------------------------

void logStartup() {
  #if DEBUGGING == 1
    Serial3.println(F("User defined properties applied."));
  #endif
}

void logGpsInit() {
  #if DEBUGGING == 1
    Serial3.print(F("Initializing GPS module on Serial1 with "));
    Serial3.print(BAUDRATE_1);
    Serial3.println(F(" baud."));
  #endif
}

void logGpsReset() {
  #if DEBUGGING == 1
    Serial3.println(F("Resettings GPS module on Serial1."));
  #endif
}

void logInfraredRxInit(uint16_t pin) {
  #if DEBUGGING == 1
    Serial3.print(F("Initializing infrared receiver D#"));
    Serial3.print(pin);
    Serial3.println(F("."));
  #endif
}

void logInfraredTxInit(uint16_t pin) {
  #if DEBUGGING == 1
    Serial3.print(F("Initializing infrared transceiver D#"));
    Serial3.print(pin);
    Serial3.println(F("."));
  #endif
}

void logInfraredReset() {
  #if DEBUGGING == 1
    Serial3.println(F("Resetting infrared device."));
  #endif
}

void logServoInit(uint16_t pin, uint16_t address) {
  #if DEBUGGING == 1
    Serial3.print(F("Initializing servo motor PWM#"));
    Serial3.print(pin);
    Serial3.print(F(" I2C@0x"));
    Serial3.print(String(address, HEX));
    Serial3.println(F("."));
  #endif
}

void logServoReset(uint16_t cid) {
  #if DEBUGGING == 1
    Serial3.print(F("Resetting servo motor (id="));
    Serial3.print(cid);
    Serial3.println(F(")."));
  #endif
}

void logGyroscopeSensorInit(uint8_t address) {
  #if DEBUGGING == 1
    Serial3.print(F("Initializing gyroscope sensor I2C@0x"));
    Serial3.print(String(address, HEX));
    Serial3.println(F("."));
  #endif
}

void logGyroscopeSensorReset(uint16_t cid) {
#if DEBUGGING == 1
    Serial3.print(F("Resetting gyroscope sensor (id="));
    Serial3.print(cid);
    Serial3.println(F(")."));
  #endif
}

void logAnalogSensorInit(uint16_t pin) {
  #if DEBUGGING == 1
    Serial3.print(F("Initializing analog sensor A#"));
    Serial3.print(pin);
    Serial3.println(F("."));
  #endif
}

void logAnalogSensorReset(uint16_t cid) {
  #if DEBUGGING == 1
    Serial3.print(F("Resetting analog sensor (id="));
    Serial3.print(cid);
    Serial3.println(F(")."));
  #endif
}

void logSonarInit(uint16_t pin1, uint16_t pin2) {
  #if DEBUGGING == 1
    Serial3.print(F("Initializing sonar sensor D#"));
    Serial3.print(pin1);
    Serial3.print(F(" and D#"));
    Serial3.print(pin2);
    Serial3.println(F("."));
  #endif
}

void logSonarReset(uint16_t cid) {
  #if DEBUGGING == 1
    Serial3.print(F("Resetting sonar sensor (id="));
    Serial3.print(cid);
    Serial3.println(F(")."));
  #endif
}

void logHumidityInit(uint16_t pin) {
  #if DEBUGGING == 1
    Serial3.print(F("Initializing humidity sensor D#"));
    Serial3.print(pin);
    Serial3.println(F("."));
  #endif
}

void logHumidityReset(uint16_t cid) {
  #if DEBUGGING == 1
    Serial3.print(F("Resetting humidity sensor (id="));
    Serial3.print(cid);
    Serial3.println(F(")."));
  #endif
}

void sendMaximumAmountError(const String& type) {
  host.sendCmd(kError, "Maximum amount of assingable "+type+" objects reached.");
}
