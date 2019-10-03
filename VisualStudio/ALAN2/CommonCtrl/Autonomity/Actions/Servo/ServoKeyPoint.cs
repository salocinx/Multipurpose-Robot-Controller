
#region Usings
using System;
using System.Drawing;
using System.Xml.Serialization;
#endregion

namespace CommonCtrl {

    [Serializable]
    public class ServoKeyPoint {

        #region Fields
        private int x;                  // x-axis: 10px = 20ms; 100px = 200ms; 500px = 1000ms
        private float y;                // y-axis: dependent on window height; [0.0, 100.0] %
        private bool start;
        [NonSerialized]
        private bool selected;
        #endregion

        #region Lifecycle
        public ServoKeyPoint() {
            // used for xml serialization ...
        }

        public ServoKeyPoint(int x, float y) {
            this.x = Toolkit.round(x, Globals.DEFAULT_SERVO_RESOLUTION_X);
            this.y = y;
        }
        #endregion

        #region Properties
        public int X {
            get { return x; }
            set { x = value; }
        }

        public float Y {
            get { return y; }
            set { y = value; }
        }

        public bool Start {
            get { return start; }
            set { start = value; }
        }

        public bool Selected {
            get { return selected; }
            set { selected = value; }
        }
        #endregion

        #region Properties (Computed)
        [XmlIgnore]
        public int ViewX {
            get { return Guikit.m2v4x(x); }
            set { x = Guikit.v2m4x(value); }
        }

        [XmlIgnore]
        public float ViewY {
            get { return Guikit.m2v4y(y); }
            set { y = Guikit.v2m4y((int)value); }
        }

        [XmlIgnore]
        public PointF ViewPosition {
            get { return new PointF(ViewX, ViewY); }
            set { ViewX = (int)value.X; ViewY = value.Y; }
        }
        #endregion

        #region Functions
        public bool isStartNode() {
            return start;
        }

        public void setStartNode() {
            this.start = true;
        }

        public void snap() {
            this.x = Toolkit.round(x, Globals.DEFAULT_SERVO_RESOLUTION_X);
        }

        public ServoKeyPoint copy() {
            ServoKeyPoint instance = new ServoKeyPoint();
            instance.X = x;
            instance.Y = y;
            instance.Start = start;
            return instance;
        }
        #endregion

    }

}
