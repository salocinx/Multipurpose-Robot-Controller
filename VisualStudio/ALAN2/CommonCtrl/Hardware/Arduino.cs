
#region Usings
using System;
using System.Linq;
using System.IO.Ports;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Threading;
using System.Management;
using CommandMessenger;
using CommandMessenger.Transport.Serial;
using CommonCtrl;
#endregion

namespace CommonCtrl {

    #region Enumerations
    public enum Board {
        Nano, Uno, Mega
    };

    public enum Command {
        Error,
        Startup,
        Shutdown,
        KeepAlive,
        RttRequest,
        InitGpsModule,
        ChangeGpsInterval,
        ReadGpsSignal,
        InitGyroscope,
        ChangeGyroscopeInterval,
        ReadGyroscope,
        InitInfraredRx,
        ReadInfraredSignal,
        InitInfraredTx,
        SendInfraredSignal,
        InitAnalogSensor,
        ReadAnalogSensor,
        ChangeAnalogSensorPin,
        ChangeAnalogSensorInterval,
        InitHumidity,
        ChangeHumidityPin,
        ChangeHumidityInterval,
        InitSonar,
        ChangeSonarPins,
        ChangeSonarInterval,
        InitServo,
        ChangeServoPin,
        UpdateServo,
        SetServoSignal,
        SetServoPosition,
        TargetServoValue,
    };

    public enum Channel {
        Controller, Monitoring
    };
    #endregion

    [Serializable]
    public class Arduino {

        #region Fields
        private Board board;                                    // type of the underlying arduino {nano, uno, mega}

        private int baudrate_0;                                 // baudrate at which the arduino communicates with the host
        private int baudrate_3;                                 // baudrate at which the arduino sends debugging info to the host

        [NonSerialized]
        private bool launched;                                  // flag is set as soon as the arduino link is 
        [NonSerialized]
        private int bytesSent;                                  // amount of bytes sent on the main link
        [NonSerialized]
        private int bytesReceived;                              // amount of bytes received on the main link

        [NonSerialized]
        private CmdMessenger messenger;                         // serial controller endpoint
        [NonSerialized]
        private SerialTransport serial;                         // serial transport layer
        [NonSerialized]
        private SerialPort monitor;                             // serial monitor endpoint
        [NonSerialized]
        private readonly object syncobj = new object();
        #endregion

        #region Events
        [field: NonSerialized]
        public event OnNewLineReported onNewLineReported;
        [field: NonSerialized]
        public event OnRoundTripUpdate onRoundTripUpdate;
        
        [field: NonSerialized]
        public event OnGpsUpdate onGpsUpdate;
        [field: NonSerialized]
        public event OnGyroscopeUpdate onGyroscopeUpdate;
        [field: NonSerialized]
        public event OnSensorUpdate onSensorUpdate;
        [field: NonSerialized]
        public event OnInfraredSignalUpdate onInfraredSignalUpdate;
        #endregion

        #region Threads
        [NonSerialized]
        private Thread autoShutdownThread;
        [NonSerialized]
        private volatile bool sending = true;
        [NonSerialized]
        private readonly object sendingLock = new object();

        [NonSerialized]
        private Thread measureBandwidthThread;
        [NonSerialized]
        private volatile bool measuring = true;
        [NonSerialized]
        private readonly object measuringLock = new object();
        #endregion

        #region Lifecycle
        public Arduino() {
            this.baudrate_0 = 115200;
            this.baudrate_3 = 115200;
        }

