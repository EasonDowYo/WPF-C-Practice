using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace SQL_Template
{
    public class SQLClass
    {
        private SqlConnection SqlConn;
        private SqlCommand SqlCmd;
        private SqlConnectionStringBuilder ConnStrBuilder = new SqlConnectionStringBuilder();
        public String SqlString = "";
        public SQLClass()
        {
            Connect();
        }
        private void Connect()
        {
            ConnStrBuilder.DataSource = "LAPTOP-0G73EUQ6\\TEW_SQLEXPRESS";
            ConnStrBuilder.UserID = "Eason";
            ConnStrBuilder.Password = "1111";
            ConnStrBuilder.InitialCatalog = "Spend_db";
            try
            {
                SqlConn = new SqlConnection(ConnStrBuilder.ConnectionString);
                
                SqlConn.Open();
                if (SqlConn.State != ConnectionState.Open)
                    Console.WriteLine("Connect MSSQL open failed");


            }
            catch(SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public DataTable DoQuery(string SqlStr)
        {
            DataTable QueryResult = new DataTable();
            SqlString = SqlStr;
            SqlCmd = new SqlCommand(SqlStr, SqlConn);

            QueryResult.Load(SqlCmd.ExecuteReader());


            return QueryResult;
        }
    }
}
