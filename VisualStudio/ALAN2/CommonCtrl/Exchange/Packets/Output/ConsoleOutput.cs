
#region Usings
using System;
using System.IO;
using System.Collections.Generic;
#endregion

namespace CommonCtrl {

    [Serializable]
    public class ConsoleOutput : NetworkPacket {

        #region Fields
        private bool origin;
        private string line;
        #endregion

        #region Lifecycle
        public ConsoleOutput(ushort componentId) : base(componentId) {
            // nothing to do yet ...
        }
        #endregion

        #region Properties
        public bool Origin {
            get { return origin; }
            set { origin = value; }
        }

        public string Line {
            get { return line; }
            set { line = value; }
        }
        #endregion

    }

}
