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
    public class CittaController
    {
        ADOSQLServer2017 ado;
        public CittaController(string dbName)
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
        public int getIdByCitta(string citta)
        {
            SqlCommand cmd = new SqlCommand("SELECT idCITTA FROM CITTA WHERE CITTA=@citta");
            cmd.Parameters.AddWithValue("@citta", citta);
            if (ado.EseguiQuery(cmd).Rows.Count == 0) throw new Exception("nessun id corrisponde alla seguente citta");
            else
            return Convert.ToInt32(ado.EseguiQuery(cmd).Rows[0]["idcitta"]);
        }
        /// <summary>
        /// il metodo ritorna l'id del giorno
        /// </summary>
        /// <param name="citta"></param>
        /// <returns></returns>
        internal int createCitta(string citta)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO CITTA(CITTA) VALUES(@CITTA);");
            cmd.Parameters.AddWithValue("@CITTA", citta.ToUpper());
            ado.EseguiNonQuery(cmd);

            cmd = new SqlCommand("SELECT TOP 1 idCitta FROM CITTA ORDER BY idCitta desc");
            return Convert.ToInt32(ado.EseguiScalar(cmd));
        }
    }
}
