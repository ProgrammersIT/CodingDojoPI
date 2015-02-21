using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPrincipal
{
    public class ValidaTeoria
    {
        public int Assassino { get; private set; }
        public int Arma { get; private set; }
        public int Local { get; private set; }

        private IEscolherItemRandomico _randomico;

        public ValidaTeoria(int assassino, int local, int arma, IEscolherItemRandomico randomico)
        {
            Assassino = assassino;
            Local = local;
            Arma = arma;

            _randomico = randomico;
        }

        public int Validar(int assassino, int local, int arma)
        {
            var valoresIncorretos = new List<int>();

            if (Assassino != assassino)
                valoresIncorretos.Add(1);

            if(local != Local)
                valoresIncorretos.Add(2);

            if(arma != Arma)
                valoresIncorretos.Add(3);

            if (valoresIncorretos.Any())
                return _randomico.Escolher(valoresIncorretos);

            return 0;
        }
    }
}
