using btg_testes_auto;

namespace btg_test
{
    public class VooTest
    {
        Voo voo = new("168", "A107", new DateTime(2023, 07, 20, 14, 30, 0));


        [Fact(DisplayName = "Voo vazio")]
        public void AssentosDisponiveis_VooVazio_RetornaCem()
        {
            int retorno = voo.QuantidadeVagasDisponivel();

            Assert.Equal(100, retorno);
        }

        [Fact(DisplayName = "Assentos Disponiveis com dois Assentos Ocupados ")]
        public void VerificarQuantidadeVagasDisponiveis_3AssentosOcupados_RetornaNoventaESete()
        {
            voo.OcupaAssento(42);
            voo.OcupaAssento(39);
            voo.OcupaAssento(71);
            int retorno = voo.QuantidadeVagasDisponivel();

            Assert.Equal(97, retorno);
        }

        [Fact(DisplayName = "Assentos Disponiveis com Voo Lotado ")]
        public void VerificarQuantidadeVagasDisponiveis_VooCheio_RetornaZero()
        {
            for (int i = 0; i <= 100; i++)
            {
                voo.OcupaAssento(i);
            }
            int retorno = voo.QuantidadeVagasDisponivel();

            Assert.Equal(0, retorno);
        }

        [Fact(DisplayName = "Prox. assento Livre voo cheio")]
        public void VerificarProximoLivre_VooCheio_RetornaZero()
        {
            for (int i = 0; i <= 100; i++)
            {
                voo.OcupaAssento(i);
            }
            int retorno = voo.ProximoLivre();

            Assert.Equal(0, retorno);
        }

        [Fact(DisplayName = "Assento não está disponível")]
        public void VerificarDisponibilidadeAssento_AssentoVinteETres_RetornaFalse()
        {
            voo.OcupaAssento(23);
            bool retorno = voo.AssentoDisponivel(23);

            Assert.False(retorno);
        }

        [Fact(DisplayName = "Assento disponivel")]
        public void VerificarDisponibilidadeAssento_AssentoVinteETres_RetornaTrue()
        {
            bool retorno = voo.AssentoDisponivel(23);

            Assert.True(retorno);
        }


    }
}
