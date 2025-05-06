using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
//
using ADOSQLServer2017_ns;

namespace NeveServer.Controller
{
    public class TemperatureController
    {
        ADOSQLServer2017 ado;
        GiornoController giornoC;
        CittaController cittaC;

        public TemperatureController(string dbName)
        {
            this.ado = new ADOSQLServer2017(dbName);
            this.giornoC = new GiornoController(dbName);
            this.cittaC = new CittaController(dbName);
        }

        internal string getTemperature(string posto)
        {
            string risp = "";
            SqlCommand cmdChkCitta = new SqlCommand("SELECT COUNT(*) FROM CITTA WHERE @POSTO IN (SELECT citta FROM CITTA)");
            cmdChkCitta.Parameters.AddWithValue("@POSTO", posto);

            if ((int)ado.EseguiScalar(cmdChkCitta) == 0) throw new Exception("Non esiste questa citta nel database");
            string sql = "SELECT giorno, tMin,tMax FROM CITTA C,GIORNI G ,TEMPERATURE T WHERE C.IDCITTA=T.IDCITTA AND T.IDGIORNO=G.IDGIORNO AND CITTA=@CITTA";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@CITTA", posto);

            System.Data.DataTable dt = ado.EseguiQuery(cmd);
            foreach (System.Data.DataRow riga in dt.Rows)
            {
                risp += riga["giorno"].ToString() + " - " + riga["tMin"].ToString() + " - " + riga["tMax"].ToString() + "\r\n";
            }

            return risp;
        }

        internal string insertTemperature(string citta, string giorno, string tmin, string tmax)
        {
            string query = "INSERT INTO TEMPERATURE(IDCITTA,IDGIORNO,TMIN,TMAX) VALUES(@citta,@giorno,@tmin,@tmax)";
            SqlCommand cmd = new SqlCommand(query);
            int idcitta;
            try
            {
                idcitta = cittaC.getIdByCitta(citta);
            }
            catch (Exception ex)
            {
                idcitta=cittaC.createCitta(citta);
            }
            int idgiorno;
            //try
            //{
            //    idgiorno= giornoC.getIdByGiorno(giorno);
            //}
            //catch (Exception ex)
            //{
            //    giornoC.createGiorno(giorno);
            //}
            cmd.Parameters.AddWithValue("@citta",idcitta );
            cmd.Parameters.AddWithValue("@giorno", giornoC.getIdByGiorno(giorno));
            cmd.Parameters.AddWithValue("@tmin", tmin);
            cmd.Parameters.AddWithValue("@tmax", tmax);

            ado.EseguiNonQuery(cmd);

            return getTemperature(citta);
        }
    }
}