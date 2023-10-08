
using System.Data;
using Shared_Resources;

namespace TaskFormUtenteGenericoBlazorAppApiWEB
{
    internal class UserManager                      // passare oggetto serilog al manager, o liste di log e facciamo tornare indietro
    {
        public LogService log;
        public LinkedList<Persona> PersonaList = new LinkedList<Persona>();
        public DBService dBUtils;
        public DataSet dataSet = new DataSet();
        public LogService LogUtils;
        private string tableName = "tbl_Utenti";

        //public Manager(string? cs, LogUtils logUtils)
        //{
        //    dBUtils = new DBUtils(string.IsNullOrEmpty(cs) ? string.Empty : cs);
        //    LogUtils = logUtils;
        //}

        public UserManager(string? cs, IConfiguration configuration)
        {
            dBUtils = new DBService(string.IsNullOrEmpty(cs) ? string.Empty : cs);
            log = new LogService(configuration);
        }

        /// <summary>
        /// INSERISCE UN NUOVO UTENTE DENTRO IL DB
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="cognome"></param>
        /// <param name="codiceFiscale"></param>
        /// <param name="eta_tmp"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public Errore InsertUser(string nome, string cognome, string codiceFiscale, int eta_tmp, string email)
        {
            string caller = "Manager.InsertUser()";
            log.Info(caller, "ON");
            int eta = -999;

            Errore er = null;

            try
            {
                log.Debug(caller, $"Eta = {eta_tmp}");
                eta = Convert.ToInt32(eta_tmp);
            }
            catch (Exception ex)
            {

                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("ERRORE FORMATO ETA", eta_tmp.ToString());
                er = new Errore(ex, data);
                log.Error(caller, er);
                return er;
            }

            Persona persona;

            try
            {
                persona = new Persona(Nome: nome, Cognome: cognome, CodiceFiscale: codiceFiscale, Eta: eta_tmp, Email: email);
                PersonaList.AddLast(persona);
                log.Debug(caller, $"Persona = {persona.ToString()}");
            }
            catch (Exception ex)
            {
                er = new Errore(ex);
                log.Error(caller, er);
                return er;
            }


            try
            {

                string query = $"INSERT INTO {tableName} (Nome, Cognome, IndirizzoEmail, Eta, CodiceFiscale) VALUES ('{persona.nome}', '{persona.cognome}', '{persona.email}', {persona.eta}, '{persona.codiceFiscale}');";
                log.Debug(caller, $"Query = {query}");
                (er, dataSet) = dBUtils.EseguiQuery(query);
            }
            catch (Exception ex)
            {
                er = new Errore(ex);
                log.Error(caller, er);
                return er;
            }


            log.Info(caller, "OFF");

            return er;
        }
        /// <summary>
        /// ELIMINA UTENTE SELEZIONATO NELLA LISTBOX CERCANDOLO PER EMAIL, prende in input tableName e il dizionario attributo_db-lista
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Errore Delete(Dictionary<string, List<object>> attributi)
        {
            string caller = "Manager.Delete()";
            log.Info(caller, "ON");
            Errore er = null;

            try
            {
                string query = $"DELETE FROM {tableName} WHERE 1=1";
                if (attributi != null)
                {
                    foreach (KeyValuePair<string, List<object>> elemento in attributi)
                    {

                        if (!elemento.Value.Any())
                            continue;

                        Type tipo = elemento.Value[0].GetType();
                        log.Debug(caller, $"Tipo = {tipo} Query = {query}");
                        switch (tipo.Name.ToLower())
                        {
                            case "string":
                                List<string> strings = new List<string>();
                                elemento.Value.ForEach(x => strings.Add(x.ToString()));
                                query += $" AND {elemento.Key} IN({string.Join(",", strings.FindAll(z => !string.IsNullOrEmpty(z)).Select(x => dBUtils.GestioneCampo(x)))})"; //+ gestione campo
                                break;
                            case "int":
                                List<int> ints = new List<int>();
                                elemento.Value.ForEach(x => ints.Add(Convert.ToInt32(x)));
                                query += $" AND {elemento.Key} IN({string.Join(",", ints.Select(x => dBUtils.GestioneCampo(x)))}) "; //+ gestione campo
                                break;
                            case "datetime":
                                List<DateTime> datetimes = new List<DateTime>();
                                elemento.Value.ForEach(x => datetimes.Add(Convert.ToDateTime(x)));
                                query += $" AND {elemento.Key} IN({string.Join(",", datetimes.Select(x => dBUtils.GestioneCampo(x)))}) "; //+ gestione campo
                                break;
                            default:
                                break;
                        }
                        log.Debug(caller, $"Query = {query}");
                    }
                }

                (er, dataSet) = dBUtils.EseguiQuery(query);
            }
            catch (Exception ex)
            {
                er = new Errore(ex);
                log.Error(caller, er);
                return er;
            }


            log.Info(caller, $"OFF");

            return er;

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
        public (Errore, List<Persona>) GetUsers(Dictionary<string, List<object>> list)
        {
            string caller = "Manager.GetUsers()";
            log.Info(caller, $"ON");
            Errore er = null;
            List<Persona> lista = new List<Persona>();
            try
            {
                string query = $"SELECT * FROM {tableName} WHERE 1=1 ";
                foreach (KeyValuePair<string, List<object>> d in list)
                {
                    if (!d.Value.Any())
                        continue;
                    string name = d.Value[0].GetType().Name.ToLower();
                    log.Debug(caller, $"Name = {name} Query = {query}");
                    switch (name)
                    {
                        case "string":
                            List<string> strings = new List<string>();
                            d.Value.ForEach(x => strings.Add(x.ToString()));
                            query += $"AND {d.Key} IN ({string.Join(",", strings.FindAll(x => !string.IsNullOrEmpty(x)).Select(y => dBUtils.GestioneCampo(y)))})";
                            break;
                        case "int64":
                            List<int> ints = new List<int>();
                            d.Value.ForEach(x => ints.Add(Convert.ToInt32(x)));
                            query += $"AND {d.Key} IN ({string.Join(",", ints.Select(y => dBUtils.GestioneCampo(y)))})";
                            break;
                        case "datetime":
                            List<DateTime> dt = new List<DateTime>();
                            d.Value.ForEach(x => dt.Add(Convert.ToDateTime(x)));
                            query += $"AND {d.Key} IN ({string.Join(",", dt.Select(y => dBUtils.GestioneCampo(y)))})";
                            break;
                    }
                    log.Debug(caller, $"Query = {query}");

                }

                (er, dataSet) = dBUtils.EseguiQuery(query);

                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    DataRow row = dataSet.Tables[0].Rows[i];                                                                                   // MODIFICARE ROW[]
                    Persona persona = new Persona();
                    persona.codiceFiscale = row.IsNull("CodiceFiscale") ? string.Empty : row["CodiceFiscale"].ToString();
                    persona.nome = row.IsNull("Nome") ? string.Empty : row["Nome"].ToString();
                    persona.cognome = row.IsNull("Cognome") ? string.Empty : row["Cognome"].ToString();
                    persona.eta = row.IsNull("Eta") ? -999 : Convert.ToInt32(row["Eta"]);
                    persona.email = row.IsNull("IndirizzoEmail") ? string.Empty : row["IndirizzoEmail"].ToString();
                    lista.Add(persona);
                }
            }
            catch (Exception e)
            {
                er = new Errore(e);
                log.Error(caller, er);
                return (er, lista);
            }

            log.Info(caller, "OFF");

            return (er, lista);
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
        public (Errore, DataSet) GetPersoneDatabase(Dictionary<string, List<object>> list)
        {
            string caller = "Manager.PersoneGeiDataSet()";
            log.Info("Select", $"ON");
            Errore er = null;
            List<Persona> lista = new List<Persona>();
            try
            {
                string query = $"SELECT * FROM tbl_Utenti WHERE 1=1 ";
                foreach (KeyValuePair<string, List<object>> d in list)
                {
                    if (!d.Value.Any())
                        continue;
                    string name = d.Value[0].GetType().Name.ToLower();
                    log.Debug(caller, $"Name = {name} Query = {query}");
                    switch (name)
                    {
                        case "string":
                            List<string> strings = new List<string>();
                            d.Value.ForEach(x => strings.Add(x.ToString()));
                            query += $"AND {d.Key} IN ({string.Join(",", strings.FindAll(x => !string.IsNullOrEmpty(x)).Select(y => dBUtils.GestioneCampo(y)))})";
                            break;
                        case "int":
                            List<int> ints = new List<int>();
                            d.Value.ForEach(x => ints.Add(Convert.ToInt32(x)));
                            query += $"AND {d.Key} IN ({string.Join(",", ints.Select(y => dBUtils.GestioneCampo(y)))})";
                            break;
                        case "datetime":
                            List<DateTime> dt = new List<DateTime>();
                            d.Value.ForEach(x => dt.Add(Convert.ToDateTime(x)));
                            query += $"AND {d.Key} IN ({string.Join(",", dt.Select(y => dBUtils.GestioneCampo(y)))})";
                            break;
                    }
                    log.Debug(caller, $"Query = {query}");

                }

                (er, dataSet) = dBUtils.EseguiQuery(query);

                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    DataRow row = dataSet.Tables[0].Rows[i];                                                                                   // MODIFICARE ROW[]
                    Persona persona = new Persona();
                    persona.codiceFiscale = row.IsNull("CodiceFiscale") ? string.Empty : row["CodiceFiscale"].ToString();
                    persona.nome = row.IsNull("Nome") ? string.Empty : row["Nome"].ToString();
                    persona.cognome = row.IsNull("Cognome") ? string.Empty : row["Cognome"].ToString();
                    persona.eta = row.IsNull("Eta") ? -999 : Convert.ToInt32(row["Eta"]);
                    persona.email = row.IsNull("IndirizzoEmail") ? string.Empty : row["IndirizzoEmail"].ToString();
                    lista.Add(persona);
                }
            }
            catch (Exception e)
            {
                er = new Errore(e);
                log.Error(caller, er);
                return (er, dataSet);
            }

            log.Info(caller, "OFF");

            return (er, dataSet);
        }

