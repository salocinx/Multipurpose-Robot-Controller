
#region Usings
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace CommonCtrl {

    [Serializable]
    public class ServoActionCommand : NetworkPacket {

        #region Fields
        private ServoAction servoAction;
        #endregion

        #region Lifecycle
        public ServoActionCommand(ushort componentId) : base(componentId) {
            // nothing to do yet ...
        }
        #endregion

        #region Properties
        public ServoAction ServoAction {
            get { return servoAction; }
            set { servoAction = value; }
        }
        #endregion

    }

}
