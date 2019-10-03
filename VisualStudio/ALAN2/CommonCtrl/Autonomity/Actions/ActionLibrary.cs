
#region Usings
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
#endregion

namespace CommonCtrl {

    [Serializable]
    #region Xml Definitions
    [XmlRoot("Library")]
    [XmlInclude(typeof(SpeechAction))]
    [XmlInclude(typeof(ServoAction))]
    [XmlInclude(typeof(ServoLayer))]
    [XmlInclude(typeof(ServoKeyPoint))]
    #endregion
    public class ActionLibrary {

        #region Fields
        private List<ServoAction> servoActions = new List<ServoAction>();
        private List<SpeechAction> speechActions = new List<SpeechAction>();
        #endregion

        #region Lifecycle
        public ActionLibrary() {
            // used for xml serialization ...
        }

        public void defaults() {
            // no default actions yet ...
        }

        public void store() {
            try {
                using(TextWriter writer = new StreamWriter(@"Library.xml")) {
                    XmlSerializer serializer = new XmlSerializer(typeof(ActionLibrary));
                    serializer.Serialize(writer, this);
                }
            } catch(Exception ex) {
                #region Logbook
                Logger.Log(Level.WARNING, " Could not store action library.", ex);
                #endregion
            }
        }
        #endregion

        #region Properties
        public List<ServoAction> ServoActions {
            get { return servoActions; }
        }

        public List<SpeechAction> SpeechActions {
            get { return speechActions; }
        }
        #endregion

    }

}