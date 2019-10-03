
#region Usings
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
#endregion

namespace CommonCtrl {

    [Serializable]
    public class Photoresistor : Sensor, iLogbook {

        #region Fields
        private ushort pin;                     // analog pin at which the photo resistor is attached to
        #endregion

        #region Lifecycle
        public Photoresistor() {
            // used for xml serialization ...
        }
        #endregion

        #region Properties
        public ushort Pin {
            get { return pin; }
            set { pin=value; }
        }
        #endregion

        #region Functions
        public override void open() {
            if(active) {
                // initialize photoresistor sensor on Arduino
                arduino.initAnalogSensor(id, pin, readInterval);
                // initialize monitor log file
                if(logging) {
                    // construct entire file path
                    string filepath = Logbook.getFilepath("Photoresistor@A"+pin);
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
                Photoresistor c = (Photoresistor)component;
                #region Change Pin
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
                this.slope = c.Slope;
                this.intercept = c.Intercept;
                #endregion
            }
        }
        #endregion

    }

}
