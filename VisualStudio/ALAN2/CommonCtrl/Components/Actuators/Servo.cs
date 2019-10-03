
#region Usings
using System;
using System.Drawing;
using CommonCtrl;
#endregion

namespace CommonCtrl {

    [Serializable]
    public class Servo : Actuator {

        #region Fields
        private ushort pin;          // pwm pin the servo is attached to
        private ushort address;      // pwm board type (arduino=0x20, adafruit=[0x40, 0x43])
        private float position;      // current position of the servo as percentage from [min, max]
        private ushort time;         // time in [ms] the servo takes to turn the full range from [min, max]
        private ushort minimum;      // minimum pwm signal in [us] => position = 0
        private ushort maximum;      // maximum pwm signal in [us] => position = 100

        private bool viewAxisX;      // is servo controlled by x-axis in remote view ?
        private bool viewAxisY;      // is servo controlled by y-axis in remote view ?
        private bool viewReversed;   // are servo values mirrored on the specific axis ?
        private float viewRotation;  // is servo used as motor controller ?
        #endregion

        #region Lifecycle
        public Servo() {
            // used for xml serialization ...
        }
        #endregion

        #region Properties
        public ushort Pin {
            get { return pin; }
            set { pin = value; }
        }

        public ushort Address {
            get { return address; }
            set { address = value; }
        }

        public float Position {
            get { return position; }
            set { position = value; }
        }

        public ushort Time {
            get { return time; }
            set { time = value; }
        }

        public ushort Minimum {
            get { return minimum; }
            set { minimum = value; }
        }

        public ushort Maximum {
            get { return maximum; }
            set { maximum = value; }
        }

        public bool ViewAxisX {
            get { return viewAxisX; }
            set { viewAxisX = value; }
        }

        public bool ViewAxisY {
            get { return viewAxisY; }
            set { viewAxisY = value; }
        }

        public bool ViewReversed {
            get { return viewReversed; }
            set { viewReversed = value; }
        }

        public float ViewRotation {
            get { return viewRotation; }
            set { viewRotation = value; }
        }
        #endregion

        #region Functions
        public override void open() {
            if(active) {
                arduino.initServo(id, pin, address, minimum, maximum, time, Globals.DEFAULT_SERVO_INTERVAL, position);
            }
        }

        public override void close() {
            // nothing to do yet ...
        }

        public bool validate(int x1, int x2, float y1, float y2) {
            int dx = Math.Abs(x2-x1);
            float dy = Math.Abs(y2-y1);
            float tmax = time*(dy/100f);
            return dx>=tmax;
        }

        public override string ToString() {
            return name+" [PWM"+pin+"] [I2C@"+Toolkit.toHexFormat(address)+"]";
        }
        #endregion

        #region Update
        public override void update(Component component) {
            if(GetType() == component.GetType()) {
                Servo c = (Servo)component;
                #region Change Pin or Address
                if(c.Pin!=pin || c.Address!=address) {
                    arduino.changeServoPin(id, c.Pin, c.Address);
                }
                #endregion
                #region Change Properties
                if(c.Minimum!=minimum || c.Maximum!=maximum || c.Time!=time) {
                    arduino.updateServo(id, c.Pin, c.Address, minimum, maximum, time);
                }
                #endregion
                #region Update Properties
                this.active = c.Active;
                this.name = c.Name;
                this.pin = c.Pin;
                this.address = c.Address;
                this.position = c.Position;
                this.time = c.Time;
                this.minimum = c.Minimum;
                this.maximum = c.Maximum;
                this.viewAxisX = c.ViewAxisX;
                this.viewAxisY = c.ViewAxisY;
                this.viewReversed = c.ViewReversed;
                this.viewRotation = c.ViewRotation;
                #endregion
            }
        }
        #endregion

    }

}
