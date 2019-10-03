
#region Usings
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using CommonCtrl;
#endregion

namespace RemoteCtrl {

    public class RtpNetworkClient {

        #region Fields
        private bool running = true;
        private Agent agent;
        private Thread receiveThread;
        private Socket clientSocket;
        private IPEndPoint remoteEndpoint;
        #endregion

        #region Events
        public event OnNetworkPacketReceived onNetworkPacketReceived;
        public event OnNetworkClientDisconnected onNetworkClientDisconnected;
        #endregion

        #region Lifecycle
        public RtpNetworkClient(Agent agent) {
            this.agent = agent;
            // initialize the network server socket
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // disable nagle algorithm
            clientSocket.NoDelay = true;
            // define rx/tx buffer sizes
            clientSocket.SendBufferSize = Globals.BUFFER_SIZE_RTP;
            clientSocket.ReceiveBufferSize = Globals.BUFFER_SIZE_RTP;
        }
        #endregion

        #region Connection
        public void connect(IPAddress address, int port) {
            try {
                // construct a remote network endpoint
                remoteEndpoint = new IPEndPoint(address, port);
                #region Logbook
                Logger.Log(Level.INFO, "Start connecting to RTP server at "+remoteEndpoint.ToString()+" ...");
                #endregion
                // bind client socket to remote endpoint
                clientSocket.Connect(remoteEndpoint);
                // start receiver thread
                receiveThread = new Thread(receive);
                receiveThread.Name = "Network Listener (RTP)";
                receiveThread.Start();
            } catch(Exception ex) {
                #region Logbook
                Logger.Log(Level.ERROR, "Could not connect to RTP server.", ex);
                #endregion
            }
        }

        public void disconnect() {
            try {
                // stop listener thread
                running = false;
                // close client socket
                if(clientSocket!=null) {
                    if(clientSocket.Connected) {
                        clientSocket.Shutdown(SocketShutdown.Both);
                        clientSocket.Close();
                    }
                }
            } catch(SocketException ex) {
                #region Logbook
                Logger.Log(Level.WARNING, "Client connection to RTP server not shut down correctly.", ex);
                #endregion
            } finally {
                clientSocket = null;
            }
        }
        #endregion

        #region Network
        private void receive() {
            try {
                while(running) {
                    int offset = 0;
                    byte[] header = new byte[4];
                    // receive header bytes from tcp stream
                    while(offset < header.Length) {
                        offset += clientSocket.Receive(header, offset, header.Length - offset, SocketFlags.None);
                    }
                    int bytesToRead = BitConverter.ToInt32(header, 0);
                    // receive payload bytes from tcp stream
                    offset = 0;
                    byte[] payload = new byte[bytesToRead];
                    while(offset < payload.Length) {
                        offset += clientSocket.Receive(payload, offset, payload.Length - offset, SocketFlags.None);
                    }
                    // deserialize byte array to network packet
                    NetworkPacket packet = null;
                    using(MemoryStream ms = new MemoryStream(payload)) {
                        BinaryFormatter bf = new BinaryFormatter();
                        packet = (NetworkPacket)bf.Deserialize(ms);
                    }
                    // deliver network packet to listeners
                    if(packet!=null) {
                        this.onNetworkPacketReceived?.Invoke(packet);
                    }
                    // update network statistics 
                    NetworkStatistics.getInstance().TotalBytesRtpIn += payload.Length;
                }
            } catch(SocketException ex) {
                #region Logbook
                Logger.Log(Level.WARNING, "Could not receive data from RTP server: "+ex.Message);
                #endregion
                onNetworkClientDisconnected?.Invoke(agent.SystemId);
            } catch(ObjectDisposedException ex) {
                #region Logbook
                Logger.Log(Level.WARNING, "Could not receive data from RTP server: "+ex.Message);
                #endregion
            } catch(ThreadAbortException ex) {
                // allows your thread to terminate gracefully
                if(ex!=null) Thread.ResetAbort();
            }
        }

        #region Depreciated
        // INFO: https://stackoverflow.com/questions/44531259/why-i-get-a-serializationexception-with-binaryformatter/44555795#44555795
        /*private void receive() {
            try {
                while(running) {
                    if(clientSocket.Available>=4) {
                        // receive header bytes from tcp stream
                        byte[] header = new byte[4];
                        clientSocket.Receive(header, 4, SocketFlags.None);
                        int bytesToRead = BitConverter.ToInt32(header, 0);
                        // receive body bytes from tcp stream
                        int offset = 0;
                        byte[] data = new byte[bytesToRead];
                        while(bytesToRead > 0) {
                            int bytesReceived = clientSocket.Receive(data, offset, bytesToRead, SocketFlags.None);
                            offset += bytesReceived;
                            bytesToRead -= bytesReceived;
                        }
                        // deserialize byte array to network packet
                        NetworkPacket packet = null;
                        using(MemoryStream ms = new MemoryStream(data)) {
                            BinaryFormatter bf = new BinaryFormatter();
                            packet = (NetworkPacket)bf.Deserialize(ms);
                        }
                        // deliver network packet to listeners
                        if(packet!=null) {
                            this.onNetworkPacketReceived?.Invoke(packet);
                        }
                        // update network statistics
                        NetworkStatistics.getInstance().TotalBytesRtpIn += data.Length;
                    }
                }
            } catch(SocketException ex) {
                #region Logbook
                Logger.Log(Level.WARNING, "Could not receive data from RTP server: "+ex.Message);
                #endregion
                onNetworkClientDisconnected?.Invoke(agent.SystemId);
            } catch(ObjectDisposedException ex) {
                #region Logbook
                Logger.Log(Level.WARNING, "Could not receive data from RTP server: "+ex.Message);
                #endregion
            } catch(ThreadAbortException ex) {
                // allows your thread to terminate gracefully
                if(ex!=null) Thread.ResetAbort();
            }
        }*/
        #endregion

        #endregion

    }

}