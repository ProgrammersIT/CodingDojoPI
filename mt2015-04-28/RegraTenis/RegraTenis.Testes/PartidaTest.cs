using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegraTenis.Testes
{
    [TestFixture]
    public class PartidaTest
    {
        Partida partida;

        [SetUp]
        public void SetUp()
        {
            partida = new Partida();
        }

        [Test]
        public void IniciaPartida_AmbosJogadoresComZeroPontos()
        {
            Assert.That(partida.Jogador1.Pontos, Is.EqualTo(0));
            Assert.That(partida.Jogador2.Pontos, Is.EqualTo(0));
        }

        [Test]
        public void Nenhum_jogador_com_Vitoria_partida_nao_acabou()
        {
            Assert.That(partida.Terminou, Is.False);
        }

        [Test]
        public void Quando_alguem_chegar_no_ponto_vitoria_ai_acaba_tudo()
        {
            partida.Jogador1.Pontos = (int)Pontuacao.Vitoria;
            Assert.That(partida.Terminou, Is.True);
        }

        [Test]
        public void Jogador1_Marca45_E_DestroiJogador2()
        {
            partida.MarcarPontoParaJogador1();
            partida.MarcarPontoParaJogador1();
            partida.MarcarPontoParaJogador1();
            partida.MarcarPontoParaJogador1();

            Assert.That(partida.Terminou, Is.True);
            Assert.That(partida.Vencedor, Is.EqualTo(partida.Jogador1));
        }
    }
}
