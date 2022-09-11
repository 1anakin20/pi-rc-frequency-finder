using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Threading;
using rc_frequency_finder.kinect;
using rc_frequency_finder.vision;

namespace rc_frequency_finder.rc
{
    public class FrequencyLoop
    {
        private PiRCTransmission _transmission;
        private KinectCV _kinectCV;
        private bool _stop = false;
        private const string DeadFrequency = "27.145";
        public event EventHandler<FoundPossibleMatchArgs> FoundPossibleMatch;

        public FrequencyLoop(KinectCV kinectCV, string ip, int port)
        {
            _transmission = new PiRCTransmission(ip, port);
            _kinectCV = kinectCV;

        }

        public void Start()
        {
            var signals = SignalList();
            Console.WriteLine("Loaded signal list");
            _kinectCV.KinectCVThresholdPassed += (sender, args) => _stop = true;
            foreach (var frequency in new[] { "49.830", "49.845", "49.860", "49.875", "49.890" })
            {
                foreach (var signal in signals)
                {
                    var command = $@"[
                    {{
                        ""frequency"": {frequency},
                        ""dead_frequency"": {DeadFrequency},
                        ""burst_us"": {signal.USeconds * signal.SyncMultiplier},
                        ""spacing_us"": {signal.USeconds},
                        ""repeats"": {signal.SyncRepeats},
                    }},
                    {{
                        ""frequency"": {frequency},
                        ""dead_frequency"": {DeadFrequency},
                        ""burst_us"": {signal.USeconds},
                        ""spacing_us"": {signal.USeconds},
                        ""repeats"": {signal.SignalRepeats},
                    }}
                    ]";

                    _transmission.Send(command);
                    Thread.Sleep(1000);
                    if (_stop)
                    {
                        Console.WriteLine("==================== WE MAY HAVE A WINNER ==========================");
                        Console.WriteLine(command);
                        OnFoundPossibleMatch(new FoundPossibleMatchArgs(command));
                        return;
                    }
                }
            }
        }

        public void Stop()
        {
            _stop = true;
        }

        private static List<Signal> SignalList()
        {
            // From: https://github.com/bskari/pi-rc/blob/08d62b03d81729fb6c20ff86642ea9d440625de1/watch.html#L243
            var signals = new List<Signal>();
            // Do the most common ones first
            foreach (var uSeconds in new[]{400, 500})
            {
                var syncRepeats = 4;
                var syncMultiplier = 3;
                for (var signalRepeats = 0; signalRepeats <= 30; signalRepeats++)
                {
                    var signal = new Signal(uSeconds, syncRepeats, syncMultiplier, signalRepeats);
                    signals.Add(signal);
                }
            }

            foreach (var uSeconds in new[]{400, 500})
            {
                foreach (var syncRepeats in new[]{3, 5})
                {
                    foreach (var syncMultiplier in new[]{4, 5})
                    {
                        for (int signalRepeats = 10; signalRepeats <= 30; signalRepeats++)
                        {
                            var signal = new Signal(uSeconds, syncRepeats, syncMultiplier,
                                signalRepeats);
                            signals.Add(signal);
                        }
                    }
                }
            }

            foreach (var uSeconds in new[]{400, 500})
            {
                foreach (var syncRepeats in new[]{3, 4, 5})
                {

                    foreach (var syncMultiplier in new[] { 3, 4, 5 })
                    {
                        for (int signalRepeats = 10; signalRepeats <= 65; signalRepeats++)
                        {
                            var signal = new Signal(uSeconds, syncRepeats, syncMultiplier, signalRepeats);
                            if (!signals.Contains(signal))
                            {
                                signals.Add(signal);
                            }
                        }
                    }
                }
            }

            // Do everything
            for (int uSeconds = 100; uSeconds < 1201; uSeconds += 100)
            {
                for (var syncRepeats = 2; syncRepeats < 8; syncRepeats++)
                {
                    for (int syncMultiplier = 0; syncMultiplier < 8; syncMultiplier++)
                    {
                        for (int signalRepeats = 10; signalRepeats < 65; signalRepeats++)
                        {
                            var signal = new Signal(uSeconds, syncRepeats, syncMultiplier,
                                signalRepeats);
                            if (!signals.Contains(signal))
                            {
                                signals.Add(signal);
                            }
                        }
                    }
                }
            }

            return signals;
        }

        protected virtual void OnFoundPossibleMatch(FoundPossibleMatchArgs e)
        {
            FoundPossibleMatch?.Invoke(this, e);
        }
    }
}