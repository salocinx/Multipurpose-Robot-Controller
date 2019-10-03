
#region Usings
using System;
using Emgu.CV;
using Emgu.CV.CvEnum;
using CommonCtrl;
#endregion

namespace CommonCtrl {

    [Serializable]
    public class CameraMono : Camera {

        #region Fields

        private int cameraIndex = -1;

        [NonSerialized]
        private byte currentFrame;

        // processing camera images
        [NonSerialized]
        private Mat matGrayFrame;
        [NonSerialized]
        private Mat matColourFrame;

        // capturing camera images
        [NonSerialized]
        private Capture camera = null;
        #endregion

        #region Lifecycle
        public CameraMono() {
            // used for xml serialization ...
        }
        #endregion

        #region Functions
        public override void open() {
            if(active) {
                if(cameraIndex >= 0) {
                    base.open();
                    CvInvoke.UseOpenCL = false;
                    matColourFrame = new Mat();
                    matGrayFrame = new Mat();
                    camera = new Capture(cameraIndex);
                    camera.SetCaptureProperty(CapProp.FrameWidth, resolution.Width);
                    camera.SetCaptureProperty(CapProp.FrameHeight, resolution.Height);
                    camera.ImageGrabbed += ProcessFrame;
                    camera.Start();
                } else {
                    throw new ComponentInitializationException("Camera index not set.");
                }
            }
        }

        public override void close() {
            if(camera != null) {
                base.close();
                camera.Stop();
                camera.Dispose();
            }
        }

        public override string ToString() {
            return name+" [USB"+cameraIndex+"]";
        }
        #endregion

        #region Properties
        public int CameraIndex {
            get { return cameraIndex; }
            set { cameraIndex = value; }
        }
        #endregion

        #region Controlling
        public override void play() {
            if(camera != null) {
                camera.Start();
            }
        }

        public override void pause() {
            if(camera != null) {
                camera.Pause();
            }
        }
        #endregion

        #region Processing
        private void ProcessFrame(object sender, EventArgs arg) {

            try {

                #region Logbook
                Logger.Log(Level.FINE, "Processing camera image frame ...", Debug.CAMERAS);
                #endregion

                // count frames [0, 59]
                if(currentFrame < 59) {
                    currentFrame++;
                } else {
                    currentFrame = 0;
                }

                // capture and cache image from camera
                if(camera != null && camera.Ptr != IntPtr.Zero) {
                    camera.Retrieve(matColourFrame, 0);
                }

                // distribute frames to listeners
                if(colour) {
                    handleCameraImageCaptured(this, matColourFrame);
                } else {
                    CvInvoke.CvtColor(matColourFrame, matGrayFrame, ColorConversion.Bgr2Gray);
                    handleCameraImageCaptured(this, matGrayFrame);
                }

            } catch(Exception ex) {
                #region Logbook
                Logger.Log(Level.WARNING, "Could not process camera frame: "+ex.Message, Debug.CAMERAS);
                #endregion
            }

        }
        #endregion

        #region Update
        public override void update(Component component) {
            if(GetType() == component.GetType()) {
                CameraMono c = (CameraMono)component;
                #region Change Current Resolution
                if(c.Resolution != resolution) {
                    if(camera!=null) {
                        camera.SetCaptureProperty(CapProp.FrameWidth, c.Resolution.Width);
                        camera.SetCaptureProperty(CapProp.FrameHeight, c.Resolution.Height);
                    }
                }
                #endregion
                #region Change Playback State
                if(c.capturing) {
                    this.play();
                } else {
                    this.pause();
                }
                #endregion
                #region Change Encoding Quality
                if(c.Quality != quality) {
                    this.quality = c.Quality;
                    // trigger recalculation
                    this.codecInfo = null;
                    this.codecInfo = CodecInfo;
                    // trigger recalculation
                    this.encoderParams = null;
                    this.encoderParams = EncoderParams;
                }
                #endregion
                #region Update Properties
                this.active = c.Active;
                this.name = c.Name;
                this.cameraIndex = c.CameraIndex;
                this.resolution = c.Resolution;
                this.colour = c.Colour;
                this.capturing = c.Capturing;
                this.streaming = c.Streaming;
                #endregion
            }
        }
        #endregion

    }

}