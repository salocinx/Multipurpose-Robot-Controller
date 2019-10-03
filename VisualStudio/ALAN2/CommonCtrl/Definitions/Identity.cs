
#region Usings
using System;
#endregion

namespace CommonCtrl {

    [Serializable]
    public class Identity {

        private string id;
        private string name;
        private string revision;

        public Identity() {
            // used for xml serialization ...
        }

        public string Id {
            get { return id; }
            set { id = value; }

        }

        public string Name {
            get { return name; }
            set { name = value; }

        }

        public string Revision {
            get { return revision; }
            set { revision = value; }

        }

    }

}
