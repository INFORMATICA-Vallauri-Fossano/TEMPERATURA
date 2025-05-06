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
    public class GiornoController
    {
        ADOSQLServer2017 ado;
        public GiornoController(string dbName)
        {
            this.ado = new ADOSQLServer2017(dbName);
        }

        public int getIdByGiorno(string giorno)
        {
            SqlCommand cmd = new SqlCommand("SELECT IDGIORNO FROM GIORNI WHERE GIORNO=@giorno");
            cmd.Parameters.AddWithValue("@giorno",giorno);
            if (ado.EseguiQuery(cmd).Rows.Count == 0) throw new Exception("nessun id corrisponde al seguente giorno");
            else
                return Convert.ToInt32(ado.EseguiQuery(cmd).Rows[0]["idgiorno"]);
        }

        internal int createGiorno(string giorno)
        {
            SqlCommand cmd = new SqlCommand("INSERTO INTO giorni VALUES(@GIORNO);");
            cmd.Parameters.AddWithValue("@GIORNO", giorno.ToUpper());
            ado.EseguiNonQuery(cmd);

            cmd = new SqlCommand("SELECT TOP 1 IDGIORNO FROM GIORNI ORDER BY IDGIORNO desc");
            return Convert.ToInt32(ado.EseguiScalar(cmd));
        }
    }
}
