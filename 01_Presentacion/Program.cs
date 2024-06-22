using _03_Dominio;
using _02_Aplicacion;
using System.Configuration;
using static System.Runtime.InteropServices.JavaScript.JSType;
using _02_Aplicacion.DTO;
using _04_PersistenciaDatos;
using System.Reflection;




AutoDTO Peugeot206 = new AutoDTO(Guid.NewGuid(), "GSG958", 5, 5000, true);
AutoDTO Peugeot208 = new AutoDTO(Guid.NewGuid(), "AAA888", 5, 4000, true);
AutoDTO CitroenC4 = new AutoDTO(Guid.NewGuid(), "AAG789", 5, 4000, false);
AutoDTO Peugeot408 = new AutoDTO(Guid.NewGuid(), "aBB992", 2, 700000, true);
AutoDTO Peugeot206XT = new AutoDTO(Guid.NewGuid(), "GSG958", 2, 400000, true);

AutoRepositorioMemoria BaseAutos = new AutoRepositorioMemoria();
//AutoRepositorioSQL BaseAutosSQL = new AutoRepositorioSQL();
AutoRepositorioMongoDB BaseAutoMongoDB = new AutoRepositorioMongoDB();

CrearAuto CrearAutosDTO = new CrearAuto(BaseAutos);
UnitOfWork UOW = new UnitOfWork(BaseAutoMongoDB);

CrearAutosDTO.Ejecutar(Peugeot206);
CrearAutosDTO.Ejecutar(Peugeot208);
CrearAutosDTO.Ejecutar(CitroenC4);
CrearAutosDTO.Ejecutar(Peugeot206XT);
CrearAutosDTO.Ejecutar(Peugeot408);
UOW.Cargar(Peugeot206);
UOW.Cargar(Peugeot208);
UOW.Cargar(CitroenC4);
UOW.Cargar(Peugeot206XT);
UOW.Cargar(Peugeot408);
UOW.Modificar(Peugeot206);
UOW.Modificar(Peugeot208);
UOW.Modificar(CitroenC4);
UOW.Modificar(Peugeot206XT);
UOW.Modificar(Peugeot408);



ListarAuto ListaDTO = new ListarAuto(BaseAutos);



Console.WriteLine("---------------LISTA ORIGINAL:----------------");
   foreach(AutoDTO dto in ListaDTO.Ejecutar())
{
      Console.WriteLine(dto.Id());
      Console.WriteLine(dto.Patente());
      Console.WriteLine(dto.Capacidad());
      Console.WriteLine(dto.PrecioKm());
      Console.WriteLine(dto.Disponible());
}


ModificarAuto modi = new ModificarAuto(BaseAutos);
Console.WriteLine("---------------LISTA MODIFICADA:----------------");
if (modi.Ejecutar(Peugeot206XT)!=-1)
{
    UOW.Modificar(Peugeot206XT);
    Console.WriteLine("Se modificó el auto patente N° " + Peugeot206XT.Patente());
    
}
else
{
    Console.WriteLine("Auto patente N° " + Peugeot206XT.Patente() + " no existe");
}



PersistirCambioDisponibilidadAuto dispo = new PersistirCambioDisponibilidadAuto(BaseAutos);

Console.WriteLine("---------------MODIFICACION ESTADO AUTO:----------------");
if (dispo.Ejecutar(Peugeot408) != -1)
{
    UOW.Modificar(Peugeot408);
    Console.WriteLine("Se modificó disponibilidad auto patente N° " + Peugeot408.Patente());

}
else
{
    Console.WriteLine("Auto patente N° " + Peugeot408.Patente() + " no existe");
}





foreach (AutoDTO dto in ListaDTO.Ejecutar())
{
    Console.WriteLine(dto.Id());
    Console.WriteLine(dto.Patente());
    Console.WriteLine(dto.Capacidad());
    Console.WriteLine(dto.PrecioKm());
    Console.WriteLine(dto.Disponible());
}

Console.WriteLine("---------------LISTA DISMINUIDA:----------------");
EliminarAuto eli = new EliminarAuto(BaseAutos);

   
if (eli.Ejecutar(Peugeot206XT) != -1)
{
    UOW.Eliminar(Peugeot206XT);
    Console.WriteLine("Se eliminó el auto patente N° " + Peugeot206XT.Patente());
    
}
else
{
    Console.WriteLine("Auto patente N° " + Peugeot206XT.Patente() + " no existe");
}




foreach (AutoDTO dto in ListaDTO.Ejecutar())
{
    Console.WriteLine(dto.Id());
    Console.WriteLine(dto.Patente());
    Console.WriteLine(dto.Capacidad());
    Console.WriteLine(dto.PrecioKm());
    Console.WriteLine(dto.Disponible());
}

UOW.Ejecutar();

