using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterMindrw2
{
    public class Game
    {
        private readonly Comb secret;
        private bool done = false;
        private DateTime start, end;
        private int attempts = 0;
        private bool solved = false;

        public Game(int p)
        {
            secret = new Comb(
                p % 6 + 1,
                (p / 6) % 6 + 1,
                (p / 36) % 6 + 1,
                (p / 216) % 6 + 1
                );
            start = DateTime.Now;
        }

        public bool Solved
        {
            get { return solved; }
        }

        public Comb Solution
        {
            get
            {
                if (done) return secret;
                return Comb.undef;
            }
        }

        public TimeSpan curTime
        {
            get 
            {
                if (done) return end - start;
                return DateTime.Now - start;
            }
        }

        public Guess Try(Comb p)
        {
            if (attempts < 6)
            {
                attempts++;
                bool cor = p.identTo(secret);
                solved = solved || cor;
                return secret.compare(p);
            }
            return new Guess(0, 0);
        }

        public Comb Finish()
        {
            end = DateTime.Now;
            done = true;
            return secret;
        }

        public Success Score()
        {
            if (solved)
                return new Success(curTime, attempts);
            return Success.undef;
        }
    }
}