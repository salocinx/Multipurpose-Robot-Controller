
#region Usings
using System;
using System.IO;
using System.Net;
#endregion

namespace CommonCtrl {

    [Serializable]
    public class BeaconSignal : NetworkPacket {

        #region Fields
        private string name;
        private string address;
        private string revision;
        #endregion

        #region Lifecycle
        public BeaconSignal(ushort componentId) : base(componentId) {
            // nothing to do yet ...
        }
        #endregion

        #region Properties
        public string Name {
            get { return name; }
            set { name = value; }
        }

        public string Address {
            get { return address; }
            set { address = value; }
        }

        public string Revision {
            get { return revision; }
            set { revision = value; }
        }
        #endregion

        #region Functions
        public override string ToString() {
            string result = base.ToString();
            result += "Name: "+name+Environment.NewLine;
            result += "Address: "+address.ToString()+Environment.NewLine;
            result += "Revision: "+revision.ToString()+Environment.NewLine;
            return result;
        }
        #endregion

    }

}
