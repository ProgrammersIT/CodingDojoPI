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
    public class VisualizadorDeCampoTestes
    {
        Mock<IEscreveCelula> _escreveCelulaMock;
        Mock<ICampoMinado> _campoMinadoMock;

        VisualizadorDeCampo _visualizadorDeCampo;

        [SetUp]
        public void SetUp()
        {
            _escreveCelulaMock = new Mock<IEscreveCelula>();
            _campoMinadoMock = new Mock<ICampoMinado>();

            _visualizadorDeCampo = new VisualizadorDeCampo(_escreveCelulaMock.Object);
        }

        [Test]
        public void DesenhaCampo_Chama_EscreverCelulaEAdicionarQuebraDeLinha()
        {
            _campoMinadoMock.Setup(x => x.Campo).Returns(new Celula[1,1]);

            _visualizadorDeCampo.DesenhaCampo(_campoMinadoMock.Object);

            _escreveCelulaMock.Verify(x => x.EscreverCelula(It.IsAny<Celula>()), Times.Once);
        }
    }
}
