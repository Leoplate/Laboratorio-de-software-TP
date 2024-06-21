using _02_Aplicacion.DTO;
using _03_Dominio.Repositorios;
using _03_Dominio;
using System.Security.Cryptography.X509Certificates;


namespace _02_Aplicacion
{
    public class UnitOfWork
    {

        List<AutoDTO> CargarUOW = new List<AutoDTO>();
        List<AutoDTO> EliminarUOW = new List<AutoDTO>();
        List<AutoDTO> ModificarUOW = new List<AutoDTO> ();
        IAutoRepositorio Base;

        public UnitOfWork(IAutoRepositorio Base)
        {
            this.Base = Base;
        }


        public void Eliminar(AutoDTO auto)
        {

            int indice = EliminarUOW.FindIndex(a => a.Patente() == auto.Patente());
            
            
            if (indice == -1)
            {
                

                EliminarUOW.Add(auto);
                
            }
            
                 
        }


        public void Modificar(AutoDTO auto)
        {


            int indice = ModificarUOW.FindIndex(a => a.Patente() == auto.Patente());


            if (indice != -1)
            {
                ModificarUOW[indice] = auto;

            }
            else { ModificarUOW.Add(auto); }


        }

        public void Cargar(AutoDTO auto)
        {


            int indice = Base.Listar().FindIndex(a => a.Patente() == auto.Patente());


            if (indice == -1)
            {


                CargarUOW.Add(auto);

            }
        }



        public void Ejecutar()
        {

            foreach (AutoDTO dto in CargarUOW)
            {

                Base.Grabar(new Auto(dto.Id(), dto.Patente(), dto.Capacidad(), dto.PrecioKm(), dto.Disponible()));
            }




            foreach (AutoDTO dto in ModificarUOW)
            {
                Base.Actualizar(new Auto(dto.Id(), dto.Patente(), dto.Capacidad(), dto.PrecioKm(), dto.Disponible()));
            }






            foreach (AutoDTO dto in EliminarUOW)
            {

                Base.Eliminar(new Auto(dto.Id(), dto.Patente(), dto.Capacidad(), dto.PrecioKm(), dto.Disponible()));
            }
        }


        }


        

        


    
}
