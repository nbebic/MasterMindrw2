using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterMindrw2
{
    class Success
    {
        public static Success undef = new Success(TimeSpan.MaxValue, 159);
        public TimeSpan time;
        public int attempts;

        public Success(TimeSpan curTime, int attempts)
        {
            this.time = curTime;
            this.attempts = attempts;
        }

        internal int[] toArray()
        {
            int[] a = { (int)time.TotalSeconds, attempts };
            return a;
        }
    }
}
