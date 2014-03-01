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

        public int[] Try(int[] comb)
        {
            throw new NotImplementedException();
        }

        public int[] End()
        {
            throw new NotImplementedException();
        }

        public int[] Win()
        {
            throw new NotImplementedException();
        }

        public System.Data.DataSet FetchAll()
        {
            throw new NotImplementedException();
        }

        public System.Data.DataSet FetchTime()
        {
            throw new NotImplementedException();
        }

        public System.Data.DataSet FetchTries()
        {
            throw new NotImplementedException();
        }


        public DateTime SyncTime()
        {
            throw new NotImplementedException();
        }
    }
}
