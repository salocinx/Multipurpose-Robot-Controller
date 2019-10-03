
#region Usings
using System;
using System.IO;
using System.Collections.Generic;
#endregion

namespace CommonCtrl {

    [Serializable]
    public class UpdateComponent : NetworkPacket {

        #region Fields
        private Component component;
        #endregion

        #region Lifecycle
        public UpdateComponent(ushort componentId) : base(componentId) {
            // nothing to do yet ...
        }
        #endregion

        #region Properties
        public Component Component {
            get { return component; }
            set { component = value; }
        }
        #endregion

    }

}