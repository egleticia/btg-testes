using btg_testes_auto;
using System.Reflection.Metadata;

namespace btg_test
{
    public class AnaliseSuspeitoTest
    {
        [Theory(DisplayName = "Analise todas true")]
        [Trait("DefinirSuspeitos", "Assassino")]
        [InlineData(true, true, true, true, true)]
        public void AnaliseSuspeito_TodasTrue_RetornaAssassino(bool telefonouVitima, bool esteveNoLocal, bool moraPerto, bool devedor, bool trabalhaComVitima)
        {
            // Arrange
            AnaliseSuspeitos analiseSuspeitos = new();

            // Act
            string resultado = analiseSuspeitos.ExecutarQuestionarioSuspeito(telefonouVitima, esteveNoLocal, moraPerto, devedor, trabalhaComVitima);

            // Assert
            Assert.Equal("Assassino", resultado);
        }

        [Theory(DisplayName = "Analise todas false")]
        [Trait("DefinirSuspeitos", "Inocente")]
        [InlineData(false, false, false, false, false)]
        public void AnaliseSuspeito_TodasFalse_RetornaInocente(bool telefonouVitima, bool esteveNoLocal, bool moraPerto, bool devedor, bool trabalhaComVitima)
        {
            // Arrange
            AnaliseSuspeitos analiseSuspeitos = new();

            // Act
            string resultado = analiseSuspeitos.ExecutarQuestionarioSuspeito(telefonouVitima, esteveNoLocal, moraPerto, devedor, trabalhaComVitima);

            // Assert
            Assert.Equal("Inocente", resultado);
        }

        [Theory(DisplayName = "Analise duas true")]
        [Trait("DefinirSuspeitos", "Suspeita")]
        [InlineData(true, true, false, false, false)]
        [InlineData(false, true, true, false, false)]
        [InlineData(false, false, true, true, false)]
        [InlineData(false, false, false, true, true)]
        [InlineData(true, false, false, false, true)]
        public void AnaliseSuspeito_DuasTrue_RetornaSuspeita(bool telefonouVitima, bool esteveNoLocal, bool moraPerto, bool devedor, bool trabalhaComVitima)
        {
            // Arrange
            AnaliseSuspeitos analiseSuspeitos = new();

            // Act
            string resultado = analiseSuspeitos.ExecutarQuestionarioSuspeito(telefonouVitima, esteveNoLocal, moraPerto, devedor, trabalhaComVitima);

            // Assert
            Assert.Equal("Suspeita", resultado);
        }

        [Theory(DisplayName = "Analise tres/quatro true")]
        [Trait("DefinirSuspeitos", "Cumplice")]
        [InlineData(true, true, true, true, false)]
        [InlineData(true, true, true, false, false)]
        [InlineData(true, false, true, true, false)]
        [InlineData(false, true, false, true, true)]
        [InlineData(true, false, true, false, true)]
        public void AnaliseSuspeito_TresOuQuatroTrue_RetornaCumplice(bool telefonouVitima, bool esteveNoLocal, bool moraPerto, bool devedor, bool trabalhaComVitima)
        {
            // Arrange
            AnaliseSuspeitos analiseSuspeitos = new();

            // Act
            string resultado = analiseSuspeitos.ExecutarQuestionarioSuspeito(telefonouVitima, esteveNoLocal, moraPerto, devedor, trabalhaComVitima);

            // Assert
            Assert.Equal("Cúmplice", resultado);
        }
    }
}
