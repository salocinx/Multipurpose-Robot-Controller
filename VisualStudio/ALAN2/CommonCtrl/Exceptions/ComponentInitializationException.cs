
#region Usings
using System;
#endregion

namespace CommonCtrl {

    public class ComponentInitializationException : Exception {

        public ComponentInitializationException() { }

        public ComponentInitializationException(string message) : base(message) { }

        public ComponentInitializationException(string message, Exception inner) : base(message, inner) { }

    }

}
