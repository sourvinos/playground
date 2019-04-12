using Playground.Interfaces;
using System;

namespace Playground.Implementations
{
    public class Clock : IClock
    {
        public DateTime GetTime()
        {
            return DateTime.Now;
        }
    }
}
