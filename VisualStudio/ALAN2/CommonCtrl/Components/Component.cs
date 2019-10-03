
#region Usings
using System;
using System.Drawing;
using System.Xml.Serialization;
using System.Collections.Generic;
#endregion

namespace CommonCtrl {

    [Serializable]
    public class Component : iComponent {

        #region Fields
        protected ushort id;
        protected bool active;
        protected string name;
        protected string groupType;
        protected List<Component> components = new List<Component>();

        protected static ushort cid;

        [NonSerialized]
        protected Arduino arduino;
        #endregion

        #region Properties
        public ushort Id {
            get { return id; }
            set { id = value; }
        }

        public bool Active {
            get { return active; }
            set { active = value; }
        }

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public ushort CurrentId {
            get { return cid; }
            set { cid = value; }
        }

        public string GroupType {
            get { return groupType; }
            set { groupType = value; }
        }

        public void setComponentType(Type type) {
            this.groupType = type.FullName;
        }

        public Type getComponentType() {
            if(isGroup()) {
                return Type.GetType(groupType);
            } else {
                return this.GetType();
            }
        }

        public List<Component> Components {
            get { return components; }
            set { components = value; }
        }
        #endregion

        #region Functions
        public static ushort getComponentId() {
            cid++;
            return cid;
        }

        public virtual void open() {
            // nothing to do yet ...
        }

        public virtual void close() {
            // nothing to do yet ...
        }

        public bool isGroup() {
            return components.Count > 0;
        }

        public virtual void update(Component component) {
            this.active = component.Active;
            this.name = component.Name;
            this.components = component.Components;
        }

        public virtual void attach(Arduino arduino) {
            this.arduino = arduino;
        }

        public override string ToString() {
            return name;
        }
        #endregion

    }

}