        public void launch() {
            // determine com ports
            List<string> availableComPorts = getAvailableComPorts();
            #region Logbook
            Logger.Log(Level.INFO, "Initialize Atmel Microcontroller:");
            #endregion
            string com_0 = getComPort(Channel.Controller, baudrate_0, availableComPorts);
            #region Logbook
            Logger.Log(Level.INFO, " - Controller Channel @ "+com_0+" with "+baudrate_0+" [baud]");
            #endregion
            string com_3 = getComPort(Channel.Monitoring, baudrate_3, availableComPorts);
            #region Logbook
            if(!com_3.Equals("n/a")) {
                Logger.Log(Level.INFO, " - Monitoring Channel @ "+com_3+" with "+baudrate_3+" [baud]");
            }
            #endregion
            // initialize monitor channel if available
            initializeMonitor(com_3);
            // set up serial transport layer
            serial = new SerialTransport();
            serial.CurrentSerialSettings.PortName = com_0;
            serial.CurrentSerialSettings.BaudRate = baudrate_0;
            serial.CurrentSerialSettings.DtrEnable = false;
            // initialize the command messenger with the serial port transport layer (16- or 32-bit ?)
            messenger = new CmdMessenger(serial, BoardType.Bit16);
            // attach the callbacks to the command messenger
            attachCommandCallbacks();
            // attach to NewLinesReceived for logging purposes
            messenger.NewLineReceived += newLineReceived;
            // attach to NewLineSent for logging purposes
            messenger.NewLineSent += newLineSent;
            // start listening
            messenger.Connect();
            #region Work-Around for Reset-Bug
            Thread.Sleep(512);
            messenger.Disconnect();
            Thread.Sleep(512);
            messenger.Connect();
            Thread.Sleep(512);
            #endregion
            // keep arduino alive and avoid auto shutdown
            this.autoShutdownThread = new Thread(sendKeepAliveMessage);
            this.autoShutdownThread.Start();
            // measure bandwidth serial connection
            this.measureBandwidthThread = new Thread(resetBandwidthCounters);
            this.measureBandwidthThread.Start();
            // indicate ready
            this.launched = true;
        }

        public void terminate() {
            // stop keep alive messages
            sending = false;
            lock(sendingLock) {
                Monitor.Pulse(sendingLock);
            }
            // stop resetting bandwidth counters
            measuring = false;
            lock(measuringLock) {
                Monitor.Pulse(measuringLock);
            }
            // clean up on atmel
            shutdown();
            Thread.Sleep(128);
            // indicate not ready
            launched = false;
            // stop listening
            messenger.Disconnect();
            // dispose command messenger
            messenger.Dispose();
            // dispose serial port object
            serial.Dispose();
            // dispose monitoring connection
            if(monitor!=null) {
                monitor.Close();
                monitor.Dispose();
            }
            #region Logbook
            Logger.Log(Level.INFO, "Atmel Microcontroller successfully shutdown.");
            #endregion
        }
        #endregion

        #region Configuration
        [XmlIgnore]
        public bool I2C {
            get {
                switch(board) {
                    case Board.Nano:
                        return true;
                    case Board.Uno:
                        return true;
                    case Board.Mega:
                        return true;
                    default:
                        return false;
                }
            }
        }

        [XmlIgnore]
        public bool SPI {
            get {
                switch(board) {
                    case Board.Nano:
                        return true;
                    case Board.Uno:
                        return true;
                    case Board.Mega:
                        return true;
                    default:
                        return false;
                }
            }
        }

        [XmlIgnore]
        public List<int> SerialPins {
            get {
                switch(board) {
                    case Board.Nano:
                        return new List<int>() { 0 };
                    case Board.Uno:
                        return new List<int>() { 0 };
                    case Board.Mega:
                        return new List<int>() { 0, 1, 2, 3 };
                    default:
                        return new List<int>() { };
                }
            }
        }

        [XmlIgnore]
        public List<int> AnalogPins {
            get {
                switch(board) {
                    case Board.Nano:
                        return new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 };
                    case Board.Uno:
                        return new List<int>() { 0, 1, 2, 3, 4, 5 };
                    case Board.Mega:
                        return new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
                    default:
                        return new List<int>() { };
                }
            }
        }

