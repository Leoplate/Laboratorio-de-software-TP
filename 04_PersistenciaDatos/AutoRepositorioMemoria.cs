using _03_Dominio;
using _03_Dominio.Repositorios;

namespace _04_PersistenciaDatos
{
    public class AutoRepositorioMemoria : IAutoRepositorio
    {

        List<Auto> BaseAutos = new List<Auto>();


        

        public List<Auto> Listar()
        {
            return this.BaseAutos;
        }

        public void Grabar(Auto auto)
        {
            this.BaseAutos.Add(auto);
        }
    }
}
