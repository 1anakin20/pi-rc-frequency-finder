namespace rc_frequency_finder.rc
{
    public class Signal
    {
        public int USeconds;
        public int SyncRepeats;
        public int SyncMultiplier;
        public int SignalRepeats;

        public Signal(int uSeconds, int syncRepeats, int syncMultiplier, int signalRepeats)
        {
            USeconds = uSeconds;
            SyncRepeats = syncRepeats;
            SyncMultiplier = syncMultiplier;
            SignalRepeats = signalRepeats;
        }

        protected bool Equals(Signal other)
        {
            return USeconds == other.USeconds && SyncRepeats == other.SyncRepeats && SyncMultiplier == other.SyncMultiplier && SignalRepeats == other.SignalRepeats;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Signal)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = USeconds;
                hashCode = (hashCode * 397) ^ SyncRepeats;
                hashCode = (hashCode * 397) ^ SyncMultiplier;
                hashCode = (hashCode * 397) ^ SignalRepeats;
                return hashCode;
            }
        }
    }
}