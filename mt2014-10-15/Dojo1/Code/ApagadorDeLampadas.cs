using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo1.Code
{
    public class ApagadorDeLampadas
    {
        List<bool> lampadas;

        public ApagadorDeLampadas()
        {
            lampadas = new List<bool>();
        }
        public List<bool> PassadaNoCorredor(int vezes)
        {
            if (vezes <= 0)
                throw new ArgumentException();

            InicializarLampadas(vezes);

            for (int passada = 0; passada < vezes; passada++)
            {
                for (int lampada = 0; lampada < vezes; lampada++)
                {
                    if (((lampada + 1) % (passada + 1)) == 0)
                        lampadas[lampada] = !lampadas[lampada];
                }
            }

            return lampadas;
        }

        private void InicializarLampadas(int vezes)
        {
            for (int i = 0; i < vezes; i++)
            {
                lampadas.Add(false);
            }
        }

        

    }
}
