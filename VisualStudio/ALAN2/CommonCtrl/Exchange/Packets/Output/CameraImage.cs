
#region Usings
using System;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
#endregion

namespace CommonCtrl {

    [Serializable]
    public class CameraImage : NetworkPacket {

        #region Fields

        // compressed image data
        private byte[] compressedImage;         

        private int rawImageSize;
        private int compressedImageSize;

        // raw image meta data
        private ushort imageWidth;
        private ushort imageHeight;
        private short imageDepth;

        // compressed image meta data
        private ushort compressionTime;
        private byte compressionRatio;

        // encoding and compression
        [NonSerialized]
        private static Stopwatch watch = new Stopwatch();
        [NonSerialized]
        private ImageCodecInfo codecInfo;
        [NonSerialized]
        private EncoderParameters encoderParams;

        #endregion

        #region Lifecycle
        public CameraImage(ushort componentId, Mat image, ImageCodecInfo codecInfo, EncoderParameters encoderParams) : base(componentId) {
            this.codecInfo = codecInfo;
            this.encoderParams = encoderParams;
            this.imageWidth = (ushort)image.Width;
            this.imageHeight = (ushort)image.Height;
            this.imageDepth = (short)image.Depth;
            this.compress(image);
        }
        #endregion

        #region Properties
        public byte[] CompressedImage {
            get { return compressedImage; }
        }

        public int RawImageSize {
            get { return rawImageSize; }
        }

        public int CompressedImageSize {
            get { return compressedImageSize; }
        }

        public ushort ImageWidth {
            get { return imageWidth; }
        }

        public ushort ImageHeight {
            get { return imageHeight; }
        }

        public short ImageDepth {
            get { return imageDepth; }
        }

        public ushort CompressionTime {
            get { return compressionTime; }
        }

        public byte CompressionRatio {
            get { return compressionRatio; }
        }
        #endregion

        #region Compression
        public void compress(Mat image) {
            using(MemoryStream stream = new MemoryStream()) {
                watch.Restart();
                rawImageSize = image.Step * image.Rows;
                image.Bitmap.Save(stream, codecInfo, encoderParams);
                watch.Stop();
                this.compressedImage = stream.ToArray();
                this.compressedImageSize = compressedImage.Length;
                this.compressionTime = (ushort)watch.ElapsedMilliseconds;
                this.compressionRatio = (byte)((double)compressedImage.Length/(double)rawImageSize*100.0);
            }
        }

        public static Image<Bgr, Byte> decompress(CameraImage packet) {
            using(MemoryStream stream = new MemoryStream(packet.CompressedImage, 0, packet.CompressedImage.Length)) {
                stream.Position = 0;
                return new Image<Bgr, Byte>(new Bitmap(Image.FromStream(stream, true)));
            }
        }
        #endregion

    }

}
