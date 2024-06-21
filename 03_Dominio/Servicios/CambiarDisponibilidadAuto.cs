
using _03_Dominio.Repositorios;
using _03_Dominio;
using System.Security.Cryptography.X509Certificates;


namespace _02_Aplicacion
{
    public class CambiarDisponibilidadAuto
    {

        

        


        public Auto Ejecutar(Auto auto)
        {

            
                
            
            

                bool estado = auto.Disponible();
                if (estado)
                {
                    auto.EnViaje();
                }
                else { auto.SinViaje();}


            return auto;


        }

            
                
               


            
        

    }
}
