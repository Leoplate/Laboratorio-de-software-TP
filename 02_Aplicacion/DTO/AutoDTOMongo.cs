using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Aplicacion.DTO
{
    public class AutoAux
    {
        [BsonElement("_id")]
        public Guid id;
        [BsonElement("patente")]
        public string Patente;
        [BsonElement("capacidad")]
        public int Capacidad;
        [BsonElement("precioKm")]
        public int PrecioKm;
        [BsonElement("disponible")]
        public bool Disponible;


        public AutoAux(Guid id, string patente, int capacidad, int precioKm, bool disponible)
        {
            this.id = id;
            this.Patente = patente.ToUpper();
            this.Capacidad = capacidad;
            this.PrecioKm = precioKm;
            this.Disponible = disponible;
        }
    }
}
