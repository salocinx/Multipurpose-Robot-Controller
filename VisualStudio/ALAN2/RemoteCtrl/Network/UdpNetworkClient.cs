
#region Usings
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using CommonCtrl;
#endregion

namespace RemoteCtrl {

    public class UdpNetworkClient {

        #region Singleton
        private static volatile UdpNetworkClient instance;

        public static UdpNetworkClient getInstance() {
            if(instance==null) {
                instance = new UdpNetworkClient();
            }
            return instance;
        }
        #endregion

        #region Fields
        private Thread listenerThread;
        private Socket clientSocket;
        private EndPoint recvEndpoint;
        private byte[] buffer;
        private int available;
        private volatile bool running;
        #endregion

        #region Events
        public event OnBeaconSignalPacketReceived onBeaconSignalPacketReceived;
        #endregion

        #region Lifecycle
        private UdpNetworkClient() {
            this.running = true;
            this.buffer = new byte[Globals.BUFFER_SIZE_UDP];
            this.recvEndpoint = new IPEndPoint(Toolkit.getNetworkAdress(true), Globals.NETWORK_UDP_PORT);
            this.clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            this.clientSocket.SendBufferSize = Globals.BUFFER_SIZE_UDP;
            this.clientSocket.ReceiveBufferSize = Globals.BUFFER_SIZE_UDP;
            this.clientSocket.Bind(recvEndpoint);
        }

        public void launch() {
            this.listenerThread = new Thread(listen);
            this.listenerThread.Name = "Network Listener (UDP)";
            this.listenerThread.Start();
        }

        public void terminate() {
            // stop listener thread
            running = false;
            // close tcp client socket
            if(clientSocket!=null) {
                clientSocket.Close();
            }
        }
        #endregion

        #region Management
        public void listen() {
            try {
                while(running) {
                    if((available = clientSocket.ReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref recvEndpoint)) >= 0) {
                        Array.Copy(buffer, 4, buffer, 0, buffer.Length-4);
                        NetworkPacket packet = NetworkPacket.getPacket(buffer);
                        if(packet is BeaconSignal) {
                            BeaconSignal beaconSignal = (BeaconSignal)packet;
                            this.onBeaconSignalPacketReceived?.Invoke(beaconSignal);
                            NetworkStatistics.getInstance().TotalBytesUdpIn += buffer.Length;
                        } else {
                            #region Logbook
                            Logger.Log(Level.WARNING, "Unknown packet type received on UDP socket: #"+NetworkPacket.getPacket(buffer));
                            #endregion
                        }
                        #region Logbook
                        Logger.Log(Level.FINE, "Received packet on UDP socket: "+buffer.Length+" [b]", Debug.UDP_IN);
                        #endregion
                    }
                }
            } catch(SocketException ex) {
                #region Logbook
                Logger.Log(Level.WARNING, "Could not listen on UDP socket.", ex);
                #endregion
            } catch(ThreadAbortException ex) {
                // allows your thread to terminate gracefully
                if(ex!=null) Thread.ResetAbort();
            }
        }
        #endregion

    }

}
