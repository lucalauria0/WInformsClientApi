using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFormUtenteGenerico.Managers
{
    public class UserManager
    {
        public LogService log;
        public DataSet dataSet = new DataSet();
        public ApiHelperService api;
        public UserManager(LogService logger, string url)
        {
            log = logger;
            api = new ApiHelperService(url, log);
            log.Info("UserManager", "Logs ON");
        }
        /// <summary>
        /// SELECT GENERICA
        /// </summary>
        /// <param name="list"></param>
        /// <param name="nome"></param>
        /// <param name="cognome"></param>
        /// <param name="email"></param>
        /// <param name="cf"></param>
        /// <param name="eta"></param>
        /// <returns></returns>
        //public (Errore, DataSet) GetPersoneDatabase(Dictionary<string, List<object>> list)
        //{
        //    string caller = "Manager.PersoneGeiDataSet()";
        //    log.Info("Select", $"ON");
        //    Errore er = null;
        //    List<Persona> lista = new List<Persona>();
        //    try
        //    {
        //        string query = $"SELECT * FROM tbl_Utenti WHERE 1=1 ";
        //        foreach (KeyValuePair<string, List<object>> d in list)
        //        {
        //            if (!d.Value.Any())
        //                continue;
        //            string name = d.Value[0].GetType().Name.ToLower();
        //            log.Debug(caller, $"Name = {name} Query = {query}");
        //            switch (name)
        //            {
        //                case "string":
        //                    List<string> strings = new List<string>();
        //                    d.Value.ForEach(x => strings.Add(x.ToString()));
        //                    query += $"AND {d.Key} IN ({string.Join(",", strings.FindAll(x => !string.IsNullOrEmpty(x)).Select(y => dBUtils.GestioneCampo(y)))})";
        //                    break;
        //                case "int":
        //                    List<int> ints = new List<int>();
        //                    d.Value.ForEach(x => ints.Add(Convert.ToInt32(x)));
        //                    query += $"AND {d.Key} IN ({string.Join(",", ints.Select(y => dBUtils.GestioneCampo(y)))})";
        //                    break;
        //                case "datetime":
        //                    List<DateTime> dt = new List<DateTime>();
        //                    d.Value.ForEach(x => dt.Add(Convert.ToDateTime(x)));
        //                    query += $"AND {d.Key} IN ({string.Join(",", dt.Select(y => dBUtils.GestioneCampo(y)))})";
        //                    break;
        //            }
        //            log.Debug(caller, $"Query = {query}");
        //        }

        //        (er, dataSet) = dBUtils.EseguiQuery(query);

        //        for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
        //        {
        //            DataRow row = dataSet.Tables[0].Rows[i];                                                                                   // MODIFICARE ROW[]
        //            Persona persona = new Persona();
        //            persona.codiceFiscale = row.IsNull("CodiceFiscale") ? string.Empty : row["CodiceFiscale"].ToString();
        //            persona.nome = row.IsNull("Nome") ? string.Empty : row["Nome"].ToString();
        //            persona.cognome = row.IsNull("Cognome") ? string.Empty : row["Cognome"].ToString();
        //            persona.eta = row.IsNull("Eta") ? -999 : Convert.ToInt32(row["Eta"]);
        //            persona.email = row.IsNull("IndirizzoEmail") ? string.Empty : row["IndirizzoEmail"].ToString();
        //            lista.Add(persona);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        er = new Errore(e);
        //        log.Error(caller, er);
        //        return (er, dataSet);
        //    }

        //    log.Info(caller, "OFF");

        //    return (er, dataSet);
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cf"></param>
        /// <returns></returns>
        public async Task<Errore> CheckUser(string cf)
        {
            Errore er = null;
            bool result = true;
            string caller = "Manager, CheckUser()";
            log.Info(caller, "ON");

            try
            {
                Dictionary<string, List<object>> keyValuePairs = new Dictionary<string, List<object>>();
                keyValuePairs.Add("CodiceFiscale", new List<object> { cf });
                List<Persona> personas;
                
                (er, personas) = await api.GetPersone(keyValuePairs);
                log.Debug(caller, $"Persone trovate: {personas.Count}");

                if (personas.Any())
                {
                    er = new Errore("L'Utente è gia registrato.");
                }

            }
            catch (Exception ex)
            {
                er = new Errore("Qualcosa è andato storto... :(");
                log.Error(caller, er);
            }

            log.Info(caller, "OFF");

            return er;
        }
    }
}
