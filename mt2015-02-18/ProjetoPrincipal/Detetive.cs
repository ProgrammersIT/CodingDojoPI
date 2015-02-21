using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPrincipal
{
    public class Detetive
    {
        ValidaTeoria _validaTeoria;

        public Detetive(ValidaTeoria validaTeoria)
        {
            _validaTeoria = validaTeoria;
        }

        public SolucaoTeoria DescobreTeoria()
        {
            var numeroTentativas = 0;
            for (int assassino = 0; assassino < 6; assassino++)
            {
                for (int local = 0; local < 10; local++)
                {
                    for (int arma = 0; arma < 6; arma++)
                    {
                        numeroTentativas++;
                        if (_validaTeoria.Validar(assassino, local, arma) == 0)
                            return new SolucaoTeoria{Assassino = assassino, Local = local, Arma = arma, Tentativas = numeroTentativas};
                    }
                }
            }

            return null;
        }
    }

    public class SolucaoTeoria
    {
        public int Assassino { get; set; }
        public int Arma { get; set; }
        public int Local { get; set; }
        public int Tentativas { get; set; }
    }
}
