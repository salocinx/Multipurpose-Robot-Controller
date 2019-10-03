
#region Usings
using System;
using System.Xml.Serialization;
using System.Collections.Generic;
#endregion

namespace CommonCtrl {

    [Serializable]
    public abstract class Sensor : Component {

        #region Fields

        // sensor properties
        protected float data;                        // current value
        protected float minimum;                     // minimal value
        protected float maximum;                     // maximal value
        protected string postfix;                    // unit of measurement {cm, °C, %, etc.}

        // sensor value translation
        protected float slope;                       // linear function to convert integer value to sensor real world value; y=f(x)=ax+b [constant: a]
        protected float intercept;                   // linear function to convert integer value to sensor real world value; y=f(x)=ax+b [constant: b]
        protected uint readInterval;                 // interval at which the sensor is read from the hardware [ms]; max = 2147483647 [ms] = 35791 [min] = 596 [h] = 24 [d]

        // sensor logging
        protected Logbook logbook;                   // holds the historical data written to file
        protected bool logging;                      // should data be saved to a file ?
        protected uint logCapacity = 4096;            // maximal amount of entries before log is rotated
        protected uint logInterval = 5000;            // interval at which the sensor is logged to file [ms]; max = 2147483647 [ms] = 35791 [min] = 596 [h] = 24 [d]; best if it's a multiple of the read interval
        [NonSerialized]
        protected long logTime;                      // time of last log
        #endregion

        #region Properties
        public float Data {
            get { return data; }
            set { data = value; }
        }

        public float Minimum {
            get { return minimum; }
            set { minimum = value; }
        }

        public float Maximum {
            get { return maximum; }
            set { maximum = value; }
        }

        public string Postfix {
            get { return postfix; }
            set { postfix = value; }
        }

        public float Slope {
            get { return slope; }
            set { slope=value; }
        }

        public float Intercept {
            get { return intercept; }
            set { intercept=value; }
        }

        public uint ReadInterval {
            get { return readInterval; }
            set { readInterval = value; }
        }

        public bool Logging {
            get { return logging; }
            set { logging = value; }
        }

        public uint LogCapacity {
            get { return logCapacity; }
            set { logCapacity = value; }
        }

        public uint LogInterval {
            get { return logInterval; }
            set { logInterval = value; }
        }

        [XmlIgnore]
        public long LogTime {
            get { return logTime; }
            set { logTime = value; }
        }

        [XmlIgnore]
        public Logbook Logbook {
            get { return logbook; }
            set { logbook = value; }
        }
        #endregion

        #region Functions
        public abstract void log();
        #endregion

    }

}