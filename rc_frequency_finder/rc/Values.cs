using System;

namespace rc_frequency_finder.rc
{
    public class Values
    {
        // RC car params
        public readonly string Frequency;
        public readonly string DeadFrequency;
        // final
        public readonly string SyncBurstUs;
        public readonly string SyncSpacingUs;
        public readonly string SyncTotal;
        public readonly string SpacingUs;
        public readonly string BurstUs;
        // Movement params
        public readonly string Stop;
        /*
        public readonly string Forward;
        public readonly string ForwardLeft;
        public readonly string ForwardRight;
        public readonly string Left;
        public readonly string Right;
        public readonly string Reverse;
        public readonly string BackwardsLeft;
        public readonly string BackwardsRight;
        */

        public Values(string frequency, string deadFrequency, string syncBurstUS, string syncSpacingUS, string syncTotal, string spacingUS, string burstUS, string stop)
        {
            Frequency = frequency;
            DeadFrequency = deadFrequency;
            SyncBurstUs = syncBurstUS;
            SyncSpacingUs = syncSpacingUS;
            SyncTotal = syncTotal;
            SpacingUs = spacingUS;
            BurstUs = burstUS;
            Stop = stop;
            /*
            Stop = stop;
            Forward = forward;
            ForwardLeft = forwardLeft;
            ForwardRight = forwardRight;
            Left = left;
            Right = right;
            Reverse = reverse;
            BackwardsLeft = backwardsLeft;
            BackwardsRight = backwardsRight;
            */
        }
    }
}