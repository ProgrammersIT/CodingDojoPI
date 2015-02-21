using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetoPrincipal;
using Moq;
using System.Collections.Generic;

namespace TestesProjetoPrincipal
{
    [TestClass]
    public class ValidaTeoriaTest
    {
        ValidaTeoria _subject;
        Mock<IEscolherItemRandomico> _escolherRandomico;

        [TestInitialize]
        public void Setup()
        {
            _escolherRandomico = new Mock<IEscolherItemRandomico>();

            _escolherRandomico.Setup(x => x.Escolher(new List<int> { 1 })).Returns(1);
            _escolherRandomico.Setup(x => x.Escolher(new List<int> { 2 })).Returns(2);
            _escolherRandomico.Setup(x => x.Escolher(new List<int> { 3 })).Returns(3);
            _escolherRandomico.Setup(x => x.Escolher(new List<int> { 2, 3 })).Returns(3);

            _subject = new ValidaTeoria(0, 0, 0, _escolherRandomico.Object);
        }

        [TestMethod]
        public void TestValidarTeoriaCorreta()
        {
            var resultado = _subject.Validar(0, 0, 0);

            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void TestValidarTeoriaComAssassinoIncorreto()
        {
            var resultado = _subject.Validar(1, 0, 0);

            Assert.AreEqual(resultado, 1);
        }

        [TestMethod]
        public void TestValidarTeoriaComLocalIncorreto()
        {
            var resultado = _subject.Validar(0, 1, 0);

            Assert.AreEqual(resultado, 2);
        }

        [TestMethod]
        public void TestValidarTeoriaComArmaIncorreto()
        {
            var resultado = _subject.Validar(0, 0, 1);

            Assert.AreEqual(resultado, 3);
        }

        [TestMethod]
        public void TestValidarTeoriaComArmaELocalIncorretos()
        {
            var resultado = _subject.Validar(0, 1, 1);

            Assert.AreEqual(resultado, 3);
        }
    }
}
