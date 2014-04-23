using System;
using System.Collections.Generic;
using System.Data;
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
        public int attempts { get; private set; }

        public ScoreEntry(string name, int time, int atm)
        {
            this = new ScoreEntry();
            this.name = name;
            this.time = time;
            this.attempts = atm;
        }

        internal ScoreEntry(DataRow row)
        {
            this = new ScoreEntry();
            this.name = (string) row[0];
            this.attempts = (int) row[1];
            this.time = (int) row[2];
        }
    }
}