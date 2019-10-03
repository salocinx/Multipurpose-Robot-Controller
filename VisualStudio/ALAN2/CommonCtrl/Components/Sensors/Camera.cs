
#region Usings
using System;
using System.Xml;
using System.Xml.Serialization;
using System.Drawing;
using System.Drawing.Imaging;
using Emgu.CV;
using Emgu.CV.CvEnum;
#endregion

namespace CommonCtrl {

    [Serializable]
    public abstract class Camera : Component {

        #region Fields
        protected int quality;
        protected bool colour;
        protected bool capturing;
        protected bool streaming;

        protected Resolution resolution;

        [NonSerialized]
        protected ImageCodecInfo codecInfo;
        [NonSerialized]
        protected EncoderParameters encoderParams;

        [NonSerialized]
        protected int framesReceived;
        [NonSerialized]
        protected long bytesReceived;
        [NonSerialized]
        protected int currentFramerate;
        [NonSerialized]
        protected long currentBandwidth;
        #endregion

        #region Properties
        public int Quality {
            get { return quality; }
            set { quality = value; }
        }

        public bool Colour {
            get {return colour; }
            set {colour = value; }
        }

        public bool Capturing {
            get { return capturing; }
            set { capturing = value; }
        }

        public bool Streaming {
            get { return streaming; }
            set { streaming = value; }
        }

        public Resolution Resolution {
            get { return resolution; }
            set { resolution = value; }
        }

        [XmlIgnore]
        public ImageCodecInfo CodecInfo {
            get {
                if(codecInfo==null) {
                    ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
                    foreach(ImageCodecInfo codec in codecs) {
                        if(codec.FormatID == ImageFormat.Jpeg.Guid) {
                            codecInfo = codec;
                        }
                    }
                }
                return codecInfo;
            }
        }

        [XmlIgnore]
        public EncoderParameters EncoderParams {
            get {
                if(encoderParams==null) {
                    encoderParams = new EncoderParameters(1);
                    encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, (long)quality);
                }
                return encoderParams;
            }

        }
        
        [XmlIgnore]
        public int FramesReceived {
            get { return framesReceived; }
            set { framesReceived = value; }
        }

        [XmlIgnore]
        public long BytesReceived {
            get { return bytesReceived; }
            set { bytesReceived = value; }
        }

        [XmlIgnore]
        public int CurrentFramerate {
            get { return currentFramerate; }
            set { currentFramerate = value; }
        }

        [XmlIgnore]
        public long CurrentBandwidth {
            get { return currentBandwidth; }
            set { currentBandwidth = value; }
        }
        #endregion

        #region Inheritance
        public override void open() {
            base.open();
        }

        public override void close() {
            base.close();
        }

        public override void update(Component component) {
            base.update(component);
        }

        public abstract void play();
        public abstract void pause();

        [field:NonSerialized]
        public event OnCameraImageCaptured onCameraImageCaptured;

        protected virtual void handleCameraImageCaptured(Camera camera, Mat frame) {
            onCameraImageCaptured?.Invoke(camera, frame);
        }
        #endregion

        #region Functions
        public void updateStatistics() {
            this.currentFramerate = framesReceived;
            this.currentBandwidth = bytesReceived;
            this.framesReceived = 0;
            this.bytesReceived = 0;
        }
        #endregion

    }

}