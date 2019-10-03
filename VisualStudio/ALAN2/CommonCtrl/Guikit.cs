
#region Usings
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Threading.Tasks;
#endregion

namespace CommonCtrl {

    public class Guikit {

        private static PointF viewFactor;

        public static PointF ViewFactor {
            get { return viewFactor; }
            set { viewFactor = value; }
        }

        public static int m2v4x(int x) {
            return (int)(x*viewFactor.X/2.5f);
        }

        public static int m2v4y(float y) {
            return (int)(y*viewFactor.Y);
        }

        public static int v2m4x(int x) {
            return (int)(x*(1f/viewFactor.X)*2.5f);
        }

        public static float v2m4y(int y) {
            return y*(1f/viewFactor.Y);
        }

    }

}
