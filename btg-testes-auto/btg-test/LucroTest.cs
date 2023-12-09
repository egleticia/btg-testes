
using btg_testes_auto;

namespace btg_test
{
    public class LucroTest
    {
        [Fact(DisplayName = "Valor menor que 20")]
        public void DefinirLucro_ValorMenorQue20_RetornaLucro()
        {
            Lucro lucro = new Lucro();
            decimal retorno = lucro.Calcular(10);

            Assert.Equal(14.5M, retorno);
        }

        [Fact(DisplayName = "Igual a 20")]
        public void DefinirLucro_ValorIgual20_RetornaLucro()
        {
            Lucro lucro = new Lucro();
            decimal retorno = lucro.Calcular(20);

            Assert.Equal(26, retorno);
        }

        [Fact(DisplayName = "Maior que 20")]
        public void DefinirLucro_ValorMaiorQue20_RetornaLucro()
        {
            Lucro lucro = new Lucro();
            decimal retorno = lucro.Calcular(40);

            Assert.Equal(52, retorno);
        }
    }
}
