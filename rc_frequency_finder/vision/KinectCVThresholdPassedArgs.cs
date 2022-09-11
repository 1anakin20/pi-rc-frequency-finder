namespace rc_frequency_finder.kinect
{
    public sealed class KinectCVThresholdPassedArgs
    {
        public double SetThreshold { get; }
        public double CurrentValue { get; }

        public KinectCVThresholdPassedArgs(double setThreshold, double currentValue)
        {
            SetThreshold = setThreshold;
            CurrentValue = currentValue;
        }
    }
}