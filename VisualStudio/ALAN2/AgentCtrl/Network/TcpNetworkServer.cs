
#region Usings
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using CommonCtrl;
#endregion

namespace AgentCtrl {

    #region Tcp Network Server
    [Serializable]
    public class TcpNetworkServer {

        #region Fields
        private bool running = true;
        private bool launched = false;
        private int port;
        private byte[] buffer;
        private Socket serverSocket;
        private Thread acceptThread;
        private IPEndPoint localEndpoint;
        private List<TcpNetworkClient> tcpNetworkClients;
        private TcpNetworkServices tcpNetworkServices;
        private static ushort curSeqNum = 0;
        private readonly object syncobj = new object();
        #endregion

        #region Lifecycle
        public TcpNetworkServer() {
            this.port = 19650;
        }

        public void launch() {
            #region Logbook
            Logger.Log(Level.INFO, " - Start TCP network service @ "+Toolkit.getNetworkAdress(false)+":"+port+" ...");
            #endregion
            // initialize parameters
            this.buffer = new byte[Globals.BUFFER_SIZE_TCP];
            this.tcpNetworkClients = new List<TcpNetworkClient>();
            this.localEndpoint = new IPEndPoint(Toolkit.getNetworkAdress(false), port);
            this.serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // bind server socket to local endpoint
            serverSocket.Bind(localEndpoint);
            serverSocket.Listen(10);
            // start listening for client connections
            acceptThread = new Thread(acceptClientConnections);
            acceptThread.Name = "Network Acceptor Thread (TCP)";
            acceptThread.Start();
            // start periodic network services
            tcpNetworkServices = new TcpNetworkServices();
            tcpNetworkServices.launch();
        }

        public void terminate() {

            /* When using a connection-oriented Socket, always call the Shutdown method before closing the Socket.
             * This ensures that all data is sent and received on the connected socket before it is closed.
             * Call the Close method to free all managed and unmanaged resources associated with the Socket.
             * Do not attempt to reuse the Socket after closing.*/

            #region Logbook
            Logger.Log(Level.INFO, "Terminating TCP network service @ "+Toolkit.getNetworkAdress(false).ToString()+":"+port+" ...");
            #endregion

            // stop listener thread
            running = false;

            // terminate periodic network services
            if(tcpNetworkServices != null) {
                tcpNetworkServices.terminate();
            }

            // terminate all active client connections
            if(tcpNetworkClients != null) {
                foreach(TcpNetworkClient tcpNetworkClient in tcpNetworkClients) {
                    tcpNetworkClient.terminate();
                }
            }

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
        #endregion

        #region Functions
        public void removeTcpNetworkClient(TcpNetworkClient client) {
            if(tcpNetworkClients != null) {
                try {
                    tcpNetworkClients.Remove(client);
                    #region Logbook
                    Logger.Log(Level.INFO, "Client "+client.ClientSocket.RemoteEndPoint.ToString()+" disconnected from TCP server.");
                    #endregion
                } catch(ObjectDisposedException) {
                    // ignore ...
                } catch(ArgumentOutOfRangeException) {
                    // ignore ...
                }
            }
        }

        public static ushort getSequenceNumber() {
            #region Update Sequence Number
            if(curSeqNum<ushort.MaxValue) {
                curSeqNum++;
            } else {
                curSeqNum=0;
            }
            #endregion
            return curSeqNum;
        }
        #endregion

        #region Connection
        private void acceptClientConnections() {
            try {
                while(running) {
                    // wait for incoming connection (blocked)
                    Socket clientSocket = serverSocket.Accept();
                    // disable nagle algorithm
                    clientSocket.NoDelay = true;
                    // define rx/tx buffer sizes
                    clientSocket.SendBufferSize = Globals.BUFFER_SIZE_TCP;
                    clientSocket.ReceiveBufferSize = Globals.BUFFER_SIZE_TCP;
                    // keep reference of active client connections
                    tcpNetworkClients.Add(new TcpNetworkClient(this, clientSocket));
                    // log successfull connection establishment
                    #region Logbook
                    Logger.Log(Level.INFO, "Client "+clientSocket.RemoteEndPoint.ToString()+" connected to TCP server.");
                    #endregion
                    // send initial system info packet
                    SystemStatus packet = new SystemStatus(0);
                    packet.WiFi = Program.Controller.WiFi;
                    packet.System = Program.Controller.System;
                    packet.Arduino = Program.Controller.Arduino;
                    packet.Cameras = Program.Controller.Cameras;
                    packet.Components = Program.Controller.Components;
                    packet.ActionLibrary = Program.ActionLibrary;
                    packet.AtmelConsole = Program.Controller.AtmelConsole;
                    packet.AgentConsole = Program.Controller.AgentConsole;
                    this.broadcast(packet);
                    // server is up and running
                    this.launched = true;
                }
            } catch(Exception ex) {
                #region Logbook
                Logger.Log(Level.ERROR, "Client connection establishment to TCP server failed.", ex);
                #endregion
            }
        }
        #endregion

        #region Broadcasting
        public void broadcast(NetworkPacket packet) {
            if(Program.Launched) {
                this.broadcast(packet, TcpNetworkServer.getSequenceNumber());
            }
        }

        public void broadcast(NetworkPacket packet, ushort sequenceNumber) {
            if(Program.Launched) {
                try {
                    // set sequence number once for a packet independent of the number of receivers
                    packet.SequenceNumber = sequenceNumber;
                    // send the network packet to all remote controllers
                    for(int i=tcpNetworkClients.Count-1; i>=0; i--) {
                        try {
                            tcpNetworkClients[i].send(packet);
                            #region Logbook
                            Logger.Log(Level.FINE, "Broadcast "+packet.GetType().ToString()+" through TCP socket.", Debug.TCP_OUT);
                            #endregion
                        } catch(SocketException) {
                            #region Remove Tcp Network Client
                            try {
                                this.removeTcpNetworkClient(tcpNetworkClients[i]);
                            } catch(ArgumentOutOfRangeException) { }
                            #endregion
                        } catch(ObjectDisposedException) {
                            // nothing to do ...
                        }
                    }
                } catch(Exception ex) {
                    #region Logbook
                    Logger.Log(Level.ERROR, "Could not send packet through TCP socket.", ex);
                    #endregion
                }
            }
        }
        #endregion

    }
    #endregion