        /// <summary>
        /// AGGIORNA UTENTE CON I PARAMETRI IMMESSI NELLE TEXT (TRANNE EMAIL)
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Errore UpdateUser(Persona p)
        {
            string caller = "Manger.UpdateUser()";
            log.Info("UpdateUser", $"ON");
            Errore er = null;

            try
            {
                string query = $"UPDATE {tableName} SET {tableName}.Nome = '{p.nome}', {tableName}.Cognome = '{p.cognome}', {tableName}.Eta = '{p.eta}', {tableName}.IndirizzoEmail = '{p.email}' WHERE {tableName}.CodiceFiscale = '{p.codiceFiscale}';";
                (er, dataSet) = dBUtils.EseguiQuery(query);
                log.Debug(caller, $"Query = {query}");
            }
            catch (Exception ex)
            {
                er = new Errore(ex);
                log.Error(caller, er);
                return er;
            }

            log.Info(caller, $"OFF");

            return er;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cf"></param>
        /// <returns></returns>
        public Errore CheckUser(string cf)
        {
            Errore er = null;
            bool result = true;
            string caller = "Manager, CheckUser()";
            log.Info(caller, "ON");

            try
            {
                Dictionary<string, List<object>> keyValuePairs = new Dictionary<string, List<object>>();
                keyValuePairs.Add("CodiceFiscale", new List<object> { cf });
                List<Persona> personas = new List<Persona>();
                log.Debug(caller, $"Persone trovate: {personas.Count}");

                (er, personas) = GetUsers(keyValuePairs);

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
