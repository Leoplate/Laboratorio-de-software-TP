// See https://aka.ms/new-console-template for more information
using _03_Dominio;
using _02_Aplicacion;

using static System.Runtime.InteropServices.JavaScript.JSType;
using _02_Aplicacion.DTO;
using _04_PersistenciaDatos;




AutoDTO Peugeot = new AutoDTO(Guid.NewGuid(), "GSG959", 5, 5000, true);

//AutoRepositorioMemoria BaseAutos = new AutoRepositorioMemoria();
AutoRepositorioMemoriaSQLServer BaseAutos = new AutoRepositorioMemoriaSQLServer();

CrearAuto CrearAutosDTO = new CrearAuto(BaseAutos);


CrearAutosDTO.Ejecutar(Peugeot);

ListarAuto ListaDTO = new ListarAuto(BaseAutos);



List<AutoDTO> ListaPrueba = ListaDTO.Ejecutar();

   foreach(AutoDTO dto in ListaPrueba)
{
      Console.WriteLine(dto.Id());
      Console.WriteLine(dto.Patente());
      Console.WriteLine(dto.Capacidad());
      Console.WriteLine(dto.PrecioKm());
      Console.WriteLine(dto.Disponible());
}


