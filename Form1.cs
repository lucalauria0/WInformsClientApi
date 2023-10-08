using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Serilog;
using Serilog.Events;
using TaskFormUtenteGenerico.Managers;
using FastMember;
using System.Runtime.CompilerServices;

namespace TaskFormUtenteGenerico
{
    public partial class Form1 : Form
    {
        Errore er = null;
        List<Persona> personas;
        ApiHelperService api;
        UserManager manager;
        DataSet dataSet = new DataSet();
        LogService log;

        public Form1()                                      //placeholde
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // cs = @"Data Source=localhost;Initial Catalog=TaskFormUtenteGenerico;Persist Security Info=True;User ID=formazione;Password=admin;TrustServerCertificate=true";
            // Istanzio un nuovo oggetto manager a cui passo la connection string il nome del db
            
            LoggerConfiguration loggerConfiguration = new LoggerConfiguration().ReadFrom.AppSettings();
            log = new LogService(loggerConfiguration);
            api = new ApiHelperService(@"https://localhost:7243/", log);
            manager = new UserManager(log, @"https://localhost:7243/");
            RechargeAllBoxes();
        }
        private async void btn_Inserisci_Click(object sender, EventArgs e)
        {
            if(CheckUserlBoxes())
            {
                await manager.CheckUser(txtBox_CodiceFiscale.Text);
                if (er != null)
                {
                    MessageBox.Show(er.Messaggio);
                    return;
                }

                //DBManager.InsertUserMySQLInjection(nome: txtBox_Nome.Text, cognome: txtBox_Cognome.Text, codiceFiscale: txtBox_CodiceFiscale.Text, eta: txtBox_Eta.Text, email: txtBox_IndirizzoEmail.Text);
                
                api.InsertPersona(new Persona(Nome: txtBox_Nome.Text, Cognome: txtBox_Cognome.Text, CodiceFiscale: txtBox_CodiceFiscale.Text, Eta: Convert.ToInt32(txtBox_Eta.Text), Email: txtBox_IndirizzoEmail.Text));
                
            }
            RechargeAllBoxes();
        }
        private void btn_Modifica_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona(Nome: txtBox_Nome.Text, Cognome: txtBox_Cognome.Text, CodiceFiscale: txtBox_CodiceFiscale.Text, Email: txtBox_IndirizzoEmail.Text, Eta: Convert.ToInt32(txtBox_Eta.Text));
            api.UpdatePersona(persona);
            RechargeAllBoxes();
        }
        private void btn_Elimina_Click(object sender, EventArgs e)
        {
            // Voglio eliminare per email
            Dictionary<string, List<object>> attributi = new Dictionary<string, List<object>>();
            attributi.Add("CodiceFiscale", new List<object>() { txtBox_CodiceFiscale.Text.ToString() }); // In questo caso una sola email

            //// Creo una lista degli attributi nel db che voglio toccare 
            //List<Dictionary<string, List<object>>> attributi_db = new List<Dictionary<string, List<object>>> { email };

            // Richiamo la Delete passando gli attributi interessati
            //DBManager.Delete(attributi);
            api.Delete(attributi);
            MessageBox.Show("Eliminato correttamente.");

            RechargeAllBoxes();
        }
        private async void listBox_TutteLePersone_SelectedIndexChanged(object sender, EventArgs e)
        {
            er = null;
            try
            {
                Persona p = personas.Find(x => x.codiceFiscale.Equals(listBox_TutteLePersone.SelectedItem.ToString(), StringComparison.OrdinalIgnoreCase));
                LoadUserDetails(p);
                //var comparer = StringComparer.OrdinalIgnoreCase;
                //Dictionary<string, List<string>> infoPlansWork = new Dictionary<string, List<string>>(comparer);
            }
            catch (Exception ex)
            {
                er = new Errore(ex);
                MessageBox.Show(er.Dettagli);
            }
        }
        private void dgw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dgw.Rows[e.RowIndex];
                txtBox_Nome.Text = r.Cells["nome"].Value.ToString();
                txtBox_Cognome.Text = r.Cells["cognome"].Value.ToString();
                txtBox_IndirizzoEmail.Text = r.Cells["email"].Value.ToString();
                txtBox_Eta.Text = r.Cells["eta"].Value.ToString();
                txtBox_CodiceFiscale.Text = r.Cells["codicefiscale"].Value.ToString();
            }
        }

        /// <summary>
        /// POPOLA LE TEXTBOX CON I DETTAGLI DELL'UTENTE 
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="cognome"></param>
        /// <param name="email"></param>
        /// <param name="cf"></param>
        /// <param name="eta"></param>
        /// <returns></returns>
        public void LoadUserDetails(Persona persona)
        {
            er = null;

            try
            {

                txtBox_Nome.Text = persona.nome;
                txtBox_Cognome.Text = persona.cognome;
                txtBox_IndirizzoEmail.Text = persona.email;
                txtBox_Eta.Text = persona.eta.ToString();
                txtBox_CodiceFiscale.Text = persona.codiceFiscale;

               
            }
            catch (Exception e)
            {
                er = new Errore(e);
                MessageBox.Show(er.Dettagli);
            }

        }
        /// <summary>
        /// RICARICA LA LISTBOX E LA TXTBOX                                                     NB: QUI HO USATO LOGS DA LOGUTILS
        /// </summary>
        /// <param name="lbAll"></param>
        /// <param name="txtAll"></param>
        /// <returns></returns>
        public async void RechargeAllBoxes()
        {
            //System.Threading.Thread.Sleep(1000);
            (er, personas) = await api.GetPersone(new Dictionary<string, List<object>>());
            //(er, dataSet) = await api.GetPersoneDataset(new Dictionary<string, List<object>>());

            if (er != null)
            {
                MessageBox.Show(er.Dettagli);
                return;
            }
            if (!personas.Any())
            {
                return;
            }
            
            LoadText(personas);
            LoadList(personas);
            LoadTable(personas);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="personas"></param>
        public void LoadText(List<Persona> personas)
        {
            txtBox_TutteLePersone.Text = "";
            for (int i = 0; i < personas.Count; i++)
            {
                txtBox_TutteLePersone.Text += personas[i].ToString() + "\r\n";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="personas"></param>
        public void LoadList(List<Persona> personas)
        {
                listBox_TutteLePersone.Items.Clear();

                for (int i = 0; i < personas.Count; i++)
                {                                                                                               //datasource carica tutta la persona ma se voglio solamente il cf a listbox.selectedItem come faccio?
                    listBox_TutteLePersone.Items.Add(personas[i].codiceFiscale);
                }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        //public async void LoadTable(DataSet data = null)
        //{
        //    Errore er = null;
        //    try
        //    {
        //        dgw.DataSource = data.Tables[0];
        //    }
        //    catch (Exception ex) 
        //    {
        //        MessageBox.Show(new Errore(ex).Dettagli);
        //    }
        //}
        public async void LoadTable(List<Persona> personas)
        {
            DataTable table = new DataTable();
            using (var reader = ObjectReader.Create(personas))
            {
                table.Load(reader);
            }
            dgw.DataSource = table;
        }
        public bool CheckUserlBoxes()
        {
            bool doChecks = true;
            doChecks = isInputOK(textBox: txtBox_CodiceFiscale, textName: "Codice Fiscale", maxLenght: 16) && doChecks;
            doChecks = isInputOK(textBox: txtBox_Nome, textName: "Nome");
            doChecks = isInputOK(textBox: txtBox_Cognome, textName: "Cognome");
            doChecks = isInputOK(textBox: txtBox_Eta, range1: 18, range2: 99, textName: "Età");
            doChecks = isInputOK(textBox: txtBox_IndirizzoEmail, toCheckStrings: new List<string>() { "@", "alten.it" }, textName: "Indirizzo Email");
            return doChecks;
        }
        public bool isInputOK(TextBox textBox, List<string> toCheckStrings = null, string textName = null, int range1 = -1, int range2 = -1, int maxLenght = -1) 
        {
            if (string.IsNullOrEmpty(textBox.Text) || string.IsNullOrWhiteSpace(textBox.Text))  // Controllo se è vuoto
            {
                MessageBox.Show($"il campo {textName} non può essere vuoto");
                return false;
            }
            if (range1 != -1 && range2 != -1)       // Controllo range di intero
            {
                int integer = Convert.ToInt32(textBox.Text);
                if (!(integer >= range1 && integer <= range2))
                {
                    MessageBox.Show($"il campo {textName} deve essere maggiore di {range1} e minore di {range2}");
                    return false;
                }
            }
            if (maxLenght != -1) // Controllo la lunghezza massima
            {
                if (textBox.Text.Length > maxLenght)
                {
                    MessageBox.Show($"il campo {textName} deve essere di massimo {maxLenght} caratteri");
                    return false;
                }
            }
            if (toCheckStrings != null)         // Controllo che ci sono delle aprole obbligatorie
            {
                foreach (string s in toCheckStrings) 
                { 
                    if(!textBox.Text.Contains(s))
                    {
                        MessageBox.Show($"il campo {textName} deve contenere almeno un '{s}'");
                        return false;
                    }
                }

            }
            
            return true;
        }

        private void txtBox_TutteLePersone_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
