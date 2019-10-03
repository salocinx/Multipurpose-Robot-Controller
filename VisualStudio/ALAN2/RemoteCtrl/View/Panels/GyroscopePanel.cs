
#region Usings
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonCtrl;
#endregion

namespace RemoteCtrl {

    public partial class GyroscopePanel : UserControl, iLocalUpdate {

        #region Fields
        private Agent agent;
        private Gyroscope gyroscope;
        #endregion

        #region Lifecycle
        public GyroscopePanel(Agent agent, Gyroscope gyroscope) {
            this.agent = agent;
            this.gyroscope = gyroscope;
            InitializeComponent();
            initializeGui();
            agent.subscribeLocalUpdate(this);
        }

        private void initializeGui() {
            this.UIThreadInvoke(delegate {
                // nothing to do yet ...
            });
        }
        #endregion

        #region Local Update
        public void initializeLocalUpdate() {
            onLocalUpdate();
        }

        public iComponent getInterest() {
            return gyroscope;
        }

        public List<iComponent> getInterests() {
            return null;
        }

        public void onLocalUpdate() {
            this.UIThreadInvoke(delegate {
                #region Visualize GX
                if(gyroscope.GX>0) {
                    pgsGxMinus.Value = 0;
                    pgsGxPlus.Value = Toolkit.clamp(gyroscope.GX, pgsGxPlus.Minimum, pgsGxPlus.Maximum);
                } else if(gyroscope.GX<0) {
                    pgsGxMinus.Value = Toolkit.clamp(Math.Abs(gyroscope.GX), pgsGxMinus.Minimum, pgsGxMinus.Maximum);
                    pgsGxPlus.Value = 0;
                } else {
                    pgsGxMinus.Value = 0;
                    pgsGxPlus.Value = 0;
                }
                #endregion
                #region Visualize GY
                if(gyroscope.GY>0) {
                    pgsGyMinus.Value = 0;
                    pgsGyPlus.Value = Toolkit.clamp(gyroscope.GY, pgsGyPlus.Minimum, pgsGyPlus.Maximum);
                } else if(gyroscope.GY<0) {
                    pgsGyMinus.Value = Toolkit.clamp(Math.Abs(gyroscope.GY), pgsGyMinus.Minimum, pgsGyMinus.Maximum);
                    pgsGyPlus.Value = 0;
                } else {
                    pgsGyMinus.Value = 0;
                    pgsGyPlus.Value = 0;
                }
                #endregion
                #region Visualize GZ
                if(gyroscope.GZ>0) {
                    pgsGzMinus.Value = 0;
                    pgsGzPlus.Value = Toolkit.clamp(gyroscope.GZ, pgsGzPlus.Minimum, pgsGzPlus.Maximum);
                } else if(gyroscope.GZ<0) {
                    pgsGzMinus.Value = Toolkit.clamp(Math.Abs(gyroscope.GZ), pgsGzMinus.Minimum, pgsGzMinus.Maximum);
                    pgsGzPlus.Value = 0;
                } else {
                    pgsGzMinus.Value = 0;
                    pgsGzPlus.Value = 0;
                }
                #endregion
                #region Visualize AX
                if(gyroscope.AX>0) {
                    pgsAxMinus.Value = 0;
                    pgsAxPlus.Value = Toolkit.clamp(gyroscope.AX, pgsAxPlus.Minimum, pgsAxPlus.Maximum);
                } else if(gyroscope.AX<0) {
                    pgsAxMinus.Value = Toolkit.clamp(Math.Abs(gyroscope.AX), pgsAxMinus.Minimum, pgsAxMinus.Maximum);
                    pgsAxPlus.Value = 0;
                } else {
                    pgsAxMinus.Value = 0;
                    pgsAxPlus.Value = 0;
                }
                #endregion
                #region Visualize AY
                if(gyroscope.AY>0) {
                    pgsAyMinus.Value = 0;
                    pgsAyPlus.Value = Toolkit.clamp(gyroscope.AY, pgsAyPlus.Minimum, pgsAyPlus.Maximum);
                } else if(gyroscope.AY<0) {
                    pgsAyMinus.Value = Toolkit.clamp(Math.Abs(gyroscope.AY), pgsAyMinus.Minimum, pgsAyMinus.Maximum);
                    pgsAyPlus.Value = 0;
                } else {
                    pgsAyMinus.Value = 0;
                    pgsAyPlus.Value = 0;
                }
                #endregion
                #region Visualize AZ
                if(gyroscope.AZ>0) {
                    pgsAzMinus.Value = 0;
                    pgsAzPlus.Value = Toolkit.clamp(gyroscope.AZ, pgsAzPlus.Minimum, pgsAzPlus.Maximum);
                } else if(gyroscope.AZ<0) {
                    pgsAzMinus.Value = Toolkit.clamp(Math.Abs(gyroscope.AZ), pgsAzMinus.Minimum, pgsAzMinus.Maximum);
                    pgsAzPlus.Value = 0;
                } else {
                    pgsAzMinus.Value = 0;
                    pgsAzPlus.Value = 0;
                }
                #endregion
            });
        }
        #endregion

        #region Event-Handling (Gui)
        /* This is an overload instead of attaching the Load(*) event manually.
         * Just copy and paste this code to other user-control classes. */
        protected override void OnLoad(EventArgs evt) {
            this.AutoSize = false;
            this.Dock = DockStyle.Fill;
            base.OnLoad(evt);
        }
        #endregion

    }

}
