
#region Usings
using System;
#endregion

namespace CommonCtrl {

    public class AgentNotFoundException : Exception {

        public AgentNotFoundException() { }

        public AgentNotFoundException(string message) : base(message) { }

        public AgentNotFoundException(string message, Exception inner) : base(message, inner) { }

    }

}
