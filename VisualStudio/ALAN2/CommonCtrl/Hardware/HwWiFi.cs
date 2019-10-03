
#region Usings
using System;
using System.Text;
using NativeWifi;
#endregion

namespace CommonCtrl {

    [Serializable]
    public class HwWiFi {

        #region Fields
        private bool lan;
        private string ssid;
        private uint txRate;
        private uint rxRate;
        private uint signalQuality;
        #endregion

        #region Lifecycle
        public HwWiFi() {
            this.lan = false;
            this.ssid = "n/a";
            this.txRate = 0;
            this.rxRate = 0;
            this.signalQuality = 0;
        }

        public HwWiFi(bool lan) {
            this.lan = lan;
            this.ssid = "n/a";
            this.txRate = 0;
            this.rxRate = 0;
            this.signalQuality = 0;
        }

        public HwWiFi(Wlan.WlanAssociationAttributes network) {
            this.ssid = new String(Encoding.ASCII.GetChars(network.dot11Ssid.SSID, 0, (int)network.dot11Ssid.SSIDLength));
            this.txRate = network.txRate;
            this.rxRate = network.rxRate;
            this.signalQuality = network.wlanSignalQuality;
        }
        #endregion

        #region Properties
        public bool LAN {
            get { return lan; }
            set { lan = value; }
        }

        public string SSID {
            get { return ssid; }
            set { ssid = value; }
        }

        public uint TxRate {
            get { return txRate; }
            set { txRate = value; }
        }

        public uint RxRate {
            get { return rxRate; }
            set { rxRate = value; }
        }

        public uint SignalQuality {
            get { return signalQuality; }
            set { signalQuality = value; }
        }
        #endregion

    }

}
