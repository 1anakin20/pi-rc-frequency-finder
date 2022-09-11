using System;

namespace rc_frequency_finder.image
{
    public class DifferentImageSize : Exception
    {
        public DifferentImageSize(string message) : base(message)
        {
        }
    }
}