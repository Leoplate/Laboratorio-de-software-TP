using _03_Dominio;
using _03_Dominio.Repositorios;
using System.Data;
using System.Data.SqlClient;

namespace _04_PersistenciaDatos
{
    public class AutoRepositorioMemoriaSQLServer : IAutoRepositorio
    {
        
        
        
        List<Auto> BaseAutos = new List<Auto>();
       



       
        

        
        
        



        public List<Auto> Listar()
        {
            return this.BaseAutos;
        }

        public void Grabar(Auto auto)
        {

             
            string connectionString = "Data Source= . ;Initial Catalog=dbo;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            
            connection.Open();
          
            //BaseAuto.Connect();

            //this.BaseAuto.Add(auto);
        }
    }
}
