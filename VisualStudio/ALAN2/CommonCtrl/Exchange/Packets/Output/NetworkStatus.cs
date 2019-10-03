
#region Usings
using System;
using System.IO;
#endregion

namespace CommonCtrl {

    [Serializable]
    public class NetworkStatus : NetworkPacket {

        #region Fields
        private bool lan = false;
        private HwWiFi wifi = new HwWiFi();
        #endregion

        #region Lifecycle
        public NetworkStatus(ushort componentId) : base(componentId) {
            // nothing to do yet ...
        }
        #endregion

        #region Properties
        public bool LAN {
            get { return lan; }
            set { lan = value; }
        }

        public HwWiFi WiFi {
            get { return wifi; }
            set { wifi = value; }
        }
        #endregion

    }

}
