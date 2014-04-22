using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MasterMindrw2
{
    [DataContract]
    public struct ScoreEntry
    {
        [DataMember]
        public string name { get; private set; }
        [DataMember]
        public int time { get; private set; }
        [DataMember]
        public int attempts { get; protected set; }

        public ScoreEntry(string name, int time, int atm)
        {
            this.name = name;
            this.time = time;
            this.attempts = atm;
        }
    }
}