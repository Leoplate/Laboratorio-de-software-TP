using _03_Dominio;
using _03_Dominio.Repositorios;
using System.Runtime.Intrinsics.X86;

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

        public void Actualizar(Auto auto) {

            int indice = BaseAutos.FindIndex(a => a.Patente() == auto.Patente());
            BaseAutos[indice] = auto;

        }

        public void Eliminar(Auto auto)
        {
            int indice = BaseAutos.FindIndex(a => a.Patente() == auto.Patente());
            BaseAutos.RemoveAt(indice);

            
        }

    }

}
