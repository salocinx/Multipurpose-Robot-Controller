
#region Usings
using System;
using System.Timers;
using System.Collections.Generic;
using CommonCtrl;
#endregion

namespace RemoteCtrl {

    public class NetworkStatistics {

        #region Singleton
        private static volatile NetworkStatistics instance;

        public static NetworkStatistics getInstance() {
            if(instance==null) {
                instance = new NetworkStatistics();
            }
            return instance;
        }
        #endregion

        #region Fields

        private Timer timer;

        private int totalBytesUdpIn;
        private int totalBytesUdpOut;
        private int totalBytesTcpIn;
        private int totalBytesTcpOut;
        private int totalBytesRtpIn;
        private int totalBytesRtpOut;

        /*private volatile int totalBytesUdpIn;
        private volatile int totalBytesUdpOut;
        private volatile int totalBytesTcpIn;
        private volatile int totalBytesTcpOut;
        private volatile int totalBytesRtpIn;
        private volatile int totalBytesRtpOut;*/

        #endregion

        #region Events
        public event OnNetworkStatisticsUpdated onNetworkStatisticsUpdated;
        #endregion

        #region Lifecycle
        private NetworkStatistics() {
            timer = new Timer(1000.0);
            timer.Elapsed += update;
            timer.Start();
        }
        #endregion

        #region Properties
        public int TotalBytes {
            get {
                return TotalBytesUdp + TotalBytesTcp + TotalBytesRtp;
            }
        }

        public int TotalBytesPeak {
            get {
                return totalBytesUdpIn;
            }
        }

        public int TotalBytesUdp {
            get {
                return totalBytesUdpIn + totalBytesUdpOut;
            }
        }

        public int TotalBytesTcp {
            get {
                return totalBytesTcpIn + totalBytesTcpOut;
            }
        }

        public int TotalBytesRtp {
            get {
                return totalBytesRtpIn + totalBytesRtpOut;
            }
        }

        public int TotalBytesUdpIn {
            get { return totalBytesUdpIn; }
            set { totalBytesUdpIn = value; }
        }

        public int TotalBytesUdpOut {
            get { return totalBytesUdpOut; }
            set { totalBytesUdpOut = value; }
        }

        public int TotalBytesTcpIn {
            get { return totalBytesTcpIn; }
            set { totalBytesTcpIn = value; }
        }

        public int TotalBytesTcpOut {
            get { return totalBytesTcpOut; }
            set { totalBytesTcpOut = value; }
        }

        public int TotalBytesRtpIn {
            get { return totalBytesRtpIn; }
            set { totalBytesRtpIn = value; }
        }

        public int TotalBytesRtpOut {
            get { return totalBytesRtpOut; }
            set { totalBytesRtpOut = value; }
        }
        #endregion

        #region Functions
        private void update(object sender, ElapsedEventArgs evt) {
            // inform gui listeners
            onNetworkStatisticsUpdated?.Invoke();
            // update framerate and bandwidth of all camera components
            foreach(Agent agent in RemoteGui.getInstance().Agents) {
                if(agent.Initialized) {
                    if(agent.Components!=null) {
                        foreach(Component component in agent.Components) {
                            if(component is Camera) {
                                Camera camera = (Camera)component;
                                camera.updateStatistics();
                            }
                        }
                    }
                }
            }
            // reset byte counters for the different protocols
            this.totalBytesUdpIn = 0;
            this.totalBytesUdpOut = 0;
            this.totalBytesTcpIn = 0;
            this.totalBytesTcpOut = 0;
            this.totalBytesRtpIn = 0;
            this.totalBytesRtpOut = 0;
        }
        #endregion

    }

}
