using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterMindrw2
{
    struct Comb
    {
        public static Comb undef = new Comb(-1, -1, -1, -1);
        
        private int[] k;

        public int this[int i]
        {
            get
            {
                return k[i];
            }
        }

        public Comb(int p1, int p2, int p3, int p4)
        {
            k = new int[4];
            k[0] = p1;
            k[1] = p2;
            k[2] = p3;
            k[3] = p4;
        }

        public int[] toArray() { return k; }

        public int[] count()
        {
            int[] c = { 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < 4; i++)
            {
                c[k[i]]++;
            }
            return c;
        }

        public Guess compare(Comb b)
        {
            int t = 0, d = 0; 
            int[] c1 = this.count(), c2 = b.count();

            for (int i = 1; i <= 6; i++) 
                t += Math.Min(c1[i], c2[i]);

            for (int i = 0; i < 4; i++) 
                d += (this[i] == b[i]) ? 1 : 0;

            return new Guess(d, t - d);
        }

        public bool identTo(Comb b)
        {
            bool p = true;
            for (int i = 0; (i < 3) && p; i++)
                p = p && (this[i] == b[i]);
            return p;
        }
    }
}
