using System;
using NUnit.Framework;

namespace RegraTenis.Testes
{
    [TestFixture]
    public class RegraTenisTests
    {
        RegraTenis regras;

        [SetUp]
        public void Setup()
        {
            regras = new RegraTenis(new Jogador(), new Jogador());
        }

        [Test]
        public void Jogo_inicia_em_zero_a_zero()
        {
            Assert.That(regras.Jogador1.Pontos, Is.EqualTo(0));
            Assert.That(regras.Jogador2.Pontos, Is.EqualTo(0));
        }

        [TestCase(Pontuacao.Zero, Pontuacao.Quinze)]
        [TestCase(Pontuacao.Quinze, Pontuacao.Trinta)]
        [TestCase(Pontuacao.Trinta, Pontuacao.Quarenta)]
        public void Jogador1_marca_um_ponto(Pontuacao atual, Pontuacao esperada)
        {
            regras.Jogador1.Pontos = (int)atual;
            regras.MarcarPontoPara(regras.Jogador1);

            Assert.That((Pontuacao)regras.Jogador1.Pontos, Is.EqualTo(esperada));
            Assert.That((Pontuacao)regras.Jogador2.Pontos, Is.EqualTo(Pontuacao.Zero));
        }        

        [Test]
        public void JogoAcabouTeste()
        {
            regras.Jogador1.Pontos = (int)Pontuacao.Vitoria;

            Assert.Throws<Exception>(() => regras.MarcarPontoPara(regras.Jogador1));
        }

        [Test]
        public void JogadorTem40Pontos_MarcouMais_OutroJogadorMenorQue40_VitoriaJogador40Pontos()
        {
            regras.Jogador1.Pontos = (int)Pontuacao.Quarenta;
            regras.Jogador2.Pontos = (int)Pontuacao.Quinze;

            regras.MarcarPontoPara(regras.Jogador1);

            Assert.That((Pontuacao)regras.Jogador1.Pontos, Is.EqualTo(Pontuacao.Vitoria));
        }

        [Test]
        public void OsDoisJogadoresTem40Pontos_OJogadorQueMarcarFicaComVantagem()
        {
            regras.Jogador1.Pontos = (int)Pontuacao.Quarenta;
            regras.Jogador2.Pontos = (int)Pontuacao.Quarenta;

            regras.MarcarPontoPara(regras.Jogador1);

            Assert.That((Pontuacao)regras.Jogador1.Pontos, Is.EqualTo(Pontuacao.Vantagem));
        }

        [Test]
        public void JogadorTemVantagem_MarcaUmPonto_Vitoria()
        {
            regras.Jogador1.Pontos = (int)Pontuacao.Vantagem;
            regras.Jogador2.Pontos = (int)Pontuacao.Quarenta;

            regras.MarcarPontoPara(regras.Jogador1);

            Assert.That((Pontuacao)regras.Jogador1.Pontos, Is.EqualTo(Pontuacao.Vitoria));
        }

        [Test]
        public void JogadorTemVantagem_OutroJogadorMarcaUmPonto_VoltarPlacar()
        {
            regras.Jogador1.Pontos = (int)Pontuacao.Vantagem;
            regras.Jogador2.Pontos = (int)Pontuacao.Quarenta;

            regras.MarcarPontoPara(regras.Jogador2);

            Assert.That((Pontuacao)regras.Jogador1.Pontos, Is.EqualTo(Pontuacao.Quarenta));
            Assert.That((Pontuacao)regras.Jogador2.Pontos, Is.EqualTo(Pontuacao.Quarenta));
        }
    }
}