        [XmlIgnore]
        public List<int> PwmPins {
            get {
                switch(board) {
                    case Board.Nano:
                        return new List<int>() { 3, 5, 6, 9, 10, 11 };
                    case Board.Uno:
                        return new List<int>() { 3, 5, 6, 9, 10, 11 };
                    case Board.Mega:
                        return new List<int>() { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 44, 45, 46 };
                    default:
                        return new List<int>() { };
                }
            }
        }

        [XmlIgnore]
        public List<int> DigitalPins {
            get {
                switch(board) {
                    case Board.Nano:
                        return new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
                    case Board.Uno:
                        return new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
                    case Board.Mega:
                        return new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53 };
                    default:
                        return new List<int>() { };
                }
            }
        }
        #endregion

        #region Properties
        public Board Board {
            get { return board; }
            set { board = value; }
        }

        public int Baudrate_0 {
            get { return baudrate_0; }
            set { baudrate_0 = value; }
        }

        public int Baudrate_3 {
            get { return baudrate_3; }
            set { baudrate_3 = value; }
        }

        [XmlIgnore]
        public int BytesSent {
            get { return bytesSent; }
            set { bytesSent = value; }
        }

        [XmlIgnore]
        public int BytesReceived {
            get { return bytesReceived; }
            set { bytesReceived = value; }
        }
        #endregion

        #region Functions
        private string getComPort(Channel channel, int baudrate, List<string> ports) {
            for(int i=ports.Count-1; i>=0; i--) {
                SerialPort serial = null;
                try {
                    serial = new SerialPort();
                    serial.PortName = ports[i];
                    serial.BaudRate = baudrate;
                    serial.ReadTimeout = 500;
                    serial.Open();
                    #region Work-Around for Reset-Bug
                    Thread.Sleep(256);
                    serial.Close();
                    Thread.Sleep(256);
                    serial.Open();
                    Thread.Sleep(256);
                    #endregion
                    string input, pattern;
                    if(channel==Channel.Controller) {
                        input = serial.ReadLine();
                        pattern = Globals.CONTROLLER;
                    } else {
                        input = serial.ReadLine();
                        pattern = Globals.MONITORING;
                    }
                    if(input.Length>=pattern.Length) {
                        if(input.Substring(0, pattern.Length).Equals(pattern)) {
                            return ports[i];
                        }
                    }
                } catch(TimeoutException ex) {
                    // was not the correct port; nothing to do ...
                    #region Logbook
                    Logger.Log(Level.FINE, "Serial port "+ports[i]+" timed out: "+ex.Message, Debug.COM_OUT);
                    #endregion
                } catch(UnauthorizedAccessException ex) {
                    // serial port is already open; e.g. in a terminal program ...
                    #region Logbook
                    Logger.Log(Level.FINE, "Access on serial port "+ports[i]+" denied: "+ex.Message, Debug.COM_OUT);
                    #endregion
                } finally {
                    if(serial!=null) {
                        serial.Close();
                    }
                }
            }
            return "n/a";
        }

        private List<string> getAvailableComPorts() {
            List<string> ports = new List<string>();
            #region Collect Available COM Ports
            try {
                ManagementObjectSearcher mgmt = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PnPEntity");
                foreach(ManagementObject item in mgmt.Get()) {
                    if(item["Caption"]!=null) {
                        string caption = item["Caption"].ToString();
                        if(caption.Contains("(COM")) {
                            int start = caption.LastIndexOf("(");
                            int length = caption.LastIndexOf(")")-caption.LastIndexOf("(");
                            ports.Add(caption.Substring(start+1, length-1));
                        }
                    }
                }
            } catch(ManagementException) { }
            #endregion
            return ports;
        }

        private void initializeMonitor(string port) {
            if(!port.Equals("n/a")) {
                monitor = new SerialPort();
                monitor.PortName = port;
                monitor.BaudRate = baudrate_3;
                monitor.Open();
                monitor.DataReceived += monitorDataReceived;
            }
        }

        private void attachCommandCallbacks() {
            messenger.Attach(onUnknownCommand);
            messenger.Attach((byte)Command.Error, onError);
            messenger.Attach((byte)Command.RttRequest, onRttRequest);
            messenger.Attach((byte)Command.ReadGpsSignal, onGpsSignal);
            messenger.Attach((byte)Command.ReadGyroscope, onGyroscopeSignal);
            messenger.Attach((byte)Command.ReadAnalogSensor, onAnalogSensor);
            messenger.Attach((byte)Command.ReadInfraredSignal, onInfraredSignal);
        }
        #endregion

        #region Output
        public void startup(int maximalLoopTime) {
            // initialize user defined settings
            if(launched) {
                lock(syncobj) {
                    SendCommand cmd = new SendCommand((byte)Command.Startup);
                    cmd.AddArgument(maximalLoopTime);
                    messenger.SendCommand(cmd);
                    #region Logbook
                    Logger.Log(Level.INFO, "Startup Atmel Microprocessor.", Debug.COM_OUT);
                    #endregion
                }
            }
        }

        public void shutdown() {
            if(launched) {
                lock(syncobj) {
                    SendCommand cmd = new SendCommand((byte)Command.Shutdown);
                    messenger.SendCommand(cmd);
                    #region Logbook
                    Logger.Log(Level.INFO, "Shutdown Atmel Microprocessor.", Debug.COM_OUT);
                    #endregion
                }
            }
        }

        public void measureRoundTripTime() {
            if(launched) {
                lock(syncobj) {
                    SendCommand cmd = new SendCommand((byte)Command.RttRequest);
                    messenger.SendCommand(cmd);
                }
            }
        }

        public void initGpsModule(uint readInterval) {
            if(launched) {
                lock(syncobj) {
                    SendCommand cmd = new SendCommand((byte)Command.InitGpsModule);
                    cmd.AddArgument(readInterval);
                    messenger.SendCommand(cmd);
                    #region Logbook
                    Logger.Log(Level.INFO, "Initialize GPS receiver on Serial1 at 9600 baud.", Debug.COM_OUT);
                    #endregion
                    Thread.Sleep(64);
                }
            }
        }

        public void changetGpsReadInterval(uint readInterval) {
            if(launched) {
                lock(syncobj) {
                    SendCommand cmd = new SendCommand((byte)Command.ChangeGpsInterval);
                    cmd.AddArgument(readInterval);
                    messenger.SendCommand(cmd);
                    #region Logbook
                    Logger.Log(Level.INFO, "Change GPS receiver read interval: "+readInterval+" [ms].", Debug.COM_OUT);
                    #endregion
                }
            }
        }

        public void initGyroscopeModule(ushort compId, uint interval, ushort address) {
            if(launched) {
                lock(syncobj) {
                    SendCommand cmd = new SendCommand((byte)Command.InitGyroscope);
                    cmd.AddArgument(compId);
                    cmd.AddArgument(interval);
                    cmd.AddArgument(address);
                    messenger.SendCommand(cmd);
                    #region Logbook
                    Logger.Log(Level.INFO, "Initialize gyroscope on i2c bus @ "+Toolkit.toHexFormat(address)+".", Debug.COM_OUT);
                    #endregion
                    Thread.Sleep(64);
                }
            }
        }

        public void changeGyroscopeReadInterval(ushort compId, uint interval) {
            if(launched) {
                lock(syncobj) {
                    SendCommand cmd = new SendCommand((byte)Command.ChangeGyroscopeInterval);
                    cmd.AddArgument(compId);
                    cmd.AddArgument(interval);
                    messenger.SendCommand(cmd);
                    #region Logbook
                    Logger.Log(Level.INFO, "Change gyroscope read interval: "+interval+" [ms].", Debug.COM_OUT);
                    #endregion
                }
            }
        }

        public void initInfraredRx(ushort pin) {
            if(launched) {
                lock(syncobj) {
                    SendCommand cmd = new SendCommand((byte)Command.InitInfraredRx);
                    cmd.AddArgument(pin);
                    messenger.SendCommand(cmd);
                    #region Logbook
                    Logger.Log(Level.INFO, "Initialize infrared receiver D#"+pin+".", Debug.COM_OUT);
                    #endregion
                    Thread.Sleep(64);
                }
            }
        }

        public void initInfraredTx(ushort pin) {
            if(launched) {
                lock(syncobj) {
                    SendCommand cmd = new SendCommand((byte)Command.InitInfraredTx);
                    messenger.SendCommand(cmd);
                    #region Logbook
                    Logger.Log(Level.INFO, "Initialize infrared transceiver D#"+pin+".", Debug.COM_OUT);
                    #endregion
                    Thread.Sleep(64);
                }
            }
        }

        public void sendInfraredSignal(ushort signal, short bits) {
            if(launched) {
                lock(syncobj) {
                    SendCommand cmd = new SendCommand((byte)Command.SendInfraredSignal);
                    cmd.AddArgument(signal);
                    cmd.AddArgument(bits);
                    messenger.SendCommand(cmd);
                    #region Logbook
                    Logger.Log(Level.INFO, "Send infrared signal "+Toolkit.toHexFormat(signal)+" consisting of "+bits+" [bits].", Debug.COM_OUT);
                    #endregion
                }
            }
        }

        public void initAnalogSensor(ushort compId, ushort pin, uint interval) {
            if(launched) {
                lock(syncobj) {
                    SendCommand cmd = new SendCommand((byte)Command.InitAnalogSensor);
                    cmd.AddArgument(compId);
                    cmd.AddArgument(pin);
                    cmd.AddArgument(interval);
                    messenger.SendCommand(cmd);
                    #region Logbook
                    Logger.Log(Level.INFO, "Initialize battery A#"+pin+".", Debug.COM_OUT);
                    #endregion
                    Thread.Sleep(64);
                }
            }
        }

        public void changeAnalogSensorPin(ushort compId, ushort pin) {
            if(launched) {
                lock(syncobj) {
                    SendCommand cmd = new SendCommand((byte)Command.ChangeAnalogSensorPin);
                    cmd.AddArgument(compId);
                    cmd.AddArgument(pin);
                    messenger.SendCommand(cmd);
                    #region Logbook
                    Logger.Log(Level.INFO, "Change battery pin A#"+pin+".", Debug.COM_OUT);
                    #endregion
                }
            }
        }

        public void changeAnalogSensorInterval(ushort compId, uint interval) {
            if(launched) {
                lock(syncobj) {
                    SendCommand cmd = new SendCommand((byte)Command.ChangeAnalogSensorInterval);
                    cmd.AddArgument(compId);
                    cmd.AddArgument(interval);
                    messenger.SendCommand(cmd);
                    #region Logbook
                    Logger.Log(Level.INFO, "Change battery interval "+interval+" [ms].", Debug.COM_OUT);
                    #endregion
                }
            }
        }

        public void initHumidity(ushort compId, ushort pin, uint interval) {
            if(launched) {
                lock(syncobj) {
                    SendCommand cmd = new SendCommand((byte)Command.InitHumidity);
                    cmd.AddArgument(compId);
                    cmd.AddArgument(pin);
                    cmd.AddArgument(interval);
                    messenger.SendCommand(cmd);
                    #region Logbook
                    Logger.Log(Level.INFO, "Initialize humidity sensor D#"+pin+".", Debug.COM_OUT);
                    #endregion
                    Thread.Sleep(64);
                }
            }
        }

        public void changeHumidityPin(ushort compId, ushort pin) {
            if(launched) {
                lock(syncobj) {
                    SendCommand cmd = new SendCommand((byte)Command.ChangeHumidityPin);
                    cmd.AddArgument(compId);
                    cmd.AddArgument(pin);
                    messenger.SendCommand(cmd);
                    #region Logbook
                    Logger.Log(Level.INFO, "Change humidity pin D#"+pin+".", Debug.COM_OUT);
                    #endregion
                }
            }
        }

        public void changeHumidityInterval(ushort compId, uint interval) {
            if(launched) {
                lock(syncobj) {
                    SendCommand cmd = new SendCommand((byte)Command.ChangeHumidityInterval);
                    cmd.AddArgument(compId);
                    cmd.AddArgument(interval);
                    messenger.SendCommand(cmd);
                    #region Logbook
                    Logger.Log(Level.INFO, "Change humidity interval "+interval+" [ms].", Debug.COM_OUT);
                    #endregion
                }
            }
        }

        public void initSonar(ushort compId, ushort triggerPin, ushort echoPin, ushort maximumDistance, uint interval) {
            if(launched) {
                lock(syncobj) {
                    SendCommand cmd = new SendCommand((byte)Command.InitSonar);
                    cmd.AddArgument(compId);
                    cmd.AddArgument(triggerPin);
                    cmd.AddArgument(echoPin);
                    cmd.AddArgument(maximumDistance);
                    cmd.AddArgument(interval);
                    messenger.SendCommand(cmd);
                    #region Logbook
                    Logger.Log(Level.INFO, "Initialize sonar sensor D#"+triggerPin+"#D"+echoPin+".", Debug.COM_OUT);
                    #endregion
                    Thread.Sleep(64);
                }
            }
        }

        public void changeSonarPins(ushort compId, ushort triggerPin, ushort echoPin) {
            if(launched) {
                lock(syncobj) {
                    SendCommand cmd = new SendCommand((byte)Command.ChangeSonarPins);
                    cmd.AddArgument(compId);
                    cmd.AddArgument(triggerPin);
                    cmd.AddArgument(echoPin);
                    messenger.SendCommand(cmd);
                    #region Logbook
                    Logger.Log(Level.INFO, "Change sonar pins D#"+triggerPin+"#D"+echoPin+".", Debug.COM_OUT);
                    #endregion
                }
            }
        }

        public void changeSonarInterval(ushort compId, uint interval) {
            if(launched) {
                lock(syncobj) {
                    SendCommand cmd = new SendCommand((byte)Command.ChangeSonarInterval);
                    cmd.AddArgument(compId);
                    cmd.AddArgument(interval);
                    messenger.SendCommand(cmd);
                    #region Logbook
                    Logger.Log(Level.INFO, "Change sonar interval to "+interval+" [ms].", Debug.COM_OUT);
                    #endregion
                }
            }
        }

        public void initServo(ushort compId, ushort pin, ushort address, ushort min, ushort max, ushort time, ushort interval, float position) {
            if(launched) {
                lock(syncobj) {
                    SendCommand cmd = new SendCommand((byte)Command.InitServo);
                    cmd.AddArgument(compId);
                    cmd.AddArgument(pin);
                    cmd.AddArgument(address);
                    cmd.AddArgument(min);
                    cmd.AddArgument(max);
                    cmd.AddArgument(time);
                    cmd.AddArgument(interval);
                    cmd.AddArgument(position);
                    messenger.SendCommand(cmd);
                    #region Logbook
                    Logger.Log(Level.INFO, "Initialize servo D#"+pin+" @ "+Toolkit.toHexFormat(address)+" min: "+min+" [us]; max: "+max+" [us]; time="+time+" [ms]", Debug.COM_OUT);
                    #endregion
                    Thread.Sleep(64);
                }
            }
        }

        public void changeServoPin(ushort compId, ushort pin, ushort address) {
            if(launched) {
                lock(syncobj) {
                    SendCommand cmd = new SendCommand((byte)Command.ChangeServoPin);
                    cmd.AddArgument(compId);
                    cmd.AddArgument(pin);
                    cmd.AddArgument(address);
                    messenger.SendCommand(cmd);
                    #region Logbook
                    Logger.Log(Level.INFO, "Change servo pin and board D#"+pin+" @ "+Toolkit.toHexFormat(address)+".", Debug.COM_OUT);
                    #endregion
                }
            }
        }

        public void updateServo(ushort compId, ushort pin, ushort address, ushort min, ushort max, ushort time) {
            if(launched) {
                lock(syncobj) {
                    SendCommand cmd = new SendCommand((byte)Command.UpdateServo);
                    cmd.AddArgument(compId);
                    cmd.AddArgument(pin);
                    cmd.AddArgument(address);
                    cmd.AddArgument(min);
                    cmd.AddArgument(max);
                    cmd.AddArgument(time);
                    messenger.SendCommand(cmd);
                    #region Logbook
                    Logger.Log(Level.INFO, "Update servo characteristics D#"+pin+" @ "+Toolkit.toHexFormat(address)+" min: "+min+" [us]; max: "+max+" [us]; time="+time+" [ms].", Debug.COM_OUT);
                    #endregion
                }
            }
        }

        public void setServoSignal(ushort compId, ushort pin, ushort address, ushort value) {
            if(launched) {
                lock(syncobj) {
                    SendCommand cmd = new SendCommand((byte)Command.SetServoSignal);
                    cmd.AddArgument(compId);
                    cmd.AddArgument(pin);
                    cmd.AddArgument(address);
                    cmd.AddArgument(value);
                    messenger.SendCommand(cmd);
                    #region Logbook
                    Logger.Log(Level.INFO, "Set servo value D#"+pin+" @ "+Toolkit.toHexFormat(address)+" to "+value+" [us].", Debug.COM_OUT);
                    #endregion
                }
            }
        }

        public void setServoPosition(ushort compId, ushort pin, ushort address, float position) {
            if(launched) {
                lock(syncobj) {
                    SendCommand cmd = new SendCommand((byte)Command.SetServoPosition);
                    cmd.AddArgument(compId);
                    cmd.AddArgument(pin);
                    cmd.AddArgument(address);
                    cmd.AddArgument(position);
                    messenger.SendCommand(cmd);
                    #region Logbook
                    Logger.Log(Level.INFO, "Set servo value D#"+pin+" @ "+Toolkit.toHexFormat(address)+" to "+position+"%.", Debug.COM_OUT);
                    #endregion
                }
            }
        }

        public void targetServoPosition(ushort compId, ushort pin, ushort address, float position, uint time) {
            if(launched) {
                lock(syncobj) {
                    SendCommand cmd = new SendCommand((byte)Command.TargetServoValue);
                    cmd.AddArgument(compId);
                    cmd.AddArgument(pin);
                    cmd.AddArgument(address);         
                    cmd.AddArgument(position);
                    cmd.AddArgument(time);
                    messenger.SendCommand(cmd);
                    #region Logbook
                    Logger.Log(Level.INFO, "Set servo target D#"+pin+" @ "+Toolkit.toHexFormat(address)+" to "+position+" [us].", Debug.COM_OUT);
                    #endregion
                }
            }
        }
        #endregion

        #region Input
        void onUnknownCommand(ReceivedCommand arguments) {
            #region Logbook
            Logger.Log(Level.WARNING, "Unknown command received from Atmel.");
            #endregion
        }

        void onError(ReceivedCommand arguments) {
            string msg = arguments.ReadStringArg();
            #region Logbook
            Logger.Log(Level.ERROR, "Error on Atmel microprocessor occured: "+msg);
            #endregion
        }

        void onRttRequest(ReceivedCommand arguments) {
            int loop = arguments.ReadInt32Arg();
            short ram = arguments.ReadInt16Arg();
            onRoundTripUpdate?.Invoke(loop, ram, serial.BytesSent(), serial.BytesReceived());
            #region Logbook
            Logger.Log(Level.INFO, "Received round trip time response from Atmel.", Debug.COM_IN);
            #endregion
        }

        void onGpsSignal(ReceivedCommand arguments) {
            ushort satellites = (ushort)arguments.ReadInt16Arg();
            float latitude = arguments.ReadFloatArg();
            float longitude = arguments.ReadFloatArg();
            float altitude = arguments.ReadFloatArg();
            float speed = arguments.ReadFloatArg();
            onGpsUpdate?.Invoke(satellites, latitude, longitude, altitude, speed);
            #region Logbook
            Logger.Log(Level.INFO, "Received GPS signal update: sat="+satellites+" lat="+latitude+" lng="+longitude+" alt="+altitude+" speed="+speed+".", Debug.COM_IN);
            #endregion
        }

        void onGyroscopeSignal(ReceivedCommand arguments) {
            short ax = arguments.ReadInt16Arg();
            short ay = arguments.ReadInt16Arg();
            short az = arguments.ReadInt16Arg();
            short gx = arguments.ReadInt16Arg();
            short gy = arguments.ReadInt16Arg();
            short gz = arguments.ReadInt16Arg();
            onGyroscopeUpdate?.Invoke(ax, ay, az, gx, gy, gz);
            #region Logbook
            Logger.Log(Level.INFO, "Received gyroscope update: ax="+ax+" ay="+ay+" az="+az+" gx="+gx+" gy="+gy+" gz="+gz+".", Debug.COM_IN);
            #endregion
        }

        void onAnalogSensor(ReceivedCommand arguments) {
            ushort compId = (ushort)arguments.ReadInt16Arg();
            short value = arguments.ReadInt16Arg();
            onSensorUpdate?.Invoke(compId, value);
            #region Logbook
            Logger.Log(Level.INFO, "Received sensor update from component #"+compId+" value: "+value+".", Debug.COM_IN);
            #endregion
        }

        void onInfraredSignal(ReceivedCommand arguments) {
            ushort signal = (ushort)arguments.ReadInt16Arg();
            ushort bits = (ushort)arguments.ReadInt16Arg();
            onInfraredSignalUpdate?.Invoke(signal, bits);
            #region Logbook
            Logger.Log(Level.INFO, "Received infrared signal "+Toolkit.toHexFormat(signal)+" consisting of "+bits+" [bits].", Debug.COM_IN);
            #endregion
        }
        #endregion

        #region Monitoring
        private void newLineReceived(object sender, CommandEventArgs evt) {
            #region Logbook
            Logger.Log(Level.INFO, "Received > " + evt.Command.CommandString(), Debug.COM_IN);
            #endregion
        }

        private void newLineSent(object sender, CommandEventArgs evt) {
            #region Logbook
            Logger.Log(Level.INFO, "Sent > " + evt.Command.CommandString(), Debug.COM_OUT);
            #endregion
        }

        private void monitorDataReceived(object sender, SerialDataReceivedEventArgs evt) {
            string line = monitor.ReadLine();
            line = line.Substring(0, line.Length-1);
            if(!line.Equals(Globals.MONITORING)) {
                onNewLineReported?.Invoke(line);
            }
        }
        #endregion

        #region Auto Shutdown
        private void sendKeepAliveMessage() {
            while(sending) {
                if(launched) {
                    lock(syncobj) {
                        SendCommand cmd = new SendCommand((byte)Command.KeepAlive);
                        messenger.SendCommand(cmd);
                        #region Logbook
                        Logger.Log(Level.INFO, "Keep alive message sent to Atmel.", Debug.COM_OUT);
                        #endregion
                    }
                }
                // wait for 500ms until sending next keep alive message to arduino
                lock(sendingLock) {
                    Monitor.Wait(sendingLock, TimeSpan.FromMilliseconds(500));
                }
            }
        }
        #endregion

        #region Bandwidth Counters
        private void resetBandwidthCounters() {
            while(measuring) {
                if(launched) {
                    if(serial!=null) {
                        bytesSent = serial.BytesSent()/5;
                        bytesReceived = serial.BytesReceived()/5;
                        serial.ResetCounter();
                    }
                }
                // wait for 5000ms until next reset
                lock(measuringLock) {
                    Monitor.Wait(measuringLock, TimeSpan.FromMilliseconds(5000));
                }
            }
        }
        #endregion

    }

}
