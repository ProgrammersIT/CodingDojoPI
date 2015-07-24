using System;
using System.Linq;
using NUnit.Framework;

namespace CampoMinado.Testes
{
    [TestFixture]
    public class CampoMinadoTestes
    {
        const int LINHAS = 4;
        const int COLUNAS = 4;
        const int TOTAL = LINHAS * COLUNAS;

        CampoMinado _campoMinado;

        [SetUp]
        public void Setup()
        {
            _campoMinado = new CampoMinado(LINHAS, COLUNAS);
        }

        [Test]
        public void Campo_eh_inicializado_corretamente()
        {
            foreach (var celula in _campoMinado.Campo)
                Assert.That(celula.Valor, Is.EqualTo(0));
        }

        [TestCase(0, 0)]
        [TestCase(0, 1)]
        public void As_bombas_sao_posicionadas_de_acordo_com_a_posicao_informada(int x, int y)
        {
            _campoMinado.AdicionarBomba(new Posicao(x, y));

            Assert.That(_campoMinado.Campo[x, y].Valor, Is.EqualTo(CampoMinado.VALOR_BOMBA));
        }

        [Test]
        public void Outros_campos_nao_contem_bombas()
        {
            const int ESPERADO_SEM_BOMBA = TOTAL - 1;
            _campoMinado.AdicionarBomba(new Posicao(0, 0));

            int bombas = 0;

            foreach (var espaco in _campoMinado.Campo)
                if (espaco.Valor == CampoMinado.VALOR_BOMBA)
                    bombas++;

            var espacosSemBomba = TOTAL - bombas;

            Assert.That(espacosSemBomba, Is.EqualTo(ESPERADO_SEM_BOMBA));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Posicao_Invalida_Lanca_Excecao()
        {
            _campoMinado.AdicionarBomba(new Posicao (10, 10));
        }

        [Test]
        public void Calcular_quantidade_de_bombas_adjacentes()
        {
            _campoMinado.AdicionarBomba(new Posicao(0, 0));
            _campoMinado.AdicionarBomba(new Posicao(2, 1));

            Assert.That(_campoMinado.Campo[1, 0].Valor, Is.EqualTo(2));
            Assert.That(_campoMinado.Campo[1, 1].Valor, Is.EqualTo(2));
            Assert.That(_campoMinado.Campo[0, 1].Valor, Is.EqualTo(1));
        }
    }
}
