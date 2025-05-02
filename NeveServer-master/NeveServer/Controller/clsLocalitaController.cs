using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using ADOSQLServer2017_ns;

namespace NeveServer.Controller
{
    public class clsLocalitaController
    {
        ADOSQLServer2017 ado;
        public clsLocalitaController(string dbName)
        {
            this.ado = new ADOSQLServer2017(dbName);
        }

        public string getAllLocalita()
        {
            string localita = "";
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT citta FROM Citta";
            dt = ado.EseguiQuery(cmd);
            if (dt.Rows.Count == 0)
            {
                localita = "Nessuna Localita'";
            }
            else
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    localita += "\r\n" + dt.Rows[i].ItemArray[0].ToString();
                }
            return localita;
        }
    }
}
