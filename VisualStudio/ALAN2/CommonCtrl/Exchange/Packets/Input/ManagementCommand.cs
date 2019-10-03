
#region Usings
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace CommonCtrl {

    [Serializable]
    public class ManagementCommand : NetworkPacket {

        #region Fields
        private bool restart;
        private bool shutdown;
        #endregion

        #region Lifecycle
        public ManagementCommand(ushort componentId) : base(componentId) {
            // nothing to do yet ...
        }
        #endregion

        #region Properties
        public bool Restart {
            get { return restart; }
            set { restart = value; }
        }

        public bool Shutdown {
            get { return shutdown; }
            set { shutdown = value; }
        }
        #endregion

    }

}
