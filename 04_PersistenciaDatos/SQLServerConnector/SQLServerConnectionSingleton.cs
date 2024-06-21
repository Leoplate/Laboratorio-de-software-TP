using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace _04_PersistenciaDatos.MySQLConnector
{
    public class SQLServerConnectionSingleton
    {
        private static SQLServerConnectionSingleton instance = null;
        private SqlConnection connection;

        //private SQLServerConnectionSingleton(string server, string catalogo, string seguridad)
        private SQLServerConnectionSingleton()
        {
            //string connectionString = $"Data Source={server};Initial Catalog={catalogo};Integrated Security={seguridad};";
            //string connectionString = "Data Source=DESKTOP-P57E8BL;Initial Catalog=master;Integrated Security=True";

            //connection = new SqlConnection(connectionString);
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CS_AUTOS"].ConnectionString);
            
        }
        

        //public static SQLServerConnectionSingleton Instance
        //    (string server, string catalogo, string seguridad)
        public static SQLServerConnectionSingleton Instance
            ()
        {
            if (instance == null)
            {
                //instance = new SQLServerConnectionSingleton(server, catalogo, seguridad);
                instance = new SQLServerConnectionSingleton();
            }
            return instance;
        }

        public SqlConnection GetConnection()
        {

            
            if (connection.State == System.Data.ConnectionState.Closed || connection.State == System.Data.ConnectionState.Broken)
            {
                connection.Open();
            }
            return connection;
        }

        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}