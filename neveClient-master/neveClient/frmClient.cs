    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace neveClient
{
    public partial class frmClient : Form
    {
        HttpClient client = new HttpClient();
        string serverUrl = "http://localhost:7777/";
        string aCapo = "\r\n";
        public frmClient()
        {
            InitializeComponent();
        }

        private void frmClient_Load(object sender, EventArgs e)
        {
            this.AcceptButton = this.btnInviaMsg; //con enter invia messaggio
        }

        private async void btnInviaMsg_Click(object sender, EventArgs e)
        {
            string log = "";
            string risp = "";
            StringContent msg;
            HttpResponseMessage risposta;
            try
            {
                if (txtMsg.Text == "")
                    MessageBox.Show($"Errore inserire comando");
                else
                {
                    /*
                       COMANDI 
                          1) comandi ---> richiede i comandi disponibili
                          2) elenco ---> richiede l'elenco delle localita
                          3) neve;localita ---> richiede l'altezza neve della localita specificata
                     */
                    //potrei usare JSON
                    msg = new StringContent(txtMsg.Text, Encoding.UTF8, "application/text");
                    txtLog.Text += $"Invio richiesta al server: {txtMsg.Text}" + aCapo;
                    risposta = await client.PostAsync(serverUrl, msg);

                    if (risposta.IsSuccessStatusCode)
                    {
                        risp = await risposta.Content.ReadAsStringAsync();
                        txtLog.Text += $"Risposta dal server: {risp}" + aCapo;
                    }
                    else
                    {
                        txtLog.Text = $"Errore: {risposta.StatusCode}" + aCapo;
                    }
                    txtLog.Text += "\r\n";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
