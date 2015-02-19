using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dojo1.Code;

namespace Unit
{
    [TestClass]
    public class ProjectTests
    {
        private ApagadorDeLampadas apagadorDeLampadas;

        [TestInitialize]
        public void Setup()
        {
            apagadorDeLampadas = new ApagadorDeLampadas();
        }

        [TestMethod]
        public void ALampada1_Esta_Ligada_Primeira_Passada()
        {
            var lampadas = apagadorDeLampadas.PassadaNoCorredor(1);
            Assert.IsTrue(lampadas[0], "");
        }

        [TestMethod]
        public void ALampada2_Esta_Ligada_Primeira_Passada()
        {
            var lampadas = apagadorDeLampadas.PassadaNoCorredor(2);
            Assert.IsTrue(lampadas[0], "");
            Assert.IsFalse(lampadas[1], "");
        }

        [TestMethod]
        public void TresLampadas()
        {
            var lampadas = apagadorDeLampadas.PassadaNoCorredor(3);
            Assert.IsTrue(lampadas[0], "");
            Assert.IsFalse(lampadas[1], "");
            Assert.IsFalse(lampadas[2], "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TesteNegativo()
        {
            var lampadas = apagadorDeLampadas.PassadaNoCorredor(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TesteZeroPassadas()
        {
            var lampadas = apagadorDeLampadas.PassadaNoCorredor(0);
        }
    }
}
