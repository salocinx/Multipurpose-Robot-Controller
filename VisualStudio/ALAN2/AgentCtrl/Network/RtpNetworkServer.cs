
#region Usings
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using Emgu.CV;
using CommonCtrl;
#endregion

namespace AgentCtrl {

    [Serializable]
    public class RtpNetworkServer {

        #region Fields

        private bool running = true;
        private bool launched = false;
        private int port;
        private long compressionQuality;
        private string compressionEncoder;
        private byte[] buffer;
        private Thread acceptThread;
        private IPEndPoint localEndpoint;
        private Socket serverSocket;
        private List<Socket> clientSockets;
        private static ushort curSeqNum = 0;
        private readonly object syncobj = new object();

        // image capturing devices
        private List<Camera> cameras = new List<Camera>();

        #endregion

        #region Lifecycle
        public RtpNetworkServer() {
            this.port = 19680;
            this.compressionQuality = 85L;
            this.compressionEncoder = "jpg";
        }

        public void launch() {
            #region Logbook
            Logger.Log(Level.INFO, " - Start RTP network service @ "+Toolkit.getNetworkAdress(false)+":"+port+" ...");
            #endregion
            // initialize parameters
            this.clientSockets = new List<Socket>();
            this.buffer = new byte[Globals.BUFFER_SIZE_RTP];
            this.localEndpoint = new IPEndPoint(Toolkit.getNetworkAdress(false), port);
            this.serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // bind server socket to local endpoint
            serverSocket.Bind(localEndpoint);
            serverSocket.Listen(10);
            // start listening for client connections
            acceptThread = new Thread(acceptClientConnections);
            acceptThread.Name = "Network Acceptor Thread (RTP)";
            acceptThread.Start();
            // server is up and running
            this.launched = true;
        }

        public void terminate() {

            /* When using a connection-oriented Socket, always call the Shutdown method before closing the Socket.
             * This ensures that all data is sent and received on the connected socket before it is closed.
             * Call the Close method to free all managed and unmanaged resources associated with the Socket.
             * Do not attempt to reuse the Socket after closing.*/

            #region Logbook
            Logger.Log(Level.INFO, "Terminating RTP network service @ "+Toolkit.getNetworkAdress(false).ToString()+":"+port+" ...");
            #endregion

            // stop listener thread
            running = false;

            // remove all attached camera components
            detachAllCameras();

            // close all tcp client sockets
            if(clientSockets!=null) {
                foreach(Socket clientSocket in clientSockets) {
                    clientSocket.Close();
                }
                clientSockets.Clear();
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

        public long CompressionQuality {
            get { return compressionQuality; }
            set { this.compressionQuality = value; }
        }

        public string CompressionEncoder {
            get { return compressionEncoder; }
            set { this.compressionEncoder = value; }
        }
        #endregion

        #region Managment
        public void attachCamera(Camera camera) {
            camera.onCameraImageCaptured += distribute;
            cameras.Add(camera);
        }

        public void detachCamera(Camera camera) {
            camera.onCameraImageCaptured -= distribute;
            cameras.Remove(camera);
        }

        public void detachAllCameras() {
            foreach(Camera camera in cameras) {
                camera.onCameraImageCaptured -= distribute;
            }
            cameras.Clear();
        }
        #endregion

        #region Network
        private void acceptClientConnections() {
            try {
                while(running) {
                    // wait for incoming connection (blocked)
                    Socket clientSocket = serverSocket.Accept();
                    // disable nagle algorithm
                    clientSocket.NoDelay = true;
                    // define rx/tx buffer sizes
                    clientSocket.SendBufferSize = Globals.BUFFER_SIZE_RTP;
                    clientSocket.ReceiveBufferSize = Globals.BUFFER_SIZE_RTP;
                    // keep reference of active client connections
                    clientSockets.Add(clientSocket);
                    // log successfull connection establishment
                    #region Logbook
                    Logger.Log(Level.INFO, "Client "+clientSocket.RemoteEndPoint.ToString()+" connected to RTP server.");
                    #endregion
                }
            } catch(Exception ex) {
                #region Logbook
                Logger.Log(Level.ERROR, "Client connection establishment to RTP server failed.", ex);
                #endregion
            }
        }

        private void distribute(Camera camera, Mat frame) {
            if(clientSockets!=null) {
                if(clientSockets.Count > 0) {
                    if(camera.Streaming) {
                        // compress and encapsulate raw image with jpg algorithm
                        CameraImage packet = new CameraImage(camera.Id, frame, camera.CodecInfo, camera.EncoderParams);
                        packet.SystemId = Program.Controller.Identity.Id;
                        packet.SequenceNumber = curSeqNum;
                        byte[] content;
                        using(MemoryStream ms = new MemoryStream()) {
                            BinaryFormatter bf = new BinaryFormatter();
                            bf.Serialize(ms, packet);
                            content = ms.ToArray();
                        }
                        byte[] payload = new byte[content.Length+4];
                        // prefix with packet length
                        Array.Copy(BitConverter.GetBytes(content.Length), 0, payload, 0, 4);
                        // append payload after length header
                        Array.Copy(content, 0, payload, 4, content.Length);
                        // distribute to connected clients
                        this.distribute(payload);
                        #region Update Sequence Number
                        if(curSeqNum<ushort.MaxValue) {
                            curSeqNum++;
                        } else {
                            curSeqNum=0;
                        }
                        #endregion
                    }
                }
            }
        }

        private void distribute(byte[] bytes) {
            if(Program.Launched) {
                lock(syncobj) {
                    // distribute to connected clients
                    for(int i=clientSockets.Count-1; i>=0; i--) {
                        try {
                            clientSockets[i].Send(bytes, bytes.Length, SocketFlags.None);
                            #region Logbook
                            Logger.Log(Level.FINE, "Distributing video frame with "+bytes.Length+" [b] to client at "+clientSockets[i].RemoteEndPoint.ToString()+".", Debug.RTP_OUT);
                            #endregion
                        } catch(SocketException) {
                            #region Logbook
                            Logger.Log(Level.INFO, "Client "+clientSockets[i].RemoteEndPoint.ToString()+" disconnected from RTP server.");
                            #endregion
                            clientSockets.RemoveAt(i);
                        }
                    }
                }
            }
        }
        #endregion

    }

}
