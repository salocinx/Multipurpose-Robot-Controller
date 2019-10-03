
#region Usings
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
#endregion

namespace CommonCtrl {

    [Serializable]
    public class ServoAction {

        #region Fields
        private int id;
        private string name;
        private int zoom;
        private int speed;
        private int position;
        private List<ServoLayer> servoLayers = new List<ServoLayer>();
        #endregion

        #region Lifecycle
        public ServoAction() {
            // used for xml serialization ...
        }

        public ServoAction(int id,  string name) {
            this.id = id;
            this.name = name;
            this.zoom = 100;
            this.speed = 100;
            this.position = 0;
        }
        #endregion

        #region Properties
        public int Id {
            get { return id; }
            set { id = value; }
        }

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public int Zoom {
            get { return zoom; }
            set { zoom = value; }
        }

        public int Speed {
            get { return speed; }
            set { speed = value; }
        }

        public int Position {
            get { return position; }
            set { position = value; }
        }

        public List<ServoLayer> ServoLayers {
            get { return servoLayers; }
            set { servoLayers = value; }
        }
        #endregion

        #region Functions
        public override string ToString() {
            return name;
        }

        public int getMaxLength() {
            int maxLength = 0;
            foreach(ServoLayer servoLayer in servoLayers) {
                int layerLength = servoLayer.ServoKeyPoints[servoLayer.ServoKeyPoints.Count-1].X;
                if(layerLength > maxLength) {
                    maxLength = layerLength;
                }
            }
            return maxLength;
        }

        public ServoAction copy(int aid) {
            ServoAction instance = new ServoAction();
            instance.Id = aid;
            instance.Name = name;
            instance.Zoom = zoom;
            instance.Speed = speed;
            instance.Position = position;
            foreach(ServoLayer sl in servoLayers) {
                instance.ServoLayers.Add(sl.copy());
            }
            return instance;
        }
        #endregion

    }

}