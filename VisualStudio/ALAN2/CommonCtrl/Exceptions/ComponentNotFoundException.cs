
#region Usings
using System;
#endregion

namespace CommonCtrl {

    public class ComponentNotFoundException : Exception {

        public ComponentNotFoundException() { }

        public ComponentNotFoundException(int id) : base("Component with ID="+id+" not found.") { }

        public ComponentNotFoundException(string message) : base(message) { }

        public ComponentNotFoundException(string message, Exception inner) : base(message, inner) { }

    }

}
