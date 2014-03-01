using System;
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
            return g.Try(new Comb(
                c[0],
                c[1],
                c[2],
                c[3])).toArray();
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

        public System.Data.DataSet FetchAll()
        {
            return DBHandler.FetchAll();
        }

        public System.Data.DataSet FetchTime()
        {
            return DBHandler.FetchTime();
        }

        public System.Data.DataSet FetchTries()
        {
            return DBHandler.FetchTries();
        }


        public DateTime SyncTime()
        {
            throw new NotImplementedException();
        }
    }
}
