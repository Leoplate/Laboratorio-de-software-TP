using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Dominio.Repositorios
{
    public interface IAutoRepositorio
    {
        public List<Auto> Listar();

        public void Grabar(Auto auto);
        
    }
}
