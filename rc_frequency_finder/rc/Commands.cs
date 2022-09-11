using System.Linq;

namespace rc_frequency_finder.rc
{
    public class Commands
    {
        private const string Json = @"[
            {
                ""frequency"": {frequency},
                ""dead_frequency"": {dead_frequency},
                ""burst_us"": {sync_burst_us},
                ""spacing_us"": {sync_spacing_us},
                ""repeats"": {sync_total}
            },
            {
                ""frequency"": {frequency},
                ""dead_frequency"": {dead_frequency},
                ""burst_us"": {burst_us},
                ""spacing_us"": {spacing_us},
                ""repeats"": {repeats}
            }
        ]";

        private readonly Values _values;

        public Commands(Values values)
        {
            _values = values;
        }

        public string Format(int repeats)
        {
            var data = Json;
            data = data.Replace("{frequency}", _values.Frequency);
            data = data.Replace("{dead_frequency}", _values.DeadFrequency);
            data = data.Replace("{sync_burst_us}", _values.SyncBurstUs);
            data = data.Replace("{sync_spacing_us}", _values.SyncSpacingUs);
            data = data.Replace("{sync_total}", _values.SyncTotal);
            data = data.Replace("{spacing_us}", _values.SpacingUs);
            data = data.Replace("{burst_us}", _values.BurstUs);
            data = data.Replace("{dead_frequency}", _values.Stop);
            data = data.Replace("{repeats}", repeats.ToString());
            data = data.Replace("\r\n", "");
            data = data.Replace(" ", "");
            System.Console.Write(data);
            return data;
        }
    }
}