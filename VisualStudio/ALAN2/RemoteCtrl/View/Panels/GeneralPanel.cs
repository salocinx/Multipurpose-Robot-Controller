
#region Usings
using System;
using System.Net;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using CommonCtrl;
#endregion

namespace RemoteCtrl {

    public partial class GeneralPanel : UserControl {

        #region Fields
        private Agent agent;
        #endregion

        #region Lifecycle
        public GeneralPanel(Agent agent) {
            this.agent = agent;
            InitializeComponent();
            initializeGui();
            agent.onRoundTripTimePackedReceived += onRoundTripTimePackedReceived;
            NetworkStatistics.getInstance().onNetworkStatisticsUpdated += updateNetworkStatistics;
            txtRevision.Text = "Agent Remote Controller (rev. "+agent.Revision+")";
        }
        #endregion

        #region Functions
        private void initializeGui() {
            // set nework progress bar boundaries
            int maximum = (int)agent.WiFi.RxRate/1000;
            pgsNetworkTraffic.Maximum = maximum;
            pgsNetworkTrafficUdp.Maximum = maximum;
            pgsNetworkTrafficTcp.Maximum = maximum;
            pgsNetworkTrafficRtp.Maximum = maximum;
            // set atmel progress bar boundaries
            pgsAtmelBandwidth.Maximum = agent.Arduino.Baudrate_0;
            pgsAtmelBandwidthIn.Maximum = agent.Arduino.Baudrate_0;
            pgsAtmelBandwidthOut.Maximum = agent.Arduino.Baudrate_0;
        }

        private void updateNetworkStatistics() {
            this.UIThreadInvoke(delegate {

                double bandwidth = (((double)NetworkStatistics.getInstance().TotalBytes)/1024.0/1024.0)*8.0;
                txtNetworkTraffic.Text = "Network Traffic: "+bandwidth.ToString("0.00")+" mbps";
                pgsNetworkTraffic.Value = Toolkit.clamp((int)bandwidth, pgsNetworkTraffic.Minimum, pgsNetworkTraffic.Maximum);

                double bandwidthUdp = (((double)NetworkStatistics.getInstance().TotalBytesUdp)/1024.0/1024.0)*8.0;
                txtNetworkTrafficUdp.Text = "Network Traffic (UDP): "+bandwidthUdp.ToString("0.00")+" mbps";
                pgsNetworkTrafficUdp.Value = Toolkit.clamp((int)bandwidthUdp, pgsNetworkTrafficUdp.Minimum, pgsNetworkTrafficUdp.Maximum);

                double bandwidthTcp = (((double)NetworkStatistics.getInstance().TotalBytesTcp)/1024.0/1024.0)*8.0;
                txtNetworkTrafficTcp.Text = "Network Traffic (TCP): "+bandwidthTcp.ToString("0.00")+" mbps";
                pgsNetworkTrafficTcp.Value = Toolkit.clamp((int)bandwidthTcp, pgsNetworkTrafficTcp.Minimum, pgsNetworkTrafficTcp.Maximum);

                double bandwidthRtp = (((double)NetworkStatistics.getInstance().TotalBytesRtp)/1024.0/1024.0)*8.0;
                txtNetworkTrafficRtp.Text = "Network Traffic (RTP): "+bandwidthRtp.ToString("0.00")+" mbps";
                pgsNetworkTrafficRtp.Value = Toolkit.clamp((int)bandwidthRtp, pgsNetworkTrafficRtp.Minimum, pgsNetworkTrafficRtp.Maximum);

            });
        }

