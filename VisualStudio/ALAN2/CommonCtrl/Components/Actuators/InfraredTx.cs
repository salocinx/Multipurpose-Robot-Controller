
#region Usings
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
#endregion

namespace CommonCtrl {

    [Serializable]
    public class InfraredTx : Infrared {

        #region Fields
        private ushort pin = 5;                   // interrupt driven pin for sending ir signals (fixed pin by IRremote lib) !          
        #endregion

        #region Enumerations
        
        #endregion

        #region Lifecycle
        public InfraredTx() {
            // used for xml serialization ...
        }
        #endregion

        #region Properties
        public ushort Pin {
            get { return pin; }
            set { pin=value; }
        }
        #endregion

        #region Functions
        public override void open() {
            if(active) {
                arduino.initInfraredTx(pin);
            }
        }

        public override void close() {
            if(active) {
                // nothing to do yet ...
            }
        }

        public override string ToString() {
            return name+" [D"+pin+"]";
        }
        #endregion

        #region Update
        public override void update(Component component) {
            if(GetType() == component.GetType()) {
                InfraredTx c = (InfraredTx)component;
                #region Update Properties
                this.active = c.Active;
                this.name = c.Name;
                this.protocol = c.Protocol;
                #endregion
            }
        }
        #endregion

    }

}
