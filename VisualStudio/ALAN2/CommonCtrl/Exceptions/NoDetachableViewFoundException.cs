
#region Usings
using System;
#endregion

namespace CommonCtrl {

    public class NoDetachableViewFoundException : Exception {

        public NoDetachableViewFoundException() { }

        public NoDetachableViewFoundException(string message) : base(message) { }

        public NoDetachableViewFoundException(string message, Exception inner) : base(message, inner) { }

    }

}
