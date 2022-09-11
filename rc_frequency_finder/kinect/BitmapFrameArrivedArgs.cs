using System.Drawing;

namespace rc_frequency_finder.kinect
{
    public class BitmapFrameArrivedArgs
    {
        public Bitmap Bitmap { get; }

        public BitmapFrameArrivedArgs(Bitmap bitmap)
        {
            Bitmap = bitmap;
        }
    }
}