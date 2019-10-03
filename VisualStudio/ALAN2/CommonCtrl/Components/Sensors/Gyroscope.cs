
#region Usings
using System;
using System.Xml.Serialization;
#endregion

namespace CommonCtrl {

    [Serializable]
    public class Gyroscope : Component {

        #region Fields
        private ushort address;
        private uint readInterval;
        private int ax, ay, az;
        private int gx, gy, gz;
        #endregion

        #region Lifecycle
        public Gyroscope() {
            // used for xml serialization ...
        }
        #endregion

        #region Functions
        public override void open() {
            if(active) {
                arduino.initGyroscopeModule(id, readInterval, address);
            }
        }

        public override void close() {
            // nothing to do yet ...
        }

        public override string ToString() {
            return name+" [I2C@"+Toolkit.toHexFormat(address)+"]";
        }
        #endregion

        #region Properties
        public ushort Address {
            get { return address; }
            set { address = value; }
        }

        public uint ReadInterval {
            get { return readInterval; }
            set { readInterval = value; }
        }

        [XmlIgnore]
        public int AX {
            get { return ax; }
            set { ax = value; }
        }

        [XmlIgnore]
        public int AY {
            get { return ay; }
            set { ay = value; }
        }

        [XmlIgnore]
        public int AZ {
            get { return az; }
            set { az = value; }
        }

        [XmlIgnore]
        public int GX {
            get { return gx; }
            set { gx = value; }
        }

        [XmlIgnore]
        public int GY {
            get { return gy; }
            set { gy = value; }
        }

        [XmlIgnore]
        public int GZ {
            get { return gz; }
            set { gz = value; }
        }
        #endregion

        #region Update
        public override void update(Component component) {
            if(GetType() == component.GetType()) {
                Gyroscope c = (Gyroscope)component;
                #region Change Read Interval
                if(c.ReadInterval!=readInterval) {
                    arduino.changeGyroscopeReadInterval(id, c.ReadInterval);
                }
                #endregion
                this.active = c.Active;
                this.name = c.Name;
                this.readInterval = c.ReadInterval;
                this.ax = c.AX;
                this.ay = c.AY;
                this.az = c.AZ;
                this.gx = c.GX;
                this.gy = c.GY;
                this.gz = c.GZ;
            }
        }
        #endregion

    }

}
