
#region Usings
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
#endregion

namespace CommonCtrl {

    [Serializable]
    public class Battery : Sensor, iLogbook {

        #region Fields
        private ushort pin;                     // analog pin at which the voltage divider is attached to
        private float criticalVoltage;          // critical battery voltage; values below will fire an event (e.g. return to charging station, shutdown)
        private bool charging;                  // determined by voltage above max voltage -> is battery currently charging ? 
        private float[] state;                  // voltage levels to indicate battery state float[6]
        #endregion

        #region Lifecycle
        public Battery() {
            // used for xml serialization ...
        }
        #endregion

        #region Properties
        public ushort Pin {
            get { return pin; }
            set { pin=value; }
        }

        public float CriticalVoltage {
            get { return criticalVoltage; }
            set { criticalVoltage=value; }
        }

        public bool Charging {
            get { return charging; }
            set { charging=value; }
        }

        public float[] State {
            get { return state; }
            set { state=value; }
        }
        #endregion

        #region Functions
        public override void open() {
            if(active) {
                // initialize battery sensor on Arduino
                arduino.initAnalogSensor(id, pin, readInterval);
                // initialize monitor log file
                if(logging) {
                    // construct entire file path
                    string filepath = Logbook.getFilepath("Battery@A"+pin);
                    // create log book itself
                    if(File.Exists(filepath)) {
                        #region Load Logbook
                        try {
                            using(FileStream stream = new FileStream(filepath, FileMode.Open)) {
                                XmlSerializer serializer = new XmlSerializer(typeof(Logbook));
                                XmlReader reader = XmlReader.Create(stream);
                                this.logbook = (Logbook)serializer.Deserialize(reader);
                            }
                        } catch(Exception ex) {
                            #region Logbook
                            Logger.Log(Level.WARNING, " Could not load sensor log book: "+filepath, ex);
                            #endregion
                        }
                        #endregion
                    } else {
                        #region Init Logbook
                        this.logbook = new Logbook(filepath, logCapacity);
                        this.logbook.store();
                        #endregion
                    }
                }
            }
        }

        public override void close() {
            if(active) {
                if(logging) {
                    logbook.store();
                }
            }
        }

        public override void attach(Arduino arduino) {
            this.arduino = arduino;
        }

        public override void log() {
            if(logging) {
                if(logbook!=null) {
                    if(logInterval<=readInterval || (logInterval>readInterval && Toolkit.CurrentTimeMillis()-logTime>=logInterval)) {
                        LogbookEntry entry = new LogbookEntry();
                        entry.Timestamp = Toolkit.CurrentTimeMillis();
                        entry.Data = data;
                        logbook.append(entry);
                        logTime = Toolkit.CurrentTimeMillis();
                    }
                }
            }
        }

        public override string ToString() {
            return name+" [A"+pin+"]";
        }
        #endregion

        #region Update
        public override void update(Component component) {
            if(GetType() == component.GetType()) {
                Battery c = (Battery)component;
                #region Change Pin or Board
                if(c.Pin!=pin) {
                    arduino.changeAnalogSensorPin(id, c.Pin);
                }
                #endregion
                #region Change Read Interval
                if(c.ReadInterval!=readInterval) {
                    arduino.changeAnalogSensorInterval(id, c.ReadInterval);
                }
                #endregion
                #region Update Properties
                this.active = c.Active;
                this.name = c.Name;
                this.data = c.Data;
                this.minimum = c.Minimum;
                this.maximum = c.Maximum;
                this.pin = c.Pin;
                this.readInterval = c.ReadInterval;
                this.logging = c.Logging;
                this.logCapacity = c.LogCapacity;
                this.logInterval = c.LogInterval;
                this.criticalVoltage = c.CriticalVoltage;
                this.charging = c.Data>c.Maximum;
                this.slope = c.Slope;
                this.intercept = c.Intercept;
                this.state = c.State;
                #endregion
            }
        }
        #endregion

    }

}
