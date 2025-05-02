using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using ADOSQLServer2017_ns;

namespace NeveServer.Controller
{
    public class clsAltezzeController
    {
        ADOSQLServer2017 ado;
        public clsAltezzeController(string dbName)
        {
            this.ado = new ADOSQLServer2017(dbName);
        }

        internal string getTemperature(string posto)
        {
            string risp = "";
            string sql = "SELECT giorno, tMin,tMax FROM CITTA C,GIORNI G ,TEMPERATURE T WHERE C.IDCITTA=T.IDCITTA AND T.IDGIORNO=G.IDGIORNO AND CITTA=@CITTA";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@CITTA", posto);

            System.Data.DataTable dt = ado.EseguiQuery(cmd);
            foreach(System.Data.DataRow riga in dt.Rows)
            {
                risp += riga["giorno"].ToString() + " - " + riga["tMin"].ToString() + " - " + riga["tMax"].ToString() + "\r\n";
            }   

            return risp;
        }
    }
}
