using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampoMinado
{
    public interface IEscreveCelula
    {
        void EscreverCelula(Celula celula);
        void AdicionarQuebraDeLinha();
    }
}
