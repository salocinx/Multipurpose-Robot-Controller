
#region Usings
using System;
using System.Xml.Serialization;
#endregion

namespace CommonCtrl {

    [Serializable]
    public class GPS : Component {

        #region Fields
        private ushort satellites;
        private float latitude;
        private float longitude;
        private float altitude;
        private float speed;
        private uint readInterval;
        #endregion

        #region Lifecycle
        public GPS() {
            // used for xml serialization ...
        }
        #endregion

        #region Functions
        public override void open() {
            if(active) {
                arduino.initGpsModule(readInterval);
            }
        }

        public override void close() {
            // nothing to do yet ...
        }

        public override string ToString() {
            return name+" [Serial1]";
        }
        #endregion

        #region Properties
        [XmlIgnore]
        public ushort Satellites {
            get { return satellites; }
            set { satellites = value; }
        }

        [XmlIgnore]
        public float Latitude {
            get { return latitude; }
            set { latitude = value; }
        }

        [XmlIgnore]
        public float Longitude {
            get { return longitude; }
            set { longitude = value; }
        }

        [XmlIgnore]
        public float Altitude {
            get { return altitude; }
            set { altitude = value; }
        }

        [XmlIgnore]
        public float Speed {
            get { return speed; }
            set { speed = value; }
        }

        public uint ReadInterval {
            get { return readInterval; }
            set { readInterval = value; }
        }
        #endregion

        #region Update
        public override void update(Component component) {
            if(GetType() == component.GetType()) {
                GPS c = (GPS)component;
                #region Change Read Interval
                if(c.ReadInterval!=readInterval) {
                    arduino.changetGpsReadInterval(c.ReadInterval);
                }
                #endregion
                this.active = c.Active;
                this.name = c.Name;
                this.satellites = c.Satellites;
                this.latitude = c.Latitude;
                this.longitude = c.Longitude;
                this.altitude = c.Altitude;
                this.speed = c.Speed;
                this.readInterval = c.ReadInterval;
            }
        }
        #endregion

    }

}
