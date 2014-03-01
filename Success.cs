using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterMindrw2
{
    class Success
    {
        public static Success undef = new Success(TimeSpan.MaxValue, 159);
        private TimeSpan time;
        private int attempts;

        public Success(TimeSpan curTime, int attempts)
        {
            this.time = curTime;
            this.attempts = attempts;
        }
    }
}