        private void onRoundTripTimePackedReceived(RoundTripTime packet) {
            this.UIThreadInvoke(delegate {
                if(packet.Indicator) {
                    if(packet.Connectivity12 && packet.Connectivity13) {
                        txtAgentConnectivity.Image = Properties.Resources.on_24;
                        txtAtmelConnectivity.Image = Properties.Resources.on_24;
                    } else if(!packet.Connectivity12 && !packet.Connectivity13) {
                        txtAgentConnectivity.Image = Properties.Resources.off_24;
                        txtAtmelConnectivity.Image = Properties.Resources.off_24;
                        txtAtmelLoopIndicator.Image = Properties.Resources.off_24;
                        clearAllIndicators();
                    } else if(packet.Connectivity12 && !packet.Connectivity13) {
                        txtAgentConnectivity.Image = Properties.Resources.on_24;
                        txtAtmelConnectivity.Image = Properties.Resources.off_24;
                        txtAtmelLoopIndicator.Image = Properties.Resources.off_24;
                        clearAllIndicators();
                    } else if(!packet.Connectivity12 && packet.Connectivity13) {
                        txtAgentConnectivity.Image = Properties.Resources.off_24;
                        txtAtmelConnectivity.Image = Properties.Resources.on_24;
                    }
                } else {
                    if(packet.Partial) {
                        txtRoundTriptime12.Text = "Round Trip Time [Remote<>Agent]: "+packet.Rtt12+" ms";
                        pgsRoundTriptime12.Value = Toolkit.clamp(packet.Rtt12, pgsRoundTriptime12.Minimum, pgsRoundTriptime12.Maximum);
                    } else {
                        // set round trip indicators
                        txtRoundTriptime12.Text = "Round Trip Time [Remote<>Agent]: "+packet.Rtt12+" ms";
                        pgsRoundTriptime12.Value = Toolkit.clamp(packet.Rtt12, pgsRoundTriptime12.Minimum, pgsRoundTriptime12.Maximum);
                        txtRoundTriptime23.Text = "Round Trip Time [Agent<>Atmel]: "+packet.Rtt23+" ms";
                        pgsRoundTriptime23.Value = Toolkit.clamp(packet.Rtt23, pgsRoundTriptime23.Minimum, pgsRoundTriptime23.Maximum);
                        txtRoundTriptime13.Text = "Round Trip Time [Remote<>Agent<>Atmel]: "+packet.Rtt13+" ms";
                        pgsRoundTriptime13.Value = Toolkit.clamp(packet.Rtt13, pgsRoundTriptime13.Minimum, pgsRoundTriptime13.Maximum);

                        txtAtmelLoopTime.Text = "Average Loop Time [Atmel]: "+packet.LoopTime+" us";
                        pgsAtmelLoopTime.Value = Toolkit.clamp(packet.LoopTime, pgsAtmelLoopTime.Minimum, pgsAtmelLoopTime.Maximum);
                        txtAtmelRam.Text = "Used RAM [Atmel]: "+(8192-packet.FreeRam)+" kB";
                        pgsAtmelRam.Value = Toolkit.clamp(8192-packet.FreeRam, pgsAtmelRam.Minimum, pgsAtmelRam.Maximum);
                        txtAtmelBandwidthOut.Text = "Bandwidth Output COM [Atmel]: "+(packet.getOutputBandwidth())+" Baud";
                        pgsAtmelBandwidthOut.Value = Toolkit.clamp(packet.getOutputBandwidth(), pgsAtmelBandwidthOut.Minimum, pgsAtmelBandwidthOut.Maximum);
                        txtAtmelBandwidthIn.Text = "Bandwidth Input COM [Atmel]: "+(packet.getInputBandwidth())+" Baud";
                        pgsAtmelBandwidthIn.Value = Toolkit.clamp(packet.getInputBandwidth(), pgsAtmelBandwidthIn.Minimum, pgsAtmelBandwidthIn.Maximum);
                        txtAtmelBandwidth.Text = "Bandwidth COM [Atmel]: "+(packet.getTotalBandwidth())+" Baud";
                        pgsAtmelBandwidth.Value = Toolkit.clamp(packet.getTotalBandwidth(), pgsAtmelBandwidth.Minimum, pgsAtmelBandwidth.Maximum);
                        // set loop indicator light bulb
                        if(agent!=null) {
                            if(packet.LoopTime>=Globals.MAX_LOOP_TIME) {
                                txtAtmelLoopIndicator.Image = Properties.Resources.error_24;
                            } else {
                                txtAtmelLoopIndicator.Image = Properties.Resources.on_24;
                            }
                            if(packet.FreeRam<=2048) {
                                txtAtmelRamIndicator.Image = Properties.Resources.error_24;
                            } else {
                                txtAtmelRamIndicator.Image = Properties.Resources.on_24;
                            }
                            if(packet.getTotalBandwidth()>=(int)(agent.Arduino.Baudrate_0*0.65f)) {
                                txtAtmelBandwidthIndicator.Image = Properties.Resources.error_24;
                            } else {
                                txtAtmelBandwidthIndicator.Image = Properties.Resources.on_24;
                            }
                        }
                    }
                }
            });
        }

        private void clearAllIndicators() {

            txtRoundTriptime12.Text = "Round Trip Time [Remote<>Agent]: 0 ms";
            pgsRoundTriptime12.Value = pgsRoundTriptime12.Minimum;
            txtRoundTriptime23.Text = "Round Trip Time [Agent<>Atmel]: 0 ms";
            pgsRoundTriptime23.Value = pgsRoundTriptime23.Minimum;
            txtRoundTriptime13.Text = "Round Trip Time [Remote<>Agent<>Atmel]: 0 ms";
            pgsRoundTriptime13.Value = pgsRoundTriptime13.Minimum;

            txtAtmelLoopTime.Text = "Average Loop Time [Atmel]: 0 us";
            pgsAtmelLoopTime.Value = pgsAtmelLoopTime.Minimum;
            txtAtmelRam.Text = "Used RAM [Atmel]: 0 kB";
            pgsAtmelRam.Value = pgsAtmelRam.Minimum;

            txtAtmelBandwidth.Text = "Bandwidth COM [Atmel]: 0 Baud";
            pgsAtmelBandwidth.Value = pgsAtmelBandwidth.Minimum;
            txtAtmelBandwidthOut.Text = "Bandwidth Output COM [Atmel]: 0 Baud";
            pgsAtmelBandwidthOut.Value = pgsAtmelBandwidthOut.Minimum;
            txtAtmelBandwidthIn.Text = "Bandwidth Input COM [Atmel]: 0 Baud";
            pgsAtmelBandwidthIn.Value = pgsAtmelBandwidthIn.Minimum;

            txtAgentConnectivity.Image = Properties.Resources.off_24;
            txtAtmelConnectivity.Image = Properties.Resources.off_24;
            txtAtmelLoopIndicator.Image = Properties.Resources.off_24;
            txtAtmelRamIndicator.Image = Properties.Resources.off_24;
            txtAtmelBandwidthIndicator.Image = Properties.Resources.off_24;

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
        #endregion

    }

}
