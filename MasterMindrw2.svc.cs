﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MasterMindrw2
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerSession)]
    public class MasterMindrw2 : IMasterMindrw2
    {

        Game g;
        Random r = new Random(Int32.Parse(ConfigurationManager.AppSettings["Seed"]));

        public bool New()
        {
            try
            {
                g = new Game(r.Next(6 * 6 * 6 * 6));
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public int[] Try(int[] c)
        {
            Comb com = new Comb(
                c[0],
                c[1],
                c[2],
                c[3]);
            if (g != null)
            {
                Guess asdf = g.Try(com);
                int[] arr = asdf.toArray();
                return arr;
            }
            return null;
            
        }

        public int[] End()
        {
            return g.Finish().toArray();
        }

        public int[] Win(string name)
        {
            DBHandler.AddScore(g.Score(), name);
            return g.Score().toArray();
        }

        public ScoreEntry[] FetchAll()
        {
            return DBHandler.FetchAll();
        }

        public ScoreEntry[] FetchTime()
        {
            return DBHandler.FetchTime();
        }

        public ScoreEntry[] FetchTries()
        {
            return DBHandler.FetchTries();
        }


        public DateTime SyncTime()
        {
            return DateTime.Now;
        }
    }
}
