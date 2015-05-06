using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegraTenis
{
    public enum Pontuacao
    {
        Zero = 0,
        Quinze = 1,
        Trinta = 2,
        Quarenta = 3,
        Vantagem = 4,
        Vitoria = 5
    }

    public class RegraTenis
    {
        public Jogador Jogador1;
        public Jogador Jogador2;

        public RegraTenis(Jogador jogador1, Jogador jogador2)
        {
            Jogador1 = jogador1;
            Jogador2 = jogador2;
        }

        public void MarcarPontoPara(Jogador jogador)
        {
            if ((Pontuacao)jogador.Pontos == Pontuacao.Vitoria)
                throw new Exception("Jogo acabou!!!");

            var outro = Jogador1 == jogador ? Jogador2 : Jogador1;

            if (outro.Pontos == (int)Pontuacao.Vantagem && jogador.Pontos == (int)Pontuacao.Quarenta)
                outro.Pontos = (int)Pontuacao.Quarenta;
            else if ((Pontuacao)jogador.Pontos == Pontuacao.Quarenta && outro.Pontos < (int)Pontuacao.Quarenta)
                jogador.Pontos = (int)Pontuacao.Vitoria;
            else
                jogador.Pontos++;
        }

    }
}
