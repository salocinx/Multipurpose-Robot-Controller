
#region Usings
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonCtrl;
#endregion

namespace RemoteCtrl {

    #region Delegates
    public delegate void OnServoLayerPropertyChanged(bool visible, bool locked);
    public delegate void OnServoLayerSelectionChanged(ServoLayerControl control, ServoLayer selection);
    #endregion

    public partial class ServoLayerControl : UserControl {

        #region Fields
        private ServoLayer servoLayer;
        #endregion

        #region Events
        public event MouseEventHandler onMouseClick;
        public event OnServoLayerPropertyChanged onServoLayerPropertyChanged;
        public event OnServoLayerSelectionChanged onServoLayerSelectionChanged;
        #endregion

        #region Lifecycle
        public ServoLayerControl(ServoLayer servoLayer) {
            this.servoLayer = servoLayer;
            InitializeComponent();
            this.updateGui();
        }
        #endregion

        #region Properties
        public ServoLayer ServoLayer {
            get { return servoLayer; }
        }
        #endregion

        #region Functions
        public bool selected() {
            return servoLayer.Selected;
        }

        public void select() {
            servoLayer.Selected = true;
            BackColor = SystemColors.Highlight;
            onServoLayerSelectionChanged?.Invoke(this, servoLayer);
        }

        public void deselect() {
            servoLayer.Selected = false;
            BackColor = SystemColors.Window;
        }

        public void updateGui() {
            txtName.Text = servoLayer.ServoName;
            boxVisible.Checked = servoLayer.Visible;
            boxLocked.Checked = servoLayer.Locked;
        }
        #endregion

        #region Event-Handling
        private void boxVisible_CheckedChanged(object sender, EventArgs evt) {
            servoLayer.Visible = boxVisible.Checked;
            onServoLayerPropertyChanged?.Invoke(servoLayer.Visible, servoLayer.Locked);
        }

        private void boxLocked_CheckedChanged(object sender, EventArgs evt) {
            servoLayer.Locked = boxLocked.Checked;
            onServoLayerPropertyChanged?.Invoke(servoLayer.Visible, servoLayer.Locked);
        }

        private void ServoLayerControl_MouseClick(object sender, MouseEventArgs evt) {
            // deselect all other servo layer controls in the list
            foreach(ServoLayerControl ctrl in Parent.Controls) {
                if(ctrl!=this) {
                    ctrl.deselect();
                }
            }
            // select this one
            this.select();
            // forward click event to parent list/panel
            onMouseClick?.Invoke(sender, evt);
        }
        #endregion

    }

}
