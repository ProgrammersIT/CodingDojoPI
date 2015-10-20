using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortaBanco.Testes
{
    [TestFixture]
    public class AnalisadorLogTests
    {
        Mock<ILogMapper> mapper;
        Mock<ISeletor> seletor;
        List<string> linhas;
        AnalisadorLog analisadorLog;

        [SetUp]
        public void Setup()
        {
             mapper = new Mock<ILogMapper>();
             seletor = new Mock<ISeletor>();
             linhas = new List<string>();
             analisadorLog = new AnalisadorLog(mapper.Object, seletor.Object);
        }

        [Test]
        public void MapeiaLinhasValidas()
        {
            linhas.Add("Linha valida 1");
            linhas.Add("Linha valida 2");
            linhas.Add("Linha valida 3");

            mapper.Setup(m => m.CanMap(It.IsAny<string>()))
                  .Returns(true);

            analisadorLog.AnalisarEntradas(linhas);

            foreach (var linha in linhas)
                mapper.Verify(m => m.Map(linha));
        }

        [Test]
        public void IgnoraLinhasInvalidas()
        {
            linhas.Add("Linha invalida 1");

            mapper.Setup(m => m.CanMap(It.IsAny<string>()))
                  .Returns(false);

            analisadorLog.AnalisarEntradas(linhas);

            mapper.Verify(m => m.Map(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void MapeiaSomenteAsLinhasValidas()
        {
            linhas.Add("Linha valida 1");
            linhas.Add("Linha invalida 1");
            linhas.Add("Linha valida 2");

            mapper.Setup(m => m.CanMap(It.Is<string>(s => s.StartsWith("Linha valida"))))
                  .Returns(true);

            analisadorLog.AnalisarEntradas(linhas);

            mapper.Verify(x => x.Map("Linha valida 1"));
            mapper.Verify(x => x.Map("Linha invalida 1"), Times.Never);
            mapper.Verify(x => x.Map("Linha valida 2"));
        }

        [Test]
        public void FiltraLinhasMapeadasComSelector()
        {
            var expectedLinhaLog = new List<LinhaLog>();

            seletor.Setup(x => x.Filtrar(It.IsAny<List<LinhaLog>>()))
                   .Returns(expectedLinhaLog);

            var linhasDeLogFiltrados = analisadorLog.AnalisarEntradas(linhas);

            Assert.That(linhasDeLogFiltrados, Is.SameAs(expectedLinhaLog));
        }
    }
}
