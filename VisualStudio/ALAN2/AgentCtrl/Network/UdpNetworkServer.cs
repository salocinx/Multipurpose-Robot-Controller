
#region Usings
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using CommonCtrl;
#endregion

namespace AgentCtrl {

    [Serializable]
    public class UdpNetworkServer {

        #region Fields
        private bool launched;
        private int port;
        private short beaconInterval;
        private Socket serverSocket;
        private EndPoint sendEndpoint;
        private UdpBeaconTerminal udpBeaconTerminal;
        private static ushort curSeqNum = 0;
        private readonly object syncobj = new object();
        #endregion

        #region Lifecycle
        public UdpNetworkServer() {
            this.port = 19630;
            this.beaconInterval = 1000;
        }

        public void terminate() {
            #region Logbook
            Logger.Log(Level.INFO, "Terminating UDP network service @ "+Toolkit.getBroadcastAddress(false).ToString()+":"+port+" ...");
            #endregion
            // terminate beacon terminal
            if(udpBeaconTerminal!=null) {
                udpBeaconTerminal.terminate();
            }
            // terminate udp broadcaster
            if(serverSocket!=null) {
                serverSocket.Close();
            }
            // don't call anything here,
            // it might not be executed
        }
        #endregion

        #region Properties
        public bool Launched {
            get { return launched; }
            set { launched = value; }
        }

        public int Port {
            get { return port; }
            set { this.port = value; }
        }

        public short BeaconInterval {
            get { return beaconInterval; }
            set { this.beaconInterval = value; }
        }
        #endregion

        #region Management
        public void launch() {
            // initialize parameters
            this.sendEndpoint = new IPEndPoint(Toolkit.getBroadcastAddress(false), port);
            this.serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            this.serverSocket.SendBufferSize = Globals.BUFFER_SIZE_UDP;
            this.serverSocket.ReceiveBufferSize = Globals.BUFFER_SIZE_UDP;
            #region Wait for Network Connectivity
            while(!Toolkit.isNetworkAvailable(false)) {
                #region Logbook
                Logger.Log(Level.WARNING, "Currently no network connectivity, trying again in 2.5 seconds.");
                #endregion
                Thread.Sleep(2500);
            }
            #endregion
            #region Logbook
            Logger.Log(Level.INFO, " - Start UDP network service @ "+Toolkit.getBroadcastAddress(false).ToString()+":"+port+" ...");
            #endregion
            // bind socket and start listening
            this.serverSocket.EnableBroadcast = true;
            // start sending beacon signals
            this.udpBeaconTerminal = new UdpBeaconTerminal();
            // server is up and running
            this.launched = true;
        }
        #endregion

        #region Handle Output
        public void broadcast(byte[] bytes) {
            if(Program.Launched) {
                lock(syncobj) {
                    try {
                        if(serverSocket!=null) {
                            serverSocket.SendTo(bytes, sendEndpoint);
                            #region Logbook
                            Logger.Log(Level.FINE, "Broadcasted "+bytes.Length+" [b] through UDP socket.", Debug.UDP_OUT);
                            #endregion
                        }
                    } catch(ObjectDisposedException) {
                        // nothing to do here, just wait for the program to exit ...
                    } catch(SocketException ex) {
                        #region Logbook
                        Logger.Log(Level.WARNING, "Could not broadcast data through UDP socket.", ex);
                        #endregion
                    } catch(Exception ex) {
                        #region Logbook
                        Logger.Log(Level.ERROR, "Could not broadcast data through UDP socket.", ex);
                        #endregion
                    }
                }
            }
        }

        public void broadcast(NetworkPacket packet) {
            if(Program.Launched) {
                try {
                    using(MemoryStream ms = new MemoryStream()) {
                        packet.SystemId = Program.Controller.Identity.Id;
                        packet.SequenceNumber = curSeqNum;
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(ms, packet);
                        byte[] content = ms.ToArray();
                        byte[] payload = new byte[content.Length+4];
                        // prefix with packet length
                        Array.Copy(BitConverter.GetBytes(content.Length), 0, payload, 0, 4);
                        // append payload after length header
                        Array.Copy(content, 0, payload, 4, content.Length);
                        // distribute packet
                        this.broadcast(payload);
                        #region Update Sequence Number
                        if(curSeqNum<ushort.MaxValue) {
                            curSeqNum++;
                        } else {
                            curSeqNum=0;
                        }
                        #endregion
                    }
                } catch(SocketException ex) {
                    #region Logbook
                    Logger.Log(Level.ERROR, "Could not broadcast network packet through UDP socket.", ex);
                    #endregion
                } catch(Exception ex) {
                    #region Logbook
                    Logger.Log(Level.ERROR, "Could not broadcast network packet through UDP socket.", ex);
                    #endregion
                }
            }
        }
        #endregion

    }

    #region UDP Beacon Terminal
    public class UdpBeaconTerminal {

        #region Fields
        private bool running = true;
        private Thread beaconThread;
        #endregion

        #region Lifecycle
        public UdpBeaconTerminal() {
            this.beaconThread = new Thread(sendBeaconSignal);
            this.beaconThread.Name = "Beacon Signal Thread (UDP)";
            this.beaconThread.Start();
        }

        public void terminate() {
            // nothing to do yet ...
        }
        #endregion

        #region Sending Beacon Signal
        private void sendBeaconSignal() {
            while(running) {
                if(Program.Launched) {
                    try {
                        BeaconSignal packet = new BeaconSignal(0);
                        packet.Name = Program.Controller.Identity.Name;
                        packet.Address = Toolkit.getNetworkAdress(false).ToString();
                        packet.Revision = Program.Controller.Identity.Revision;
                        Program.Controller.UdpNetworkServer.broadcast(packet);
                        Thread.Sleep(Program.Controller.UdpNetworkServer.BeaconInterval);
                    } catch(ThreadAbortException ex) {
                        // allows your thread to terminate gracefully
                        if(ex!=null) Thread.ResetAbort();
                    } catch(Exception ex) {
                        #region Logbook
                        Logger.Log(Level.ERROR, "Could not send beacon signal through UDP socket.", ex);
                        #endregion
                    }
                } else {
                    Thread.Sleep(64);
                }
            }
        }
        #endregion

    }
    #endregion

}
 