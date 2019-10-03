
#region Usings
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace CommonCtrl {

    [Serializable]
    public class UpdateSensorValue : NetworkPacket {

        #region Fields
        private long timestamp;
        private float data;
        #endregion

        #region Lifecycle
        public UpdateSensorValue(ushort componentId) : base(componentId) {
            this.timestamp = Toolkit.CurrentTimeMillis();
        }
        #endregion

        #region Properties
        public long Timestamp {
            get { return timestamp; }
            set { timestamp=value; }
        }

        public float Data {
            get { return data; }
            set { data = value; }
        }
        #endregion

    }

}