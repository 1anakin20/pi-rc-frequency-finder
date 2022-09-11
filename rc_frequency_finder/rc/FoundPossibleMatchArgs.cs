using System;

namespace rc_frequency_finder.rc
{
    public class FoundPossibleMatchArgs
    {
        public string Command { get; }

        public FoundPossibleMatchArgs(string command)
        {
            Command = command;
        }
    }
}