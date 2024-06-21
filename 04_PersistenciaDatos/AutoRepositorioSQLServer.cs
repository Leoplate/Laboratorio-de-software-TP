
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using _03_Dominio.Repositorios;
using _03_Dominio;
using _04_PersistenciaDatos.MySQLConnector;
using _03_Dominio.ValueObject;

namespace _04_PersistenciaDatos
{
    public class AutoRepositorioSQL : IAutoRepositorio
    {
        private SqlConnection connection;

        public AutoRepositorioSQL()
        {
            


            SQLServerConnectionSingleton dbSingleton = SQLServerConnectionSingleton.Instance(
                
            );
            this.connection = dbSingleton.GetConnection();
        }

        public void Grabar(Auto auto)
        {
            



                using (SqlCommand comando = new SqlCommand(
                @"INSERT INTO Autos (id, patente, capacidad, precioKm, disponible) VALUES (@id, @patente, @capacidad, @precioKm, @disponible)",
                this.connection
            ))
            {
                

                

                comando.Parameters.AddWithValue("@id", auto.Id());
                comando.Parameters.AddWithValue("@patente", auto.Patente());
                comando.Parameters.AddWithValue("@capacidad", auto.Capacidad());
                comando.Parameters.AddWithValue("@precioKm", auto.PrecioKm());
                comando.Parameters.AddWithValue("@disponible", auto.Disponible());
                



                comando.ExecuteNonQuery();
            }
        }

        

        public List<Auto> Listar()
        {
            List<Auto> autos = new List<Auto>();
            using (SqlCommand command = new SqlCommand(
                "SELECT id, patente, capacidad, precioKm, disponible FROM Autos  ",
                this.connection
            ))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Guid id = reader.GetGuid(0);
                        string patente = reader.GetString(1);
                        int capacidad = reader.GetInt32(2);
                        int precioKm = reader.GetInt32(3);
                        bool disponible = reader.GetBoolean(4);

                        Auto auto = new Auto(id, patente, capacidad, precioKm, disponible);
                        autos.Add(auto);
                    }
                }
            }

            return autos;
        }



        public void Eliminar(Auto auto)
        {
            using (SqlCommand comando = new SqlCommand(
                "DELETE FROM Autos WHERE patente = @patente ",
                 
                this.connection
            ))
            {




                comando.Parameters.AddWithValue("@id", auto.Id());
                comando.Parameters.AddWithValue("@patente", auto.Patente());
                comando.Parameters.AddWithValue("@capacidad", auto.Capacidad());
                comando.Parameters.AddWithValue("@precioKm", auto.PrecioKm());
                comando.Parameters.AddWithValue("@disponible", auto.Disponible());




                comando.ExecuteNonQuery();
            }
        } 
            public void Actualizar(Auto auto)
            {
                using (SqlCommand comando = new SqlCommand(

                     @"UPDATE Autos SET patente = @patente, capacidad = @capacidad, precioKm = @precioKm, disponible = @disponible WHERE patente = @patente  ",
                    this.connection
                ))
                {




                    comando.Parameters.AddWithValue("@id", auto.Id());
                    comando.Parameters.AddWithValue("@patente", auto.Patente());
                    comando.Parameters.AddWithValue("@capacidad", auto.Capacidad());
                    comando.Parameters.AddWithValue("@precioKm", auto.PrecioKm());
                    comando.Parameters.AddWithValue("@disponible", auto.Disponible());




                    comando.ExecuteNonQuery();
                }

            }










    }
}
