using NeveServer.Controller;
using NeveServer.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace NeveServer
{
    internal class Program
    {
        //impostare NON Copiare nelle property DB
        //impostare azioni di compilazione = CONTENUTO per le property DB
        static string dbName = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).Parent.Parent.FullName.ToString() + @"\App_Data\Temperature.mdf";
        static clsAltezzeController altezze;
        static clsLocalitaController localita;
        //
        static string address = "http://localhost:7777/";
        static HttpListener listener;
        static void Main(string[] args)
        {
            Console.WriteLine(dbName);
            string msg = "";
            string risp = "";
            byte[] buffer;
            altezze = new clsAltezzeController(dbName);
            localita = new clsLocalitaController(dbName);
            //
            listener = new HttpListener();
            HttpListenerContext context;
            listener.Prefixes.Add(address);
            listener.Start();
            Console.WriteLine("Server in ascolto su: " + address);
            //ciclo in attesa di richieste
            try
            {
                while (true)
                {
                    context = listener.GetContext();
                    buffer = new byte[context.Request.ContentLength64];
                    context.Request.InputStream.Read(buffer, 0, buffer.Length);
                    msg = Encoding.UTF8.GetString(buffer);

                    //N.B. potrei ricevere ed inviare JSON
                    Console.WriteLine("Messaggio ricevuto: " + msg);
                    risp = elaboraRichiesta(msg);
                    Console.WriteLine("Risposta: " + risp);

                    buffer = Encoding.UTF8.GetBytes(risp);
                    context.Response.ContentType = "application/text";
                    context.Response.ContentLength64 = buffer.Length;
                    context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                    context.Response.OutputStream.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRORE: {ex.Message}");
            }
            Console.ReadKey();
        }

        private static string elaboraRichiesta(string msg)
        {
            string aCapo = "\r\n";
            string risp = "";
            string[] comando = msg.Split(';');
            switch (comando[0].ToLower())
            {
                case "comandi":
                    risp = "comandi;elenco;vedi<città>";
                    break;
                case "elenco":
                    risp = localita.getAllLocalita();
                    break;
                case "vedi":
                    risp=aCapo+ altezze.getTemperature(comando[1]);
                    break;
                default:
                    risp = "Comando errato";
                    break;
            }
            return risp;
        }
    }
}
