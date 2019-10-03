
#region Usings
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace CommonCtrl {

    [Serializable]
    public class UpdateActionLibrary : NetworkPacket {

        #region Fields
        private ActionLibrary actionLibrary;
        #endregion

        #region Lifecycle
        public UpdateActionLibrary(ushort componentId) : base(componentId) {
            // nothing to do yet ...
        }
        #endregion

        #region Properties
        public ActionLibrary ActionLibrary {
            get { return actionLibrary; }
            set { actionLibrary = value; }
        }
        #endregion

    }

}
