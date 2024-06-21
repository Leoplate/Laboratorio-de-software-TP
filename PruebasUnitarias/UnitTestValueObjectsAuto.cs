
using _02_Aplicacion;
using _02_Aplicacion.DTO;
using _03_Dominio;
using _03_Dominio.ValueObject;



namespace PruebasUnitarias
{
    public class  ValueObjectsAutoValidatorShould
    {
        //TESTS PATENTE

        [Fact]
        public void ValidateValidPatente()
        {
            //Arrange
            string pate = "AAA123";
            Patente patente = new Patente(pate);


            //Act
            string validPate = patente.Valor();


            //Assert
            Assert.Equal(validPate, pate);
                       

        }


        [Fact]
        public void ValidatePatenteControlTamanioExcepcion()
        {
            //Arrange
            string pate = "AAA1239";
            

            // Act y Assert
            var excepcion = Assert.Throws<Exception>(() => new Patente(pate));
            Assert.Equal("Tamaño ingresado no corresponde", excepcion.Message);



        }


        //TESTS CAPACIDAD

        [Fact]
        public void ValidateValidCapacidad()
        {
            //Arrange
            int capa = 5;
            Capacidad capacidad = new Capacidad(capa);


            //Act
            int validCapa = capacidad.Valor();


            //Assert
            Assert.Equal(validCapa, capa);

        }

        [Fact]
        public void ValidateCapacidadControlExcepcion()
        {
            //Arrange
            int capa = -1;
            



            // Act y Assert
            var excepcion = Assert.Throws<Exception>(() => new Capacidad(capa));
            Assert.Equal("La capacidad debe ser positiva", excepcion.Message);
        }




        //TESTS DISPONIBLE

        [Fact]
        public void ValidateValidDisponible()
        {
            //Arrange
            bool dispo = true;
            Disponible disponible = new Disponible(dispo);


            //Act
            disponible.CambiarEstado(dispo);
            


            //Assert
            Assert.Equal(dispo, disponible.Valor());

        }

        
    



    [Fact]
        public void ValidateValidDisponibleCambiarEstado()
        {
            //Arrange
            bool dispo = true;
            Disponible disponible = new Disponible(dispo);


            //Act

            disponible.CambiarEstado(dispo);
            


            //Assert
            Assert.Equal(dispo, disponible.Valor());

        }

        [Fact]
        public void ValidateDisponibleControlarExcepcion()
        {
            
            //Arrange
            bool dispo = true;
            


            // Act y Assert
            var excepcion = Assert.Throws<Exception>(() => new Disponible(dispo));
            Assert.Equal("Estado es true o false", excepcion.Message);

            
        }
       
        


        //TEST IDENTIFICADOR

        [Fact]
        public void ValidateValidIdentificador()
        {
            // Arrange
            var originalGuid = Guid.NewGuid(); 
            var identificador = new Identificador(originalGuid);

            // Act
            var resultado = identificador.Valor();

            // Assert
            Assert.Equal(originalGuid, resultado);
        }


        //TESTS PRECIOKM

        [Fact]
        public void ValidateValidPrecioKm()
        {
            //Arrange
            int precio = 5;
            PrecioKm preciokm = new PrecioKm(precio);


            //Act
            int validprecio = preciokm.Valor();


            //Assert
            Assert.Equal(validprecio, precio);

        }

        

        [Fact]
        public void ValidatePrecioKmControlExcepcion()
        {
            // Arrange
            int precio = -5;

            // Act y Assert
            var excepcion = Assert.Throws<Exception>(() => new PrecioKm(precio));
            Assert.Equal("El precio debe ser positivo", excepcion.Message);
        }



    }
}