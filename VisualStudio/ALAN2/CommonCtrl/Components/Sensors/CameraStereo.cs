
#region Usings
using System;
using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using CommonCtrl;
#endregion

namespace CommonCtrl {

    [Serializable]
    public class CameraStereo : Camera {

        #region Fields

        private int leftCameraIndex = -1;
        private int rightCameraIndex = -1;

        protected bool swapped;

        [NonSerialized]
        private byte currentFrame;
        [NonSerialized]
        private bool leftCameraRetrieved;
        [NonSerialized]
        private bool rightCameraRetrieved;

        // processing camera images
        [NonSerialized]
        private Mat matLeftColourFrame;
        [NonSerialized]
        private Mat matRightColourFrame;
        [NonSerialized]
        private Mat matLeftGrayFrame;
        [NonSerialized]
        private Mat matRightGrayFrame;
        [NonSerialized]
        private Mat matStereoFrame;

        // capturing camera images
        [NonSerialized]
        private Capture cameraLeft = null;
        [NonSerialized]
        private Capture cameraRight = null;
        #endregion

        #region Events
        [field: NonSerialized]
        public event OnStereoImageCaptured onStereoImageCaptured;
        #endregion

        #region Lifecycle
        public CameraStereo() {
            // used for xml serialization ...
        }
        #endregion

        #region Functions
        public override void open() {
            if(active) {
                if(leftCameraIndex >= 0 && rightCameraIndex >= 0) {
                    base.open();
                    CvInvoke.UseOpenCL = false;
                    matLeftColourFrame = new Mat();
                    matRightColourFrame = new Mat();
                    matLeftGrayFrame = new Mat();
                    matRightGrayFrame = new Mat();
                    matStereoFrame = new Mat();
                    cameraLeft = new Capture(leftCameraIndex);
                    cameraLeft.SetCaptureProperty(CapProp.FrameWidth, resolution.Width);
                    cameraLeft.SetCaptureProperty(CapProp.FrameHeight, resolution.Height);
                    cameraLeft.ImageGrabbed += RetrieveLeftFrame;
                    cameraRight = new Capture(rightCameraIndex);
                    cameraRight.SetCaptureProperty(CapProp.FrameWidth, resolution.Width);
                    cameraRight.SetCaptureProperty(CapProp.FrameHeight, resolution.Height);
                    cameraRight.ImageGrabbed += RetrieveRightFrame;
                    cameraLeft.Start();
                    cameraRight.Start();
                } else {
                    throw new ComponentInitializationException("Camera indices not set.");
                }
            }
        }

        public override void close() {
            base.close();
            if(cameraLeft != null) {
                cameraLeft.Stop();
                cameraLeft.Dispose();
            }
            if(cameraRight != null) {
                cameraRight.Stop();
                cameraRight.Dispose();
            }
        }

        public override string ToString() {
            return name+" [USB"+leftCameraIndex+"+USB"+rightCameraIndex+"]";
        }
        #endregion

        #region Properties
        public int LeftCameraIndex {
            get { return leftCameraIndex; }
            set { leftCameraIndex = value; }
        }

        public int RightCameraIndex {
            get { return rightCameraIndex; }
            set { rightCameraIndex = value; }
        }

        public bool Swapped {
            get { return swapped; }
            set { swapped = value; }
        }
        #endregion

        #region Controlling
        public override void play() {
            if(cameraLeft != null && cameraRight != null) {
                cameraLeft.Start();
                cameraRight.Start();
            }
        }

        public override void pause() {
            if(cameraLeft != null && cameraRight != null) {
                cameraLeft.Pause();
                cameraRight.Pause();
            }
        }

        public void swapColorChannels() {
            swapped = !swapped;
        }
        #endregion

        #region Processing
        private void RetrieveLeftFrame(object sender, EventArgs arg) {
            // capture and cache image from left camera
            if(cameraLeft != null && cameraLeft.Ptr != IntPtr.Zero) {
                cameraLeft.Retrieve(matLeftColourFrame, 0);
                leftCameraRetrieved = true;
                processFrame();
            }
        }

        private void RetrieveRightFrame(object sender, EventArgs arg) {
            // capture and cache image from right camera
            if(cameraRight != null && cameraRight.Ptr != IntPtr.Zero) {
                cameraRight.Retrieve(matRightColourFrame, 0);
                rightCameraRetrieved = true;
                processFrame();
            }
        }

        private void processFrame() {

            try {

                if(leftCameraRetrieved && rightCameraRetrieved) {

                    #region Logbook
                    Logger.Log(Level.FINE, "Processing camera image frame ..."/*, Debug.CAMERAS*/);
                    #endregion

                    // count frames [0, 59]
                    if(currentFrame < 59) {
                        currentFrame++;
                    } else {
                        currentFrame=0;
                    }

                    // calculate stereo image by combining the left and right image
                    if(matLeftColourFrame != null && matRightColourFrame!=null) {

                        CvInvoke.CvtColor(matLeftColourFrame, matLeftGrayFrame, ColorConversion.Bgr2Gray);
                        CvInvoke.CvtColor(matRightColourFrame, matRightGrayFrame, ColorConversion.Bgr2Gray);

                        if(swapped) {
                            using(VectorOfMat vm = new VectorOfMat(matLeftGrayFrame, matLeftGrayFrame, matRightGrayFrame)) {
                                CvInvoke.Merge(vm, matStereoFrame);
                            }
                        } else {
                            using(VectorOfMat vm = new VectorOfMat(matRightGrayFrame, matRightGrayFrame, matLeftGrayFrame)) {
                                CvInvoke.Merge(vm, matStereoFrame);
                            }
                        }

                        // inform listeners about new stereo image available (e.g. network servers)
                        if(colour) {
                            handleCameraImageCaptured(this, matStereoFrame);
                        } else {
                            handleCameraImageCaptured(this, matStereoFrame);
                        }

                        // inform listeners about new stereo image available (e.g. motion detection)
                        if(onStereoImageCaptured != null) {
                            if(colour) {
                                onStereoImageCaptured(this, matLeftColourFrame, matRightColourFrame, matStereoFrame);
                            } else {
                                onStereoImageCaptured(this, matLeftGrayFrame, matRightGrayFrame, matStereoFrame);
                            }
                        }

                    }

                    leftCameraRetrieved = false;
                    rightCameraRetrieved = false;

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
                CameraStereo c = (CameraStereo)component;
                #region Change Current Resolution
                if(c.Resolution != resolution) {
                    if(cameraLeft!=null && cameraRight!=null) {
                        cameraLeft.SetCaptureProperty(CapProp.FrameWidth, c.Resolution.Width);
                        cameraLeft.SetCaptureProperty(CapProp.FrameHeight, c.Resolution.Height);
                        cameraRight.SetCaptureProperty(CapProp.FrameWidth, c.Resolution.Width);
                        cameraRight.SetCaptureProperty(CapProp.FrameHeight, c.Resolution.Height);
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
                this.leftCameraIndex = c.LeftCameraIndex;
                this.rightCameraIndex = c.RightCameraIndex;
                this.swapped = c.Swapped;
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