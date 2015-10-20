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
}
