using _02_Aplicacion.DTO;
using _03_Dominio.Repositorios;
using _03_Dominio;
using System.Security.Cryptography.X509Certificates;


namespace _02_Aplicacion
{
    public class PersistirCambioDisponibilidadAuto
    {

        IAutoRepositorio RepositorioAuto;

        public PersistirCambioDisponibilidadAuto(IAutoRepositorio Base)
        {
            this.RepositorioAuto = Base;
        }


        public int Ejecutar(AutoDTO auto)
        {

            
             int indice = RepositorioAuto.Listar().FindIndex(a => a.Patente() == auto.Patente());
            

            
            
            if (indice != -1)
            {
                Auto aux = new Auto(auto.Id(), auto.Patente(), auto.Capacidad(), auto.PrecioKm(), auto.Disponible());
                CambiarDisponibilidadAuto cambio = new CambiarDisponibilidadAuto();
                //cambio.Ejecutar(aux);
                   

                this.RepositorioAuto.Actualizar(cambio.Ejecutar(aux));
                
            }

            return indice;
                
               


            
        }

    }
}
