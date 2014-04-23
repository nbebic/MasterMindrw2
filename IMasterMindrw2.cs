using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MasterMindrw2
{
    [ServiceContract(SessionMode=SessionMode.Required)]
    public interface IMasterMindrw2
    {
        /// <summary>
        /// Pravi novu igru
        /// </summary>
        /// <returns>True ako je uspesno; false inace</returns>
        [OperationContract]
        [FaultContract(typeof(string))]
        bool New();

        /// <summary>
        /// Uporedjuje pokusaj sa krajnjom kombinacijom
        /// </summary>
        /// <param name="comb">Pokusaj</param>
        /// <returns>
        /// Niz koji sadrzi 2 elementa:
        /// 0: Broj P.I.N.M. (Crveni u 'Slagalici')
        /// 1: Broj P.A.N.N.M. (Zuti u 'Slagalici')
        /// </returns>
        [OperationContract]
        [FaultContract(typeof(string))]
        int[] Try(int[] comb);

        /// <summary>
        /// Zavrsava igru
        /// </summary>
        /// <returns>Tacnu kombinaciju kao niz od 4 cela broja (pocev od 0)</returns>
        [OperationContract]
        [FaultContract(typeof(string))]
        int[] End();

        /// <summary>
        /// Uspesno zavrsava igru i salje rezultat u bazu
        /// </summary>
        /// <returns>
        /// Konacan uspeh kao 2 cala broja:
        /// 0: Vreme u sekundama
        /// 1: Broj pokusaja
        /// </returns>
        /// <remarks> Ako igra nije pogodjena vraca {-1, -1} </remarks>
        [OperationContract]
        [FaultContract(typeof(string))]
        int[] Win(string ime);

        /// <summary>
        /// Cita sve upisane rezultate u bazi
        /// </summary>
        /// <returns>Rezultat pretrage</returns>
        [FaultContract(typeof(string))]
        [OperationContract]
        ScoreEntry[] FetchAll();

        /// <summary>
        /// Cita najboljih 10 rezultata sortiranih po vremenu
        /// </summary>
        /// <returns>Rezultat pretrage</returns>
        [FaultContract(typeof(string))]
        [OperationContract]
        ScoreEntry[] FetchTime();

        /// <summary>
        /// Cita najboljih 10 rezultata sortiranih po broju pokusaja
        /// </summary>
        /// <returns>Rezultat pretrage</returns>
        [FaultContract(typeof(string))]
        [OperationContract]
        ScoreEntry[] FetchTries();

        /// <summary>
        /// Vraca trenutno vreme trajanja igre. Racunati i kasnjenje ~PravoVreme =  Vreme + (Primanje - Slanje)/2
        /// </summary>
        /// <returns>Trenutno vreme</returns>
        [OperationContract]
        DateTime SyncTime();
    }
}
