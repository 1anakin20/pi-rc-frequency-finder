using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Microsoft.Kinect;

namespace rc_frequency_finder.kinect
{
    public class KinectInfrared
    {
        private KinectSensor _sensor;
        private InfraredFrameReader _reader;
        public event EventHandler<BitmapFrameArrivedArgs> BitmapArrived;
        public Bitmap LastFrame { get; private set; }

        public KinectInfrared()
        {
            _sensor = KinectSensor.GetDefault();
            _reader = _sensor.InfraredFrameSource.OpenReader();
            _reader.FrameArrived += KinectInfraredFrameReady;
        }

        public void Start()
        {
            _sensor.Open();
        }

        private void KinectInfraredFrameReady(object sender, InfraredFrameArrivedEventArgs e)
        {
            using (var frame = e.FrameReference.AcquireFrame())
            {
                if (frame != null)
                {
                    Bitmap bitmapFrame = IRFrameToBitmap(frame);
                    LastFrame = new Bitmap(bitmapFrame);
                    OnBitmapArrived(new BitmapFrameArrivedArgs(bitmapFrame));
                }
            }
        }

        private Bitmap IRFrameToBitmap(InfraredFrame frame)
        {
            int width = frame.FrameDescription.Width;
            int height = frame.FrameDescription.Height;
            PixelFormat format = PixelFormat.Format32bppRgb;

            ushort[] infraredData = new ushort[frame.FrameDescription.LengthInPixels];
            byte[] pixelData = new byte[frame.FrameDescription.LengthInPixels * 4];

            frame.CopyFrameDataToArray(infraredData);

            for (int infraredIndex = 0; infraredIndex < infraredData.Length; infraredIndex++)
            {
                ushort ir = infraredData[infraredIndex];
                byte intensity = (byte)(ir >> 8);

                pixelData[infraredIndex * 4] = intensity; // Blue
                pixelData[infraredIndex * 4 + 1] = intensity; // Green   
                pixelData[infraredIndex * 4 + 2] = intensity; // Red
                pixelData[infraredIndex * 4 + 3] = 255;
            }

            var bitmap = new Bitmap(width, height, format);
            var bitmapdata = bitmap.LockBits(
                new System.Drawing.Rectangle(0, 0, width, height),
                ImageLockMode.WriteOnly,
                bitmap.PixelFormat
            );
            IntPtr ptr = bitmapdata.Scan0;

            Marshal.Copy(pixelData, 0, ptr, pixelData.Length);
            bitmap.UnlockBits(bitmapdata);

            return bitmap;
        }

        protected virtual void OnBitmapArrived(BitmapFrameArrivedArgs e)
        {
            BitmapArrived?.Invoke(this, e);
        }
    }
}