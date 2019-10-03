
#region Usings
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonCtrl;
#endregion

namespace RemoteCtrl {

    public partial class SensorWindow : Form, iLocalUpdate {

        #region Fields
        private Agent agent;
        private Sensor sensor;
        #endregion

        #region Lifecycle
        public SensorWindow(Agent agent, Sensor sensor) {
            this.agent = agent;
            this.sensor = sensor;
            InitializeComponent();
            initializeGui();
            agent.registerWindow(this);
            agent.subscribeLocalUpdate(this);
        }

        private void initializeGui() {
            this.Text = "Logbook ["+sensor.Name+"]";
            txtReadInterval.Text = sensor.ReadInterval.ToString();
            txtPostfix.Text = "["+sensor.Postfix+"]";
            viewSensorLogbook.setZoom(100);
            viewSensorLogbook.setSensor(sensor);
            viewSensorLogbook.onLogbookEntrySelection += onLogbookEntrySelection;
        }
        #endregion

        #region Local Update
        public void initializeLocalUpdate() {
            onLocalUpdate();
        }

        public iComponent getInterest() {
            return sensor;
        }

        public List<iComponent> getInterests() {
            return null;
        }

        public void onLocalUpdate() {
            this.UIThreadInvoke(delegate {
                viewSensorLogbook.Invalidate();
            });
        }
        #endregion

        #region Event-Handling
        private void trkZoom_ValueChanged(object sender, EventArgs evt) {
            lblZoom.Text = "Zoom ["+trkZoom.Value+"%]:";
            viewSensorLogbook.setZoom(trkZoom.Value);
            viewSensorLogbook.Invalidate();
        }

        private void pnlSensorLogbook_Scroll(object sender, ScrollEventArgs evt) {
            viewSensorLogbook.setCurrentX(evt.NewValue);
            viewSensorLogbook.Invalidate();
        }

        private void onLogbookEntrySelection(string timestamp, string value) {
            if(timestamp!=null && value!=null) {
                txtTimestamp.Text = timestamp;
                txtValue.Text = value;
            } else {
                txtTimestamp.Text = "";
                txtValue.Text = "";
            }
        }

        private void SensorWindow_FormClosing(object sender, FormClosingEventArgs evt) {
            if(evt.CloseReason == CloseReason.UserClosing) {
                evt.Cancel = true;
                Hide();
            } else {
                agent.unsubscribeLocalUpdate(this);
            }
        }
        #endregion

    }

}