using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace MasterMindrw2
{
    public class DBHandler
    {
        internal static void AddScore(Success suc, string name)
        {
            try
            {
                using (SqlConnection konekcija = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ToString()))
                {
                    konekcija.Open();

                    string upit = "INSERT INTO rezultat (ime, brojPokusaja, vreme) VALUES('"+name+"','"+suc.attempts+"','"+(int)suc.time.TotalSeconds+"')";

                    SqlCommand insertCommand = new SqlCommand(upit, konekcija);
                    insertCommand.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                string s = e.ToString();

                throw new FaultException<string>(e.Message);
            }
        }

        internal static ScoreEntry[] FetchAll()
        {
            return DoTheStuff(
            "SELECT ime, brojPokusaja, vreme FROM rezultat"
            );
        }

        internal static ScoreEntry[] FetchTime()
        {
            return DoTheStuff(
            "SELECT ime, brojPokusaja, vreme FROM rezultat ORDER BY vreme ASC LIMIT 10"
            );
        }

        internal static ScoreEntry[] FetchTries()
        {
            return DoTheStuff(
            "SELECT ime, brojPokusaja, vreme FROM rezultat ORDER BY brojPokusaja ASC LIMIT 10"
            );
        }

        internal static ScoreEntry[] DoTheStuff(string command)
        {
            List<ScoreEntry> list = new List<ScoreEntry>();
            DataSet d = new DataSet();
            using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ToString()))
            {
                using (SqlDataAdapter a = new SqlDataAdapter
                    (command, c))
                {
                    a.Fill(d);
                }
            }
            for (int i = 0; i < d.Tables[0].Rows.Count; i++)
                list.Add(new ScoreEntry(d.Tables[0].Rows[i]));

            return list.ToArray();
        }
    }
}