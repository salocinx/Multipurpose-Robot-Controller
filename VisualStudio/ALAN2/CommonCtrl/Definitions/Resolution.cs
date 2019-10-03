
#region Usings
using System;
#endregion

namespace CommonCtrl {

    [Serializable]
    public class Resolution {

        #region Fields
        private int width;
        private int height;
        #endregion

        #region Lifecycle
        public Resolution() {
            // used for xml serialization ...
        }

        public Resolution(int width, int height) {
            this.width = width;
            this.height = height;
        }
        #endregion

        #region Operators
        public static bool operator == (Resolution resolution1, Resolution resolution2) {
            // if both are null, or both are same instance
            if(ReferenceEquals(resolution1, resolution2)) {
                return true;
            }
            // if one is null, but not both
            if(((object)resolution1 == null) || ((object)resolution2 == null)) {
                return false;
            }
            // return true if fields match
            return resolution1.Width == resolution2.Width && resolution1.Height == resolution2.Height;
        }

        public static bool operator != (Resolution resolution1, Resolution resolution2) {
            return !(resolution1 == resolution2);
        }

        public override bool Equals(Object obj) {
            // if parameter is null return false
            if(obj == null) return false;
            // if parameter cannot be cast to Agent return false
            Resolution resolution = obj as Resolution;
            if((Object)resolution == null) return false;
            // return true if the fields match
            return width == resolution.Width && height == resolution.Height;
        }

        public bool Equals(Resolution resolution) {
            // if parameter is null return false
            if((object)resolution == null) return false;
            // return true if the fields match
            return width == resolution.Width && height == resolution.Height;
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }
        #endregion

        #region Properties
        public int Width {
            get { return width; }
            set { width = value; }
        }

        public int Height {
            get { return height; }
            set { height = value; }
        }
        #endregion

        #region Functions
        public override string ToString() {
            return width+" x "+height;
        }
        #endregion

    }

}