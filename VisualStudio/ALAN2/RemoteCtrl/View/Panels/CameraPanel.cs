
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

    public partial class CameraPanel : UserControl, iDetachableView {

        #region Fields
        private Agent agent;
        private Camera camera;
        private CameraMono cameraMono;
        private CameraStereo cameraStereo;
        private CameraWindow window;
        private bool isKeyDown;
        private bool isMouseDown;
        private bool initialized;
        #endregion

        #region Defaults
        private static Image<Bgr, byte> defaultImage;
        #endregion

        #region Lifecycle
        public CameraPanel(Agent agent, Camera camera) {
            this.agent = agent;
            this.camera = camera;
            #region Initialize Default Image
            if(defaultImage==null) {
                defaultImage = new Image<Bgr, byte>(new Bitmap(Properties.Resources.no_cam_connected));
            }
            #endregion
            InitializeComponent();
            initializeGui();
            agent.onCameraImagePacketReceived += onCameraImagePacketReceived;
            this.initialized = true;
        }

        private void initializeGui() {
            this.UIThreadInvoke(delegate {
                try {
                    Camera component = agent.findComponent<Camera>(camera.Id);
                    #region Resolutions Combobox
                    // find hardware camera for available resolutions
                    HwCamera hwCamera;
                    if(component is CameraMono) {
                        cameraMono = (CameraMono)component;
                        hwCamera = agent.findHardwareCamera(cameraMono.CameraIndex);
                    } else {
                        cameraStereo = (CameraStereo)component;
                        hwCamera = agent.findHardwareCamera(cameraStereo.LeftCameraIndex);
                    }
                    // fill combobox with found camera resolutions
                    Resolution selection = null;
                    cbxResolutions.Items.Clear();
                    foreach(Resolution resolution in hwCamera.Resolutions) {
                        if(resolution==component.Resolution) {
                            selection = resolution;
                        }
                        cbxResolutions.Items.Add(resolution);
                    }
                    if(selection==null) {
                        if(cbxResolutions.Items.Count>0)
                            cbxResolutions.SelectedIndex = 0;
                    } else {
                        cbxResolutions.SelectedItem = selection;
                    }
                    #endregion
                    boxCapturing.Checked = component.Capturing;
                    boxStreaming.Checked = component.Streaming;
                    boxColoured.Checked = component.Colour;
                    if(component is CameraStereo)
                        boxSwapped.Checked = cameraStereo.Swapped;
                    boxSwapped.Visible = component is CameraStereo;
                    txtQuality.Text = "Encoding Quality: "+component.Quality+"%";
                    trkQuality.Value = component.Quality;
                    pgsNetworkTraffic.Maximum = (int)agent.WiFi.RxRate/1000;
                } catch(ComponentNotFoundException ex) {
                    setComponentsEnabled(false);
                    #region Logbook
                    Logger.Log(Level.WARNING, ex);
                    #endregion
                } catch(HardwareCameraNotFoundException ex) {
                    setComponentsEnabled(false);
                    #region Logbook
                    Logger.Log(Level.WARNING, ex);
                    #endregion
                }
            });
        }
        #endregion

        #region Functions
        public void detachView() {
            if(window==null) {
                window = new CameraWindow(this);
                window.Text = Parent.Text;
            }
            // disable image on main window
            imgNetworkStreamImage.Image = defaultImage;
            // present detached view
            window.Show();
        }

        private void setComponentsEnabled(bool enabled) {
            grpStreamProperties.Enabled = enabled;
            grpVideoControlPanel.Enabled = enabled;
            grpStreamPerformance.Enabled = enabled;
            if(!enabled) {
                imgNetworkStreamImage.Image = defaultImage;
            }
        }

        private void sendComponentChanged() {
            if(camera is CameraMono) {
                UpdateComponent update = new UpdateComponent(camera.Id);
                update.Component = cameraMono;
                agent.TcpNetworkClient.send(update);
            } else {
                UpdateComponent update = new UpdateComponent(camera.Id);
                update.Component = cameraStereo;
                agent.TcpNetworkClient.send(update);
            }
        }
        #endregion

        #region Event-Hanlding (Network)
        public void onCameraImagePacketReceived(CameraImage packet) {
            if(packet.ComponentId == camera.Id) {
                this.UIThread(delegate {
                    try {
                        Image<Bgr, byte> image = CameraImage.decompress(packet);
                        #region Display Received Image
                        if(window==null) {
                            imgNetworkStreamImage.Image = image;
                        } else {
                            if(window.Visible) {
                                window.updateImage(image, packet.ImageWidth, packet.ImageHeight);
                            } else {
                                imgNetworkStreamImage.Image = image;
                            }
                        }
                        #endregion
                        txtResolution.Text = "Resolution: "+packet.ImageWidth+" x "+packet.ImageHeight;
                        txtColorDepth.Text = "Color Depth: "+((DepthType)packet.ImageDepth).ToString().Substring(2);
                        txtImageSize.Text = "Image Size: "+(packet.CompressedImageSize/1024)+" kb";
                        txtFramerate.Text = "Framerate: "+camera.CurrentFramerate+" fps";
                        pgsFramerate.Value = Toolkit.clamp(camera.CurrentFramerate, pgsFramerate.Minimum, pgsFramerate.Maximum);
                        txtCompressionTime.Text = "Compression Time: "+packet.CompressionTime+" ms";
                        pgsCompressionTime.Value = Toolkit.clamp(packet.CompressionTime, pgsCompressionTime.Minimum, pgsCompressionTime.Maximum);
                        txtCompressionRate.Text = "Compression Ratio: "+(100-packet.CompressionRatio)+" %";
                        pgsCompressionRate.Value = Toolkit.clamp((100-packet.CompressionRatio), pgsCompressionRate.Minimum, pgsCompressionRate.Maximum);
                        double bandwidth = (((double)camera.CurrentBandwidth)/1024.0/1024.0)*8.0;
                        txtNetworkTraffic.Text = "Network Traffic: "+bandwidth.ToString("0.00")+" mbps";
                        pgsNetworkTraffic.Value = Toolkit.clamp((int)bandwidth, pgsNetworkTraffic.Minimum, pgsNetworkTraffic.Maximum);
                        if(!boxCapturing.Checked || !boxStreaming.Checked) txtImageSize.Text = "Image Size: 0 kB";
                    } catch(ObjectDisposedException) {
                        #region Logbook
                        Logger.Log(Level.WARNING, "Could not set image box with network streaming image, since box was already disposed.");
                        #endregion
                    } catch(Exception ex) {
                        #region Logbook
                        Logger.Log(Level.ERROR, ex);
                        #endregion
                    }
                });
            }
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

        private void cbxResolutions_SelectedValueChanged(object sender, EventArgs evt) {
            if(initialized) {
                camera.Resolution = (Resolution)cbxResolutions.SelectedItem;
                sendComponentChanged();
            }
        }

        private void boxCapturing_CheckedChanged(object sender, EventArgs evt) {
            if(initialized) {
                if(!boxCapturing.Checked) txtImageSize.Text = "Image Size: 0 kB";
                camera.Capturing = boxCapturing.Checked;
                sendComponentChanged();
            }
        }

        private void boxStreaming_CheckedChanged(object sender, EventArgs evt) {
            if(initialized) {
                if(!boxStreaming.Checked) txtImageSize.Text = "Image Size: 0 kB";
                camera.Streaming = boxStreaming.Checked;
                sendComponentChanged();
            }
        }

        private void boxChannelsSwapped_CheckedChanged(object sender, EventArgs e) {
            if(initialized) {
                if(camera is CameraStereo) {
                    cameraStereo.Swapped = boxSwapped.Checked;
                    sendComponentChanged();
                }
            }
        }

        private void boxColoured_CheckedChanged(object sender, EventArgs evt) {
            if(initialized) {
                camera.Colour = boxColoured.Checked;
                sendComponentChanged();
            }
        }

        private void trkQuality_ValueChanged(object sender, EventArgs evt) {
            if(initialized) {
                txtQuality.Text = "Encoding Quality: "+trkQuality.Value+"%";
            }
        }

        private void trkQuality_MouseDown(object sender, MouseEventArgs e) {
            isMouseDown = true;
        }

        private void trkQuality_MouseUp(object sender, MouseEventArgs e) {
            if(initialized) {
                if(camera.Quality != trkQuality.Value) {
                    camera.Quality = trkQuality.Value;
                    sendComponentChanged();
                }
            }
            isMouseDown = false;
        }

        private void trkQuality_KeyDown(object sender, KeyEventArgs e) {
            isKeyDown = true;
        }

        private void trkQuality_KeyUp(object sender, KeyEventArgs e) {
            if(initialized) {
                if(camera.Quality != trkQuality.Value) {
                    camera.Quality = trkQuality.Value;
                    sendComponentChanged();
                }
            }
            isKeyDown = false;
        }

        private void trkQuality_Scroll(object sender, EventArgs e) {
            if(initialized) {
                if(!isMouseDown && ! isKeyDown) {
                    if(camera.Quality != trkQuality.Value) {
                        camera.Quality = trkQuality.Value;
                        sendComponentChanged();
                    }
                }
            }
        }
        #endregion

    }

}