    #region Tcp Network Client
    public class TcpNetworkClient {

        #region Fields
        private bool running = true;
        private Socket clientSocket;
        private Thread listenerThread;
        private TcpNetworkServer parent;
        private readonly object syncobj = new object();
        #endregion

        #region Lifecycle
        public TcpNetworkClient(TcpNetworkServer parent, Socket clientSocket) {
            this.parent = parent;
            this.clientSocket = clientSocket;
            // start receiver thread
            listenerThread = new Thread(listen);
            listenerThread.Name = "Network Listener (TCP)";
            listenerThread.Start();
        }

        public void terminate() {

            /* When using a connection-oriented Socket, always call the Shutdown method before closing the Socket.
             * This ensures that all data is sent and received on the connected socket before it is closed.
             * Call the Close method to free all managed and unmanaged resources associated with the Socket.
             * Do not attempt to reuse the Socket after closing.*/

            // stop listener thread
            running = false;

            // close tcp client socket
            if(clientSocket != null) {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }

        }
        #endregion

        #region Properties
        public Socket ClientSocket {
            get { return clientSocket; }
        }
        #endregion

        #region Handle Output
        public void send(NetworkPacket packet) {
            if(Program.Launched) {
                using(MemoryStream ms = new MemoryStream()) {
                    packet.SystemId = Program.Controller.Identity.Id;
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(ms, packet);
                    byte[] content = ms.ToArray();
                    byte[] payload = new byte[content.Length+4];
                    // prefix with packet length
                    Array.Copy(BitConverter.GetBytes(content.Length), 0, payload, 0, 4);
                    // append payload after length header
                    Array.Copy(content, 0, payload, 4, content.Length);
                    // distribute packet
                    this.send(payload);
                }
            }
        }

        private void send(byte[] data) {
            lock(syncobj) {
                clientSocket.Send(data, 0, data.Length, 0);
                #region Logbook
                Logger.Log(Level.FINE, "Sending "+data.Length+" [b] of data through TCP socket to "+clientSocket.RemoteEndPoint.ToString()+".", Debug.TCP_OUT);
                #endregion
            }
        }
        #endregion

        #region Handle Input

        private void listen() {
            try {
                while(running) {
                    if(clientSocket.Available>=4) {
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
                            Program.Controller.networkPacketReceived(packet);
                        }
                        #region Logbook
                        Logger.Log(Level.INFO, "Received "+payload.Length+" [b] of data from TCP socket.", Debug.TCP_IN);
                        #endregion
                    }
                }
            } catch(SocketException) {
                parent.removeTcpNetworkClient(this);
            } catch(ObjectDisposedException) {
                parent.removeTcpNetworkClient(this);
            } catch(ThreadAbortException ex) {
                // allows your thread to terminate gracefully
                if(ex!=null) Thread.ResetAbort();
            }
        }

        #region Depreciated
        // INFO: https://stackoverflow.com/questions/44531259/why-i-get-a-serializationexception-with-binaryformatter/44555795#44555795
        /*private void listen() {
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
                            Program.Controller.networkPacketReceived(packet);
                        }
                        #region Logbook
                        Logger.Log(Level.INFO, "Received "+data.Length+" [b] of data from TCP socket.", Debug.TCP_IN);
                        #endregion
                    }
                }
            } catch(SocketException) {
                parent.removeTcpNetworkClient(this);
            } catch(ThreadAbortException ex) {
                // allows your thread to terminate gracefully
                if(ex!=null) Thread.ResetAbort();
            }
        }*/
        #endregion

        #endregion

    }
    #endregion

    #region Tcp Network Services
    public class TcpNetworkServices {

        #region Fields
        private bool running;
        private Thread networkStatusThread;
        #endregion

        #region Lifecycle
        public TcpNetworkServices() {
            this.running = true;
        }

        public void launch() {
            this.networkStatusThread = new Thread(sendNetworkStatus);
            this.networkStatusThread.Name = "Send Network Status Thread";
            this.networkStatusThread.Start();
        }

        public void terminate() {
            running = false;
        }
        #endregion

        #region Service
        private void sendNetworkStatus() {
            while(running) {
                Program.Controller.updateWiFiState();
                NetworkStatus networkStatus = new NetworkStatus(0);
                networkStatus.WiFi = Program.Controller.WiFi;
                Program.Controller.TcpNetworkServer.broadcast(networkStatus);
                Thread.Sleep(5000);
            }
        }
        #endregion

    }
    #endregion

}