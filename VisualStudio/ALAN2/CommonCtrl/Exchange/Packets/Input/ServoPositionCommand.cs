
#region Usings
using System;
using System.IO;
using System.Collections.Generic;
#endregion

namespace CommonCtrl {

    [Serializable]
    public class ServoPositionCommand : NetworkPacket {

        #region Fields
        private ushort pin;
        private ushort board;
        private ushort signal;
        private float position = -1f;
        #endregion

        #region Lifecycle
        public ServoPositionCommand(ushort componentId) : base(componentId) {
            // nothing to do yet ...
        }
        #endregion

        #region Properties
        public ushort Pin {
            get { return pin; }
            set { pin = value; }
        }

        public ushort Board {
            get { return board; }
            set { board = value; }
        }

        public ushort Signal {
            get { return signal; }
            set { signal = value; }
        }

        public float Position {
            get { return position; }
            set { position = value; }
        }
        #endregion

    }

}
