using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Dominio.ValueObject
{
    public class PrecioKm
    {

        int precioKm;

        public PrecioKm(int precioKm) 
        { 
            this.Control(precioKm);
            this.precioKm = precioKm;
        }

        public int Valor()
        {
            return this.precioKm;
        }


        public void Control(int precioKm)
        {
            if(precioKm <= 0)
            {
                throw new Exception("El precio debe ser positivo");
            }

        }

    }
}
