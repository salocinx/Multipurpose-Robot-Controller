
#region Usings
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Drawing;
using System.Threading;
using System.Collections.Generic;
#endregion

namespace CommonCtrl {

    [Serializable]
    public class ServoLayer {

        #region Fields
        private ushort servoId;
        private string servoName;
        private bool locked;
        private bool visible;
        [NonSerialized]
        private bool selected;
        private List<ServoKeyPoint> servoKeyPoints = new List<ServoKeyPoint>();
        #endregion

        #region Lifecycle
        public ServoLayer() {
            // used for xml serialization ...
        }

        public ServoLayer(ushort servoId, string servoName) {
            this.servoId = servoId;
            this.servoName = servoName;
            this.locked = false;
            this.visible = true;
        }
        #endregion

        #region Properties
        public ushort ServoId {
            get { return servoId; }
            set { servoId = value; }
        }

        public string ServoName {
            get { return servoName; }
            set { servoName = value; }
        }

        public bool Locked {
            get { return locked; }
            set { locked = value; }
        }

        public bool Visible {
            get { return visible; }
            set { visible = value; }
        }

        public bool Selected {
            get { return selected; }
            set { selected = value; }
        }

        public List<ServoKeyPoint> ServoKeyPoints {
            get { return servoKeyPoints; }
            set { servoKeyPoints = value; }
        }
        #endregion

        #region Functions
        public bool hasStartNode() {
            foreach(ServoKeyPoint keyPoint in servoKeyPoints) {
                if(keyPoint.isStartNode()) {
                    return true;
                }
            }
            return false;
        }

        public bool isKeyPoint(int step) {
            foreach(ServoKeyPoint point in servoKeyPoints) {
                if(point.X==step) {
                    return true;
                }
            }
            return false;
        }

        public ServoKeyPoint getKeyPointAt(int step) {
            foreach(ServoKeyPoint point in servoKeyPoints) {
                if(point.X==step) {
                    return point;
                }
            }
            return null;
        }

        public ServoKeyPoint getNextKeyPoint(int step) {
            for(int i=0; i<servoKeyPoints.Count; i++) {
                if(servoKeyPoints[i].X == step) {
                    if(i<servoKeyPoints.Count-1) {
                        return servoKeyPoints[i+1];
                    }
                }
            }
            return null;
        }

        public ServoLayer copy() {
            ServoLayer instance = new ServoLayer();
            instance.ServoId = servoId;
            instance.ServoName = servoName;
            instance.Locked = locked;
            instance.Visible = visible;
            foreach(ServoKeyPoint skp in servoKeyPoints) {
                instance.ServoKeyPoints.Add(skp.copy());
            }
            return instance;
        }
        #endregion

    }

}
