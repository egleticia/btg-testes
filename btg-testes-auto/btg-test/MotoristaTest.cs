
using btg_testes_auto;

namespace btg_test
{
    public class MotoristaTest
    {
        Pessoa pessoaUm = new Pessoa() { Idade = 25, Nome = "Leticia", PossuiHabilitaçãoB = true };
        Pessoa pessoaDois = new Pessoa() { Idade = 16, Nome = "Maria", PossuiHabilitaçãoB = false };
        Pessoa pessoaTres = new Pessoa() { Idade = 28, Nome = "Carlos", PossuiHabilitaçãoB = false };
        Pessoa pessoaQuatro = new Pessoa() { Idade = 18, Nome = "Roberto", PossuiHabilitaçãoB = true };
        Pessoa pessoaCinco = new Pessoa() { Idade = 10, Nome = "Julia", PossuiHabilitaçãoB = false };
        Pessoa pessoaSeis = new Pessoa() { Idade = 35, Nome = "Renan", PossuiHabilitaçãoB = true };



        [Fact(DisplayName = "Encontra motorista")]
        public void EncontrarMotoristas_DoisMotoristas_RetornaNomesMotoristas()
        {
            //Arrange
            List<Pessoa> pessoas = new() { pessoaUm, pessoaSeis, pessoaTres, pessoaQuatro, pessoaDois };
            Motorista motorista = new();

            //Act
            string resultado = motorista.EncontrarMotoristas(pessoas);

            //Assert
            Assert.Contains("Leticia", resultado);
            Assert.Contains("Renan", resultado);
            Assert.DoesNotContain("Maria", resultado);
            Assert.DoesNotContain("Carlos", resultado);
            Assert.DoesNotContain("Roberto", resultado);
        }

        [Fact(DisplayName = "Encontra motorista")]
        public void EncontrarMotoristas_SemMotoristaDisponivel_RetornaErro()
        {
            //Arrange
            List<Pessoa> pessoas = new() { pessoaDois, pessoaTres, pessoaCinco };
            Motorista motorista = new();
            
            //Act
            Action resultado = () => motorista.EncontrarMotoristas(pessoas);

            //Assert
            Assert.Throws<Exception>(resultado);
        }

    }
}
