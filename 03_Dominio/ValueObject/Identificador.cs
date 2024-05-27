using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03_Dominio
{
    public class Identificador
    {
        private Guid valor;
        
        public Identificador(Guid valor) 
        {
            this.valor = valor;
        }

        public Guid Valor()
        {
            return this.valor;
        }
    }
}
