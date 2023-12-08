
using btg_testes_auto;
using Xunit.Sdk;

namespace btg_test
{
    public class MeiaCinemaTest
    {
        [Fact]
        public void VerificarMeiaEntrada_Estudante_RetornaTrue()
        {
            // Arrange
            var estudante = true;
            var doadorDeSangue = false;
            var trabalhadorPrefeitura = false;
            var contratoPrefeitura = false;

            MeiaCinema meiaCinema = new();

            // Act
            bool resultado = meiaCinema.VerificarMeiaCinema(estudante, doadorDeSangue, trabalhadorPrefeitura, contratoPrefeitura);

            // Assert
            Assert.True(resultado);
        }
        [Fact]
        public void VerificarMeiaEntrada_DoadorSangue_RetornaTrue()
        {
            // Arrange
            var estudante = false;
            var doadorDeSangue = true;
            var trabalhadorPrefeitura = false;
            var contratoPrefeitura = false;

            MeiaCinema meiaCinema = new();

            // Act
            bool resultado = meiaCinema.VerificarMeiaCinema(estudante, doadorDeSangue, trabalhadorPrefeitura, contratoPrefeitura);

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void VerificarMeiaEntrada_TrabalhadorPrefeitura_RetornaTrue()
        {
            // Arrange
            var estudante = false;
            var doadorDeSangue = false;
            var trabalhadorPrefeitura = true;
            var contratoPrefeitura = true;

            MeiaCinema meiaCinema = new();

            // Act
            bool resultado = meiaCinema.VerificarMeiaCinema(estudante, doadorDeSangue, trabalhadorPrefeitura, contratoPrefeitura);

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void VerificarMeiaEntrada_TrabalhadorPrefeitura_RetornaFalse()
        {
            // Arrange
            var estudante = false;
            var doadorDeSangue = false;
            var trabalhadorPrefeitura = true;
            var contratoPrefeitura = false;

            MeiaCinema meiaCinema = new();

            // Act
            bool resultado = meiaCinema.VerificarMeiaCinema(estudante, doadorDeSangue, trabalhadorPrefeitura, contratoPrefeitura);

            // Assert
            Assert.False(resultado);
        }

        [Fact]
        public void VerificarMeiaEntrada_RetornaFalse()
        {
            // Arrange
            var estudante = false;
            var doadorDeSangue = false;
            var trabalhadorPrefeitura = false;
            var contratoPrefeitura = false;

            MeiaCinema meiaCinema = new();

            // Act
            bool resultado = meiaCinema.VerificarMeiaCinema(estudante, doadorDeSangue, trabalhadorPrefeitura, contratoPrefeitura);

            // Assert
            Assert.False(resultado);
        }
    }
}