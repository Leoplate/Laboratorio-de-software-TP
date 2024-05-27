using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_PersistenciaDatos
{
    
    
        public class Database
        {
            private SqlConnection connection;

            public void Connect()
            {
            //@"Data Source=miServidorSQL;Initial Catalog=miBaseDeDatos;Integrated Security=True";
            //string connectionString = "Data Source=(.);Initial Catalog=(dbo.Auto);Integrated Security=True";
            //SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=dbo;Integrated Security=True");
                connection.Open();
            }

            public void Disconnect()
            {
                connection.Close();
            }
        }

    }

