using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampoMinado
{
    public class VisualizadorDeCampo
    {
        IEscreveCelula _escreveCelula;

        public VisualizadorDeCampo(IEscreveCelula escreveCelula)
        {
            _escreveCelula = escreveCelula;
        }

        public void DesenhaCampo(ICampoMinado campoMinado)
        {
            _escreveCelula.EscreverCelula(campoMinado.Campo[0, 0]);
        }
    }
}
