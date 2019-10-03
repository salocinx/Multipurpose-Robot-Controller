
#region Usings
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using CommonCtrl;
#endregion

namespace CommonCtrl {

    [Serializable]
    public abstract class NetworkPacket {

        #region Fields
        protected string systemId;
        protected ushort componentId;
        protected ushort seqnum;
        #endregion

        #region Lifecycle
        public NetworkPacket(ushort componentId) {
            this.componentId = componentId;
        }
        #endregion

        #region Properties
        public string SystemId {
            set { systemId = value; }
            get { return systemId; }
        }

        public ushort ComponentId {
            set { componentId = value; }
            get { return componentId; }
        }

        public ushort SequenceNumber {
            set { seqnum = value; }
            get { return seqnum; }
        }
        #endregion

        #region Functions
        public override string ToString() {
            string result = "";
            result += "System-ID: "+systemId+Environment.NewLine;
            result += "Component-ID: "+componentId+Environment.NewLine;
            result += "Sequence-#: "+seqnum+Environment.NewLine;
            return result;
        }
        #endregion

        #region Deserialization
        public static NetworkPacket getPacket(byte[] data) {
            NetworkPacket packet = null;
            using(MemoryStream ms = new MemoryStream(data)) {
                BinaryFormatter bf = new BinaryFormatter();
                packet = (NetworkPacket)bf.Deserialize(ms);
            }
            return packet;
        }
        #endregion

    }

}
