using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterMindrw2
{
    struct Guess
    {
        public int d;
        public int p;

        public Guess(int d, int p)
        {
            this.d = d;
            this.p = p;
        }

        public bool identTo(Guess b)
        {
            return (this.d == b.d) && (this.p == b.p);
        }

        internal int[] toArray()
        {
            int[] a = { d, p };
            return a;
        }
    }
}
