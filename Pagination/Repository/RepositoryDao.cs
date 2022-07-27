using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Pagination.Repository
{

    public class RepositoryDao
    {
        SqlConnection _connection;

        public RepositoryDao()
        {
            Init();
        }
        private void Init()
        {
            _connection = new SqlConnection(GetConnectionString());
        }
        private void OpenConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
                _connection.Close();
            _connection.Open();
        }
        private void CloseConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
                this._connection.Close();
        }
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DBConnString"] != null ? ConfigurationManager.ConnectionStrings["DBConnString"].ConnectionString : "";
        }
        public System.Data.DataSet ExecuteDataset(string sql)
        {
            var ds = new System.Data.DataSet();
            var cmd = new System.Data.SqlClient.SqlCommand(sql, _connection);
            cmd.CommandTimeout = 120;
            System.Data.SqlClient.SqlDataAdapter da;

            try
            {
                OpenConnection();
                //da = new SqlDataAdapter(sql, _connection);
                da = new System.Data.SqlClient.SqlDataAdapter(cmd);
                da.Fill(ds);
                da.Dispose();
                CloseConnection();
            }
            catch (Exception ex)
            {
                //throw ex;

                DataTable objDt1 = new DataTable();
                objDt1.Columns.Add("Code");
                objDt1.Columns.Add("Message");
                objDt1.Columns.Add("id");
                objDt1.Rows.Add(1, ConfigurationManager.AppSettings["phase"] != null && ConfigurationManager.AppSettings["phase"].ToString().ToUpper() == "DEVELOPMENT" ? ex.Message : "Something went wrong.", "");
                ds.Tables.Add(objDt1);
            }
            finally
            {
                da = null;
                CloseConnection();
            }
            return ds;
        }
        public System.Data.DataTable ExecuteDataTable(string sql)
        {
            using (var ds = ExecuteDataset(sql))
            {
                if (ds == null || ds.Tables.Count == 0)
                    return null;

                if (ds.Tables[0].Rows.Count == 0)
                    return null;

                return ds.Tables[0];
            }
        }
        public System.Data.DataRow ExecuteDataRow(string sql)
        {
            using (var ds = ExecuteDataset(sql))
            {
                if (ds == null || ds.Tables.Count == 0)
                    return null;

                if (ds.Tables[0].Rows.Count == 0)
                    return null;

                return ds.Tables[0].Rows[0];
            }
        }
        
    }
}