
#region Usings
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonCtrl;
#endregion

namespace RemoteCtrl {

    public partial class CameraConfigWindow : Form {

        #region Fields
        private Agent agent;
        private Camera camera;
        private CameraMono cameraMono;
        private CameraStereo cameraStereo;
        #endregion

        #region Lifecycle
        public CameraConfigWindow(Agent agent, Camera camera) {
            this.agent = agent;
            this.camera = camera;
            InitializeComponent();
            initializeGui();
            agent.registerWindow(this);
        }

        private void initializeGui() {
            try {
                #region Find Hardware Camera
                HwCamera hwCamera;
                if(camera is CameraMono) {
                    cameraMono = (CameraMono)camera;
                    hwCamera = agent.findHardwareCamera(cameraMono.CameraIndex);
                } else {
                    cameraStereo = (CameraStereo)camera;
                    hwCamera = agent.findHardwareCamera(cameraStereo.LeftCameraIndex);
                }
                #endregion
                #region USB Combobox
                cbxUsbPorts.Items.Clear();
                foreach(HwCamera hwcam in agent.Cameras) {
                    cbxUsbPorts.Items.Add(hwcam);
                }
                cbxUsbPorts.SelectedItem = hwCamera;
                #endregion
                #region Resolutions Combobox
                Resolution selection = null;
                cbxResolutions.Items.Clear();
                foreach(Resolution resolution in hwCamera.Resolutions) {
                    if(resolution==camera.Resolution) {
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
                boxCapturing.Checked = camera.Capturing;
                boxStreaming.Checked = camera.Streaming;
                boxColoured.Checked = camera.Colour;
                if(camera is CameraStereo)
                    boxSwapped.Checked = cameraStereo.Swapped;
                boxSwapped.Visible = camera is CameraStereo;
                txtQuality.Text = "Encoding Quality: "+camera.Quality+"%";
                trkQuality.Value = camera.Quality;
            } catch(HardwareCameraNotFoundException ex) {
                #region Logbook
                Logger.Log(Level.WARNING, ex);
                #endregion
            }
        }
        #endregion

        #region Functions
        private bool updateModel(bool show) {
            // TODO: compare with other config windows how to update fields
            return true;
        }

        private void sendComponentUpdate() {
            // TODO: compare with other config windows how to update fields
        }
        #endregion

        #region Event-Handling
        private void CameraConfigWindow_FormClosing(object sender, FormClosingEventArgs evt) {
            if(evt.CloseReason == CloseReason.UserClosing) {
                if(updateModel(true)) {
                    sendComponentUpdate();
                    agent.doLocalUpdate(camera);
                } else {
                    evt.Cancel = true;
                }
            } else {
                if(updateModel(false)) {
                    sendComponentUpdate();
                }
            }
        }
        #endregion

    }

}
