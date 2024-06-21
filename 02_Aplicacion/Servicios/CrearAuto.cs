using _02_Aplicacion.DTO;
using _03_Dominio.Repositorios;
using _03_Dominio;
using System.Security.Cryptography.X509Certificates;


namespace _02_Aplicacion
{
    public class CrearAuto
    {

        IAutoRepositorio RepositorioAuto;

        public CrearAuto(IAutoRepositorio Base)
        {
            this.RepositorioAuto = Base;
        }


        public void Ejecutar(AutoDTO carro)
        {

            int indice = RepositorioAuto.Listar().FindIndex(a => a.Patente() == carro.Patente());


            if (indice == -1)
            {
                
               
                 this.RepositorioAuto.Grabar(new Auto(
                    carro.Id(),
                    carro.Patente(),
                    carro.Capacidad(),
                    carro.PrecioKm(),
                    carro.Disponible()));
                 {
            }

            };
        }

    }
}
