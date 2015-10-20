using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortaBanco.Testes
{
    [TestFixture]
    public class HorarioEntradaNaPortaDoBancoDePirinopolisSelectorTests
    {
        [Test]
        public void FiltraEntradasEntre10e16Horas()
        {
            var listaEntradas = new List<LinhaLog>();
            
            listaEntradas.Add(new LinhaLog { HorarioLog = new DateTime(2015, 08, 20, 09, 59, 00) });
            listaEntradas.Add(new LinhaLog { HorarioLog = new DateTime(2015, 08, 20, 10, 00, 00) });
            listaEntradas.Add(new LinhaLog { HorarioLog = new DateTime(2015, 08, 20, 13, 01, 00) });
            listaEntradas.Add(new LinhaLog { HorarioLog = new DateTime(2015, 08, 20, 16, 00, 00) });
            listaEntradas.Add(new LinhaLog { HorarioLog = new DateTime(2015, 08, 20, 16, 01, 00) });

            var filtro = new HorarioEntradaNaPortaDoBancoDePirinopolisSelector();

            var listaFiltrada = filtro.Filtrar(listaEntradas);

            Assert.That(listaFiltrada.Count, Is.EqualTo(3));

            Assert.That(listaFiltrada[0].HorarioLog.Hour, Is.EqualTo(10));
            Assert.That(listaFiltrada[1].HorarioLog.Hour, Is.EqualTo(13));
            Assert.That(listaFiltrada[2].HorarioLog.Hour, Is.EqualTo(16));
        }
    }
}
