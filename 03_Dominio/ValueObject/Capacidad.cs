using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Dominio.ValueObject
{
    public class Capacidad
    {

        private int capacidad;
        public Capacidad(int capacidad) { 
            this.control(capacidad);
            this.capacidad = capacidad;
        }

        
        public void control(int capacidad)
        {
            if(capacidad <= 0)
            {
                throw new Exception("La capacidad debe ser positiva");
            }
            
        }
        
        public int Valor()
        {
            return this.capacidad;
        }


    }
}
