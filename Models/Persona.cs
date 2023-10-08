using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFormUtenteGenerico
{
    public class Persona
    {
        /// <summary>
        /// Nome Utente
        /// </summary>
        public string nome;
        /// <summary>
        /// Cognome
        /// </summary>
        public string cognome; 
        /// <summary>
        /// Codice Fiscale
        /// </summary>
        public string codiceFiscale;
        /// <summary>
        /// Età
        /// </summary>
        public int eta;
        /// <summary>
        /// Email
        /// </summary>
        public string email;
        public Persona(string Nome, string Cognome, string CodiceFiscale, int Eta, string Email) 
        {
            email = Email;
            nome = Nome;
            cognome = Cognome;
            codiceFiscale = CodiceFiscale;
            eta = Eta;
        }

        public Persona()
        {
            email = string.Empty;
            nome = string.Empty;
            cognome = string.Empty;
            codiceFiscale = string.Empty;
            eta = -999;
        }

        public override string ToString()
        {
            return $"{nome} {cognome} {codiceFiscale} {eta} {email}";
        }
    }
}
