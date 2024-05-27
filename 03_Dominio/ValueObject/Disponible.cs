using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Dominio.ValueObject
{
    public class Disponible
    {
        bool disponible;

        public Disponible(bool estado)
        {
            this.Controlar(estado);
            this.disponible = estado;
        }

        public bool Valor()
        {   
            return disponible;
        }

        public void  Controlar(bool estado)
        {
            if(estado != true && estado != false)
            {
                throw new Exception("Estado es true o false");
            }
        }

        public void CambiarEstado(bool estado)
        {
            this.Controlar(estado);
            this.disponible = estado;
        }

    }
}
