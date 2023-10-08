
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shared_Resources;

namespace TaskFormUtenteGenericoBlazorAppApiWEB
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IConfiguration _configuration;
        UserManager manager;

        public UserController(IConfiguration configuration)
        {
            //logUtils = (log==null) ? new LogUtils(configuration) : log;

            _configuration = configuration;
            manager = new UserManager(configuration.GetConnectionString("cnn"), configuration);
            //_configuration.GetValue<string>("");
        }

        [HttpPost]
        [Route("GetUsers")]
        public Tuple<Errore, List<Persona>> GetUsers([FromBody] object request)
        {
            
            Errore er = null;
            List<Persona> persone = new List<Persona>();
            string json = string.Empty;

            try
            {
                json = request.ToString() ?? string.Empty;
                WebBox box = JsonConvert.DeserializeObject<WebBox>(json) ?? new WebBox();
                (er, persone) = manager.GetUsers(box.Attributi);
            }
            catch (Exception ex)
            {
                Dictionary<string, string> jsonDic = new Dictionary<string, string>();
                jsonDic.Add("json", json);
                er = new Errore(ex, jsonDic);
            }

            return Tuple.Create(er, persone);
        }

        [HttpPost]
        [Route("UpdateUser")]
        public Errore UpdateUser([FromBody] object request)
        {

            Errore? er = null;
            string json = string.Empty;
            Persona p;

            try
            {
                json = request.ToString() ?? string.Empty;
                WebBox box = JsonConvert.DeserializeObject<WebBox>(json) ?? new WebBox();
                er = manager.UpdateUser(box.Persona);
            }
            catch (Exception ex)
            {
                Dictionary<string, string> jsonDic = new Dictionary<string, string>();
                jsonDic.Add("json", json);
                er = new Errore(ex, jsonDic);
            }

            return er;
        }

        [HttpPost]
        [Route("Delete")]
        public Errore Delete([FromBody] object request)
        {

            Errore er = null;
            string json = request.ToString() ?? string.Empty;

            try
            {
                WebBox box = JsonConvert.DeserializeObject<WebBox>(json) ?? new WebBox();
                (er) = manager.Delete(box.Attributi);
            }
            catch (Exception ex)
            {
                Dictionary<string, string> jsonDic = new Dictionary<string, string>();
                jsonDic.Add("json", json);
                er = new Errore(ex, jsonDic);
            }

            return er;
        }

        [HttpPost]
        [Route("InsertUser")]
        public Errore InsertUser([FromBody] object request)
        {
            Errore er = null;
            string json = request.ToString() ?? string.Empty;

            try
            {

                WebBox box = JsonConvert.DeserializeObject<WebBox>(json) ?? new WebBox();
                Persona p = box.Persona ?? new Persona();
                er = manager.InsertUser(p.nome, p.cognome, p.codiceFiscale, p.eta, p.email);
            }
            catch (Exception e)
            {
                Dictionary<string, string> jsonDic = new Dictionary<string, string>();
                jsonDic.Add("json", json);
                er = new Errore(e, jsonDic);
            }

            return er;
        }

    }
}
