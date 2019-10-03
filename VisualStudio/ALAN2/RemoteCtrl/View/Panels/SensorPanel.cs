
#region Usings
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonCtrl;
#endregion

namespace RemoteCtrl {

    public partial class SensorPanel : UserControl {

        #region Fields
        private Agent agent;
        private Component group;
        #endregion

        #region Lifecycle
        public SensorPanel(Agent agent, Component group) {
            this.agent = agent;
            this.group = group;
            InitializeComponent();
            initializeGui();
        }

        private void initializeGui() {
            this.UIThreadInvoke(delegate {
                try {
                    foreach(Sensor sensor in group.Components) {
                        if(sensor.Active) {
                            SensorControl ctrl = new SensorControl(agent, sensor);
                            ctrl.Location = new Point(0, lstSensors.Controls.Count*ctrl.Size.Height);
                            ctrl.Width = lstSensors.Width-20;
                            lstSensors.Controls.Add(ctrl);
                        }
                    }
                } catch(ComponentNotFoundException ex) {
                    #region Logbook
                    Logger.Log(Level.WARNING, ex);
                    #endregion
                }
            });
        }
        #endregion

        #region Event-Handling
        /* This is an overload instead of attaching the Load(*) event manually.
         * Just copy and paste this code to other user-control classes. */
        protected override void OnLoad(EventArgs evt) {
            this.AutoSize = false;
            this.Dock = DockStyle.Fill;
            base.OnLoad(evt);
        }

        private void lstSensors_SizeChanged(object sender, EventArgs evt) {
            foreach(SensorControl ctrl in lstSensors.Controls) {
                ctrl.Width = lstSensors.Width-20;
            }
        }
        #endregion

    }
}
