using _02_Aplicacion.DTO;
using _03_Dominio.Repositorios;
using _03_Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Aplicacion
{
    public class ListarAuto
    {

        IAutoRepositorio Repositorio;

        public ListarAuto(IAutoRepositorio Base)
        {
            this.Repositorio = Base;

        }

        public List<AutoDTO> Ejecutar()
        {
            List<Auto> listaAuto = Repositorio.Listar();
            List<AutoDTO> listaAutoDTO = new List<AutoDTO>();

            foreach(Auto auto in listaAuto)
            {
                listaAutoDTO.Add(new AutoDTO(auto.Id(), auto.Patente(), auto.Capacidad(),auto.PrecioKm() ,auto.Disponible()));

            }

            return listaAutoDTO;
            
        }
    }
}
