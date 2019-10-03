﻿
#region Usings
using System;
#endregion

namespace CommonCtrl {

    public class CameraNotFoundException : Exception {

        public CameraNotFoundException() { }

        public CameraNotFoundException(string message) : base(message) { }

        public CameraNotFoundException(string message, Exception inner) : base(message, inner) { }

    }

}
