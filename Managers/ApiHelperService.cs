using System.Net;
using System.Text.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using TaskFormUtenteGenerico;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.Windows.Forms;
using Serilog;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Data;

namespace TaskFormUtenteGenerico
{
    public class ApiHelperService
    {
        public string baseUrl = string.Empty;
        public LogService log;
        static HttpClient client = new HttpClient();

        public ApiHelperService(string urlWebApi, LogService logger)
        {
            baseUrl = urlWebApi;
            log = logger;

            log.Info("ApiHelper", "Logs ON");
        }

        public async Task<string> HandleCLient(WebBox box, string destinationUrl, string nomeController, string nomeMetodo)
        {
            string risultato = string.Empty;
            try
            {
                

                HttpClientHandler handler = new HttpClientHandler();
                handler.UseDefaultCredentials = true;

                using (HttpClient client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri(destinationUrl);


                    HttpResponseMessage response = await client.PostAsJsonAsync($"{nomeController}/{nomeMetodo}", JsonConvert.SerializeObject(box));
                    response.EnsureSuccessStatusCode();

                    risultato = await response.Content.ReadAsStringAsync();
                }

            } 
            catch (Exception ex)
            {
                log.Error("HandleClient", new Errore(ex));
                
            }

            return risultato;
        }

        public async Task<(Errore, List<Persona>)> GetPersone(Dictionary<string, List<object>> attributi)
        {
            
            Errore er = null;
            List<Persona> retVal = new List<Persona>();
            string caller = "ApiHelper.GetPersone()";

            try
            {
                WebBox box = new WebBox { Attributi = attributi };
                box.Parameters = new Dictionary<string, string> { { "attributi", JsonConvert.SerializeObject(box.Attributi) } };

                //WebReq req = WebRequest.Create($"{baseUrl}/api/PersonaApi/GetPersona");
             

                string result = await HandleCLient(box, baseUrl, "api/PersonaApi", "GetPersona");
                log.Debug(caller, $"Box.Parameters = {JsonConvert.SerializeObject(box.Attributi).ToString()}");
                log.Debug(caller, $"Result = {result}");
                (er, retVal) = JsonConvert.DeserializeObject <(Errore, List<Persona>)>(result, new JsonSerializerSettings() { ObjectCreationHandling = ObjectCreationHandling.Replace});
            }
            catch (Exception ex)
            {
                er = new Errore(ex);
                return (er, retVal);
            }
            return (er, retVal);
        }

        //public async Task<(Errore, DataSet)> GetPersoneDataset(Dictionary<string, List<object>> attributi)
        //{

        //    Errore er = null;
        //    DataSet retVal = new DataSet();
        //    string caller = "ApiHelper.GetPersoneDataset()";

        //    try
        //    {
        //        WebBox box = new WebBox { Attributi = attributi };
        //        box.Parameters = new Dictionary<string, string> { { "attributi", JsonConvert.SerializeObject(box.Attributi) } };
        //        log.Debug(caller, $"Box.Parameters = {box.Parameters.ToString()}");
        //        var result = await g.HandleCLient(box, @"https://localhost:7243/", "api/PersonaApi", "GetPersonaDataset");
                
        //        log.Debug(caller, $"Result = {result}");
        //        (er, retVal) = JsonConvert.DeserializeObject<(Errore, DataSet)>(result, new JsonSerializerSettings() { ObjectCreationHandling = ObjectCreationHandling.Replace });
        //    }
        //    catch (Exception ex)
        //    {
        //        er = new Errore(ex);
        //        return (er, retVal);
        //    }
        //    return (er, retVal);
        //}

        public async Task<Errore> Delete(Dictionary<string, List<object>> attributi)
        {

            Errore er = null;
            string caller = "ApiHelper.Delete()";

            try
            {
                WebBox box = new WebBox { Attributi = attributi };
                box.Parameters = new Dictionary<string, string> { { "attributi", JsonConvert.SerializeObject(box.Attributi) } };


                string result = await HandleCLient(box, baseUrl, "api/PersonaApi", "Delete");
                log.Debug(caller, $"Box.Parameters = {box.Parameters.ToString()}");
                log.Debug(caller, $"Result = {result}");
                (er) = JsonConvert.DeserializeObject<Errore>(result, new JsonSerializerSettings() { ObjectCreationHandling = ObjectCreationHandling.Replace });
            }
            catch (Exception ex)
            {
                er = new Errore(ex);
                return (er);
            }
            return (er);
        }

        public async Task<Errore> InsertPersona(Persona p)
        {
            Errore er = null;
            string caller = "ApiHelper.InsertPersona()";
           try
            {

                log.Debug(caller, $"Persona = {p.ToString()}");
                WebBox box = new WebBox { Persona = p };
                box.Parameters = new Dictionary<string, string> { { "persona", JsonConvert.SerializeObject(box.Persona) } };

                string result = await HandleCLient(box, baseUrl, "api/PersonaApi", "InsertPersona");
                log.Debug(caller, $"Box = {box.Persona.ToString()}");
                log.Debug(caller, $"Box.Parameters = {box.Parameters.ToString()}");
                log.Debug(caller, $"Result = {result}");
            }
            catch (Exception e)
            {
                er = new Errore(e);
                MessageBox.Show($"{er.Dettagli}");
                log.Error(caller, er);
                return er;
            }
            return er;

        }

        public async Task<Errore> UpdatePersona(Persona p)
        {
            Errore er = null;
            string caller = "ApiHelper.UpdatePersona()";
            try
            {

                log.Debug(caller, $"Persona = {p.ToString()}");
                WebBox box = new WebBox { Persona = p };
                box.Parameters = new Dictionary<string, string> { { "persona", JsonConvert.SerializeObject(box.Persona) } };

                string result = await HandleCLient(box, @"https://localhost:7243/", "api/PersonaApi", "UpdatePersona");
                log.Debug(caller, $"Box = {box.Persona.ToString()}");
                log.Debug(caller, $"Box.Parameters = {box.Parameters.ToString()}");
                log.Debug(caller, $"Result = {result}");
            }
            catch (Exception e)
            {
                er = new Errore(e);
                MessageBox.Show($"{er.Dettagli}");
                log.Error(caller, er);
                return er;
            }
            return er;

        }

    }
}
