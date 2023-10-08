using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;

namespace TaskFormUtenteGenerico
{
    public class WebBox
    {
        public Dictionary<string, string> Parameters { get; set; }
        public Persona Persona { get; set; }
        public Dictionary<string, List<object>> Attributi { get; set; }
        public WebBox(Dictionary<string, string> keyValuePairs) 
        {
           Parameters = keyValuePairs;
        }

        public WebBox()
        {

        }
    }
}
