using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dojo3.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidaResultadoUsuario()
        {
            var program = new Program();
            var condicoes = new Dictionary<string, bool>();
            condicoes.Add("", false);
            condicoes.Add("Sim", true);
            condicoes.Add("SIM", true);
            condicoes.Add("sim", true);
            condicoes.Add("nao", false);
            condicoes.Add("Nao", false);
            condicoes.Add("qualquer coisa", false);

            foreach (var condicao in condicoes)
            {
                var resultado = program.UsuarioRespondeuSim(condicao.Key);
                Assert.AreEqual(resultado, condicao.Value);
            }

            Assert.IsFalse(program.UsuarioRespondeuSim(null));
        }



        [TestMethod]
        public void MostrarPerguntasEReceberRespostas()
        {
            var perguntas = new[]
            {
                "Pergunta 1?",
                "Pergunta 2?",
                "Pergunta 3?",
                "Pergunta 4?",
            };

            var program = new Program();

            bool[] respostas = program.ColetaRespostas(perguntas);

            Assert.AreEqual(perguntas.Length, respostas.Length);
            //Assert.IsTrue(respostas[0]);
            //Assert.IsFalse(respostas[1]);
            //Assert.IsFalse(respostas[2]);
            //Assert.IsTrue(respostas[3]);

            /* true, false, false, true */
        }

        [TestMethod]
        public void DescobrirAnimal()
        {
            var program = new Program();

            bool[] respostas = new[] { true, false, false, false};

            var dados = new Dictionary<string, bool[]>{
                {"peixe", new[] { true, false, false, false}},
                {"outro", new[] { true, false, false, false}}
            };

            var animal = program.DescobrirAnimal(dados, respostas);

            Assert.AreEqual("peixe", animal);
        }

    }
}
