using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampoMinado
{
    public class Posicao
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Posicao(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class PosicionadorDeBombas
    {
        Posicao[] _posicoes = { new Posicao(0, 0), new Posicao(2, 1) };

        public void PosicionaBombasNoCampo(CampoMinado campoMinado)
        {
            foreach (var posicao in _posicoes)
	        {
                campoMinado.PosicionarBomba(posicao);
	        }
        }
    }
}
