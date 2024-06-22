using _03_Dominio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03_Dominio
{
    public class Auto
    {
        private Identificador id;
        private Patente patente;
        private Capacidad capacidad;
        private PrecioKm precioKm;
        private Disponible disponible;
        
        
        public Auto(Guid id, string patente, int capacidad,int precioKM,bool disponible) {
            this.id = new Identificador(id);
            this.patente = new Patente(patente);
            this.capacidad = new Capacidad(capacidad);
            this.precioKm = new PrecioKm(precioKM);
            this.disponible = new Disponible(disponible);
        }



        public Guid Id()
        {
            return this.id.Valor();
        }


        public string Patente()
        {
            return this.patente.Valor();
        }

        public int Capacidad()
        {
            return this.capacidad.Valor();
        }

        public int PrecioKm()
        {
            return this.precioKm.Valor();
        }

        public bool Disponible()
        {
            return this.disponible.Valor();
        }


        public void EnViaje(){
            this.disponible.CambiarEstado(false);
        }

        public void SinViaje()
        {
            this.disponible.CambiarEstado(true);
        }

        

        
    }
}
