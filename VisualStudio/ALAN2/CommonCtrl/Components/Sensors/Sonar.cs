
#region Usings
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
#endregion

namespace CommonCtrl {

    [Serializable]
    public class Sonar : Sensor, iLogbook {

        #region Fields
        private ushort triggerPin;          // pin at which the trigger signal is sent from
        private ushort echoPin;             // pin at which the echo signal is read from
        #endregion

        #region Lifecycle
        public Sonar() {
            // used for xml serialization ...
        }
        #endregion

        #region Properties
        public ushort TriggerPin {
            get { return triggerPin; }
            set { triggerPin = value; }
        }

        public ushort EchoPin {
            get { return echoPin; }
            set { echoPin = value; }
        }
        #endregion

        #region Functions
        public override void open() {
            if(active) {
                // initialize sonar sensor on Arduino
                arduino.initSonar(id, triggerPin, echoPin, (ushort)maximum, readInterval);
                // initialize monitor log file
                if(logging) {
                    // construct entire file path
                    string filepath = Logbook.getFilepath("Sonar@D"+triggerPin+"D"+echoPin);
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
                        entry.Data = (float)data;
                        logbook.append(entry);
                        logTime = Toolkit.CurrentTimeMillis();
                    }
                }
            }
        }

        public override string ToString() {
            return name+" [D"+triggerPin+"+D"+echoPin+"]";
        }
        #endregion

        #region Update
        public override void update(Component component) {
            if(GetType() == component.GetType()) {
                Sonar c = (Sonar)component;
                #region Change Pins
                if(c.TriggerPin!=triggerPin || c.EchoPin!=echoPin) {
                    arduino.changeSonarPins(id, c.TriggerPin, c.EchoPin);
                }
                #endregion
                #region Change Read Interval
                if(c.ReadInterval!=readInterval) {
                    arduino.changeSonarInterval(id, c.ReadInterval);
                }
                #endregion
                #region Update Properties
                this.active = c.Active;
                this.name = c.Name;
                this.data = c.Data;
                this.minimum = c.Minimum;
                this.maximum = c.Maximum;
                this.triggerPin = c.TriggerPin;
                this.echoPin = c.EchoPin;
                this.readInterval = c.ReadInterval;
                this.logging = c.Logging;
                this.logCapacity = c.LogCapacity;
                this.logInterval = c.LogInterval;
                #endregion
            }
        }
        #endregion

    }

}