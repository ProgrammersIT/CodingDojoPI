using ProjetoPrincipal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesProjetoPrincipal
{
    public class Randomico : IEscolherItemRandomico
    {
        public int Escolher(List<int> lista)
        {
            return lista[new Random().Next(lista.Count)];
        }
    }

    [TestClass]
    public class DetetiveTest
    {
        Detetive _subject;

        int _assassino, _arma, _local;

        [TestInitialize]
        public void Setup()
        {
            _assassino = 3;
            _arma = 5;
            _local = 4;

            var randomico = new Randomico();

            _subject = new Detetive(new ValidaTeoria(_assassino, _local, _arma, randomico));
        }

        [TestMethod]
        public void DescobreTeoriaTest()
        {
            var resultado = _subject.DescobreTeoria();

            Assert.AreEqual(resultado.Assassino, _assassino);
            Assert.AreEqual(resultado.Local, _local);
            Assert.AreEqual(resultado.Arma, _arma);
        }
    }
}
