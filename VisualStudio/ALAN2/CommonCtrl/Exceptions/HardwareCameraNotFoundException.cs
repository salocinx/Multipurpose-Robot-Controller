
#region Usings
using System;
#endregion

namespace CommonCtrl {

    public class HardwareCameraNotFoundException : Exception {

        public HardwareCameraNotFoundException() { }

        public HardwareCameraNotFoundException(int id) : base("Hardware camera with ID="+id+" not found on remote system.") { }

        public HardwareCameraNotFoundException(string message) : base(message) { }

        public HardwareCameraNotFoundException(string message, Exception inner) : base(message, inner) { }

    }

}
