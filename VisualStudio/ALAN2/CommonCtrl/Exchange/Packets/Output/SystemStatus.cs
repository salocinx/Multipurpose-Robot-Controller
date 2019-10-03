
#region Usings
using System;
using System.IO;
using System.Collections.Generic;
#endregion

namespace CommonCtrl {

    [Serializable]
    public class SystemStatus : NetworkPacket {

        #region Fields
        private HwWiFi wifi;
        private HwSystem system;
        private Arduino arduino;
        private List<HwCamera> cameras;
        private List<Component> components;
        private ActionLibrary actionLibrary;
        private List<string> atmelConsole;
        private List<string> agentConsole;
        #endregion

        #region Lifecycle
        public SystemStatus(ushort componentId) : base(componentId) {
            // nothing to do yet ...
        }
        #endregion

        #region Properties
        public HwWiFi WiFi {
            get { return wifi; }
            set { wifi = value; }
        }

        public HwSystem System {
            get { return system; }
            set { system = value; }
        }

        public Arduino Arduino {
            get { return arduino; }
            set { arduino = value; }
        }

        public List<HwCamera> Cameras {
            get { return cameras; }
            set { cameras = value; }
        }

        public List<Component> Components {
            get { return components; }
            set { components = value; }
        }

        public ActionLibrary ActionLibrary {
            get { return actionLibrary; }
            set { actionLibrary = value; }
        }

        public List<string> AtmelConsole {
            get { return atmelConsole; }
            set { atmelConsole = value; }
        }

        public List<string> AgentConsole {
            get { return agentConsole; }
            set { agentConsole = value; }
        }
        #endregion

    }

}