using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Data;
using System.Data.SqlClient;
//using System.Windows.Forms;

namespace ADOSQLServer2017_ns
{
    class ADOSQLServer2017
    {
        private SqlConnection cn;
        //
        //public ADOSQLServer2015()
        //{ }
        /// <summary>
        /// Classe di accesso a DB SQLServer
        /// </summary>
        /// <param name="dbName">Nome del DB</param>
        public ADOSQLServer2017(string dbName)
        {
            impostaConnessione(dbName);
        }
        private void impostaConnessione(string dbName)
        {
            string cnString;
            try
            {
                //cnString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + "\\" + dbName + ";Integrated Security=True;Connect Timeout=30";
                cnString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + dbName + ";Integrated Security=True;Connect Timeout=30";
                cn = new SqlConnection();
                cn.ConnectionString = cnString;
                cn.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Esegue una query che ritorna un dataTable
        /// </summary>
        /// <param name="cmd">Comando Query</param>
        /// <returns>dataTable</returns>
        public DataTable EseguiQuery(SqlCommand cmd)
        {
            SqlDataAdapter adp;
            cmd.Connection = cn;
            DataTable dt = new DataTable();
            adp = new SqlDataAdapter(cmd);
            try
            {
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
    }
            return dt;
        }
        //overload
        /// <summary>
        /// Esegue una query che ritorna un dataTable e popola una dataGridView
        /// </summary>
        /// <param name="cmd">Comando Query</param>
        /// <param name="dgv">dataGridView</param>
        /// <returns>dataTable</returns>
    //    public DataTable EseguiQuery(SqlCommand cmd, DataGridView dgv)
    //    {
    //        SqlDataAdapter adp;
    //        cmd.Connection = cn;
    //        DataTable dt = new DataTable();
    //        adp = new SqlDataAdapter(cmd);
    //        try
    //        {
    //            adp.Fill(dt);
    //            dgv.DataSource = dt;
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception(ex.Message);
    //}
    //        return dt;
    //    }
        /// <summary>
        /// Esegue Query che non ritornano dataTable
        /// </summary>
        /// <param name="cmd">Comando Query</param>
        /// <returns>Numero di record modificati</returns>
        public int EseguiNonQuery(SqlCommand cmd)
        {
            int ris = -1;
            cmd.Connection = cn;
            try
            {
                ris = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ris;
        }
        /// <summary>
        /// Esegue Query che non ritornano un singolo valore
        /// </summary>
        /// <param name="cmd">Comando Query</param>
        /// <returns>Valore</returns>
        public object EseguiScalar(SqlCommand cmd)
        {
            object ris = -1;
            cmd.Connection = cn;
            try
            {
                ris = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ris;
        }
    }
}
