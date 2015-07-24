using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampoMinado.Testes
{
    [TestFixture]
    public class PosicionadorDeBombasTestes
    {
        [Test]
        public void Posicionador_bombas_posiciona_uma_lista_de_bombas_no_campo_minado()
        {     
            var posicoes = new Posicao[] { new Posicao(0, 0), new Posicao(2, 1) };

            Mock<ICampoMinado> campo = new Mock<ICampoMinado>();
            var posicionador = new PosicionadorDeBombas(campo.Object);            

            posicionador.PosicionaBombasNoCampo(posicoes);

            campo.Verify(x => x.AdicionarBomba(posicoes[0]), Times.Once);
            campo.Verify(x => x.AdicionarBomba(posicoes[1]), Times.Once);
        }
    }
}
