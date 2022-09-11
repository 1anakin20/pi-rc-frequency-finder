using System;
using System.Collections;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using rc_frequency_finder.image;
using rc_frequency_finder.kinect;

namespace rc_frequency_finder.vision
{
    public class KinectCV
    {
        private readonly KinectInfrared _kinect;
        private Bitmap _previous;
        private Bitmap _current;
        private readonly double _threshold;
        public event EventHandler<KinectCVThresholdPassedArgs> KinectCVThresholdPassed;
        public event EventHandler<KinectCVDifferenceComputedArgs> KinectCVDifferenceComputed; 

        public KinectCV(KinectInfrared kinect, double threshold)
        {
            _kinect = kinect;
            _threshold = threshold;
        }

        public void Start()
        {
            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    var frame = _kinect.LastFrame;
                    if (frame != null)
                    {
                        var difference = ComputeDifference(frame);
                        OnKinectCvDifferenceComputed(new KinectCVDifferenceComputedArgs(difference));
                        if (difference > _threshold)
                        {
                            OnKinectCvThresholdPassed(new KinectCVThresholdPassedArgs(_threshold, difference));
                        }
                    }
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }

        private double ComputeDifference(Bitmap newImage)
        {
            if (_previous == null)
            {
                _previous = newImage;
                return 0;
            }

            _current = newImage;

            var difference = ComputeDifference(_previous, _current);

            _previous = _current;
            return difference;
        }

        private static double ComputeDifference(Bitmap image1, Bitmap image2)
        {
            if (image1.Size != image2.Size)
            {
                throw new DifferentImageSize($"The size of the images don't match. Image 1: {image1.Size}; Image 2: {image2.Size}");
            }

            float diff = 0;

            for (int y = 0; y < image1.Height; y++)
            {
                for (int x = 0; x < image1.Width; x++)
                {
                    Color pixel1 = image1.GetPixel(x, y);
                    Color pixel2 = image2.GetPixel(x, y);

                    diff += Math.Abs(pixel1.R - pixel2.R);
                    diff += Math.Abs(pixel1.G - pixel2.G);
                    diff += Math.Abs(pixel1.B - pixel2.B);
                }
            }

            return 100 * (diff / 255) / (image1.Width * image2.Height * 3);
        }

        protected virtual void OnKinectCvThresholdPassed(KinectCVThresholdPassedArgs e)
        {
            KinectCVThresholdPassed?.Invoke(this, e);
        }

        protected virtual void OnKinectCvDifferenceComputed(KinectCVDifferenceComputedArgs e)
        {
            KinectCVDifferenceComputed?.Invoke(this, e);
        }
    }
}