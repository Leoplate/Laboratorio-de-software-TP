using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03_Dominio
{
    public class Patente
    {
        private string patente;
        
        
        public Patente(string patente)
        {
            this.controlTamanio(patente);
            this.patente = patente;
        }


        public void controlTamanio(string patente)
        {
            
            
            if (patente.Length != 6)
            {
                throw new Exception("Tamaño ingresado no corresponde");
            }
        }

        public string Valor()
        {
            return this.patente;
        }
    }
}
