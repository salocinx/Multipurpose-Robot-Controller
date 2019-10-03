
#region Usings
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonCtrl;
#endregion

namespace RemoteCtrl {

    public partial class InfraredPanel : UserControl, iLocalUpdate {

        #region Fields
        private Agent agent;
        private InfraredRx irRx;
        private InfraredTx irTx;
        #endregion

        #region Lifecycle
        public InfraredPanel(Agent agent, Component group) {
            this.agent = agent;
            foreach(Component component in group.Components) {
                if(component is InfraredRx) {
                    irRx = (InfraredRx)component;
                } else if(component is InfraredTx) {
                    irTx = (InfraredTx)component;
                }
            }
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
            return null;
        }

        public List<iComponent> getInterests() {
            return new List<iComponent> { irRx, irTx };
        }

        public void onLocalUpdate() {
            this.UIThreadInvoke(delegate {

                boxJoystickRx.Checked = irRx.Joystick;

                cmdARx.BackColor = irRx.A ? Color.DarkGreen : SystemColors.Control;
                cmdBRx.BackColor = irRx.B ? Color.DarkGreen : SystemColors.Control;
                cmdUpRx.BackColor = irRx.Up ? Color.DarkGreen : SystemColors.Control;
                cmdDownRx.BackColor = irRx.Down ? Color.DarkGreen : SystemColors.Control;
                cmdLeftRx.BackColor = irRx.Left ? Color.DarkGreen : SystemColors.Control;
                cmdRightRx.BackColor = irRx.Right ? Color.DarkGreen : SystemColors.Control;

                cmd0Rx.BackColor = irRx.Num0 ? Color.DarkGreen : SystemColors.Control;
                cmd1Rx.BackColor = irRx.Num1 ? Color.DarkGreen : SystemColors.Control;
                cmd2Rx.BackColor = irRx.Num2 ? Color.DarkGreen : SystemColors.Control;
                cmd3Rx.BackColor = irRx.Num3 ? Color.DarkGreen : SystemColors.Control;
                cmd4Rx.BackColor = irRx.Num4 ? Color.DarkGreen : SystemColors.Control;
                cmd5Rx.BackColor = irRx.Num5 ? Color.DarkGreen : SystemColors.Control;
                cmd6Rx.BackColor = irRx.Num6 ? Color.DarkGreen : SystemColors.Control;
                cmd7Rx.BackColor = irRx.Num7 ? Color.DarkGreen : SystemColors.Control;
                cmd8Rx.BackColor = irRx.Num8 ? Color.DarkGreen : SystemColors.Control;
                cmd9Rx.BackColor = irRx.Num9 ? Color.DarkGreen : SystemColors.Control;
                cmdEscapeRx.BackColor = irRx.Escape ? Color.DarkGreen : SystemColors.Control;
                cmdEnterRx.BackColor = irRx.Enter ? Color.DarkGreen : SystemColors.Control;

                cmdGenlockRx.BackColor = irRx.Genlock ? Color.DarkGreen : SystemColors.Control;
                cmdCDTVRx.BackColor = irRx.CDTV ? Color.DarkGreen : SystemColors.Control;
                cmdPowerRx.BackColor = irRx.Power ? Color.DarkGreen : SystemColors.Control;
                cmdRewindRx.BackColor = irRx.Rewind ? Color.DarkGreen : SystemColors.Control;
                cmdPlayPauseRx.BackColor = irRx.Play ? Color.DarkGreen : SystemColors.Control;
                cmdForwardRx.BackColor = irRx.Forward ? Color.DarkGreen : SystemColors.Control;
                cmdStopRx.BackColor = irRx.Stop ? Color.DarkGreen : SystemColors.Control;
                cmdVolumePlusRx.BackColor = irRx.VolumePlus ? Color.DarkGreen : SystemColors.Control;
                cmdVolumeMinusRx.BackColor = irRx.VolumeMinus ? Color.DarkGreen : SystemColors.Control;

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

        private void timReset_Tick(object sender, EventArgs evt) {

            cmdARx.BackColor = SystemColors.Control;
            cmdBRx.BackColor = SystemColors.Control;
            cmdUpRx.BackColor = SystemColors.Control;
            cmdDownRx.BackColor = SystemColors.Control;
            cmdLeftRx.BackColor = SystemColors.Control;
            cmdRightRx.BackColor = SystemColors.Control;

            cmd0Rx.BackColor = SystemColors.Control;
            cmd1Rx.BackColor = SystemColors.Control;
            cmd2Rx.BackColor = SystemColors.Control;
            cmd3Rx.BackColor = SystemColors.Control;
            cmd4Rx.BackColor = SystemColors.Control;
            cmd5Rx.BackColor = SystemColors.Control;
            cmd6Rx.BackColor = SystemColors.Control;
            cmd7Rx.BackColor = SystemColors.Control;
            cmd8Rx.BackColor = SystemColors.Control;
            cmd9Rx.BackColor = SystemColors.Control;
            cmdEscapeRx.BackColor = SystemColors.Control;
            cmdEnterRx.BackColor = SystemColors.Control;

            cmdGenlockRx.BackColor = SystemColors.Control;
            cmdCDTVRx.BackColor = SystemColors.Control;
            cmdPowerRx.BackColor = SystemColors.Control;
            cmdRewindRx.BackColor = SystemColors.Control;
            cmdPlayPauseRx.BackColor = SystemColors.Control;
            cmdForwardRx.BackColor = SystemColors.Control;
            cmdStopRx.BackColor = SystemColors.Control;
            cmdVolumePlusRx.BackColor = SystemColors.Control;
            cmdVolumeMinusRx.BackColor = SystemColors.Control;

        }
        #endregion

    }

}
