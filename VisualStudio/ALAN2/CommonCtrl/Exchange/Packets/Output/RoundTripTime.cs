
#region Fields
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace CommonCtrl {

    [Serializable]
    public class RoundTripTime : NetworkPacket {

        /* 1: Remote Controller
         * 2: Agent Controller
         * 3: Arduino/Atmel */

        #region Fields
        private long startTime;             // start time on remote controller
        private int loopTime;               // time a loop on the Atmel takes in [us]
        private short freeRam;              // free ram available on the Atmel [kB]
        private int bytesSent;              // currently used bandwidth (out) [baud]
        private int bytesReceived;          // currently used bandwidth (in) [baud]
        private int rtt12;                  // round-trip-time between remote<->agent                   => set for partial requests, calculated for complete requests
        private int rtt23;                  // round-trip-time between agent<->arduino                  => calculated on agent when packet is received back from arduino
        private int rtt13;                  // round-trip-time between remote<->agent<->arduino         => calculated on remote when packet is received back from agent (and previously arduino)
        private bool partial;               // partial RTT measurement agent<->arduino or full RTT measurement remote<->agent<->arduino

        [NonSerialized]
        private bool indicator;             // does the packet reflect a possible timeout ?
        [NonSerialized]
        private bool connectivity12;        // connectivity indicator remote<->agent
        [NonSerialized]
        private bool connectivity13;        // connectivity indicator remote<->agent<->arduino
        #endregion

        #region Lifecycle
        public RoundTripTime(ushort componentId) : base(componentId) {
            // nothing to do yet ...
        }
        #endregion

        #region Properties
        public long StartTime {
            get { return startTime; }
            set { startTime = value; }
        }

        public int LoopTime {
            get { return loopTime; }
            set { loopTime = value; }
        }

        public short FreeRam {
            get { return freeRam; }
            set { freeRam = value; }
        }

        public int BytesSent {
            get { return bytesSent; }
            set { bytesSent = value; }
        }

        public int BytesReceived {
            get { return bytesReceived; }
            set { bytesReceived = value; }
        }

        public int Rtt12 {
            get {
                if(partial) {
                    return rtt12;
                } else {
                    return rtt13-rtt23;
                }
            }
            set { rtt12 = value; }
        }

        public int Rtt23 {
            get { return rtt23; }
            set { rtt23 = value; }
        }

        public int Rtt13 {
            get { return rtt13; }
            set { rtt13 = value; }
        }

        public bool Partial {
            get { return partial; }
            set { partial = value; }
        }

        public bool Indicator {
            get { return indicator; }
            set { indicator = value; }
        }

        public bool Connectivity12 {
            get { return connectivity12; }
            set { connectivity12 = value; }
        }

        public bool Connectivity13 {
            get { return connectivity13; }
            set { connectivity13 = value; }
        }
        #endregion

        #region Functions
        public int getOutputBandwidth() {
            return bytesSent*10;
        }

        public int getInputBandwidth() {
            return bytesReceived*10;
        }

        public int getTotalBandwidth() {
            return (bytesReceived+bytesSent)*10;
        }
        #endregion

    }

}
