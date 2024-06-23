using _03_Dominio;
using _03_Dominio.Repositorios;
using System.Runtime.Intrinsics.X86;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Bson;
using MongoDB.Driver.Core.Configuration;
using System.Configuration;
using MongoDB.Bson.Serialization.Attributes;
using _02_Aplicacion.DTO;

namespace _04_PersistenciaDatos
{

    



    public class AutoRepositorioMongoDB : IAutoRepositorio
    {

        private readonly IMongoCollection<AutoAux> _autos;



        public AutoRepositorioMongoDB()
        {

            var connectionStringFinal = ConfigurationManager.ConnectionStrings["CS_AUTOS_MONGO"].ConnectionString.Replace("&amp;","&");

            //var connectionString = "mongodb+srv://benjamonben:Charito58@cluster0.z3fb91t.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
            //var client = new MongoClient(ConfigurationManager.ConnectionStrings["CS_AUTOS_MONGO"].ConnectionString);
            var client = new MongoClient(connectionStringFinal);
            var database = client.GetDatabase("DBAutos");
             _autos = database.GetCollection<AutoAux>("Autos");
        }


        public List<Auto> Listar()
        {
            
            List<AutoAux> lista = new List<AutoAux>();
            List<Auto> lista2 = new List<Auto>();
            var autos = _autos.Find(_ => true).ToList();
            
            foreach(var auto in autos)
            {
                lista2.Add(new Auto(auto.id,auto.Patente,auto.Capacidad,auto.PrecioKm,auto.Disponible));
            }
            return lista2;

            






            
        }

        public void Grabar(Auto auto)
        {
            _autos.InsertOne(new AutoAux(auto.Id(),auto.Patente(),auto.Capacidad(),auto.PrecioKm(),auto.Disponible()));
            
        }

        public void Actualizar(Auto auto) {
            AutoAux auto1 = new AutoAux(auto.Id(), auto.Patente(), auto.Capacidad(), auto.PrecioKm(), auto.Disponible());
            var filter = Builders<AutoAux>.Filter.Eq(a => a.Patente, auto1.Patente);
            var update = Builders<AutoAux>.Update
                //.Set(a => a.id, auto1.id) 
                .Set(a => a.Capacidad, auto1.Capacidad)
                .Set(a => a.Patente, auto1.Patente)
                .Set(a => a.PrecioKm, auto1.PrecioKm)
                .Set(a => a.Disponible, auto1.Disponible);

            _autos.UpdateOne(filter, update);


            

        }

        public void Eliminar(Auto auto)
        {
            AutoAux auto1 = new AutoAux(auto.Id(), auto.Patente(), auto.Capacidad(), auto.PrecioKm(), auto.Disponible());
            var filter = Builders<AutoAux>.Filter.Eq(a => a.Patente, auto1.Patente);

            
            _autos.DeleteOne(filter);

            
        }

    }

}
