using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using rc_frequency_finder.kinect;
using rc_frequency_finder.rc;
using rc_frequency_finder.vision;

namespace rc_frequency_finder
{
    public partial class Form1 : Form
    {
        private KinectInfrared _kinect;
        private bool _started;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _kinect = new KinectInfrared();
            _kinect.BitmapArrived += KinectBitmapFrameArrived;
            Thread kinectThread = new Thread(() => _kinect.Start());
            kinectThread.Start();

        }

        private void KinectBitmapFrameArrived(object sender, BitmapFrameArrivedArgs e)
        {
            kinectImage.Image = e.Bitmap;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (!_started)
            {
                startButton.Enabled = false;

                var threshold = Convert.ToDouble(thresholdText.Text);
                var kinectCV = new KinectCV(_kinect, threshold);
                kinectCV.KinectCVDifferenceComputed += KinectCVOnKinectCVDifferenceComputed;
                kinectCV.Start();

                var frequencyLoop = new FrequencyLoop(kinectCV, IPText.Text, int.Parse(portText.Text));
                frequencyLoop.FoundPossibleMatch += FrequencyLoopOnFoundPossibleMatch;
                Thread frequencyLoopThread = new Thread(() => frequencyLoop.Start());
                frequencyLoopThread.Start();
            }
        }

        private void FrequencyLoopOnFoundPossibleMatch(object sender, FoundPossibleMatchArgs e)
        {
            outputTextBox.Invoke((MethodInvoker)delegate
            {
                outputTextBox.Text = e.Command;
            });

            startButton.Invoke((MethodInvoker)delegate
            {
                startButton.Enabled = true;
            });
        }

        private void KinectCVOnKinectCVDifferenceComputed(object sender, KinectCVDifferenceComputedArgs e)
        {
            differenceLabel.Invoke((MethodInvoker)delegate
            {
                differenceLabel.Text = e.Difference.ToString(CultureInfo.CurrentCulture);
            });
        }
    }
}
