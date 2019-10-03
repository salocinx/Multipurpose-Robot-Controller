
#region Usings
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace CommonCtrl {

    [Serializable]
    public class SpeechActionCommand : NetworkPacket {

        #region Fields
        private SpeechAction speechAction;
        #endregion

        #region Lifecycle
        public SpeechActionCommand(ushort componentId) : base(componentId) {
            // nothing to do yet ...
        }
        #endregion

        #region Properties
        public SpeechAction SpeechAction {
            get { return speechAction; }
            set { speechAction = value; }
        }
        #endregion

    }

}
