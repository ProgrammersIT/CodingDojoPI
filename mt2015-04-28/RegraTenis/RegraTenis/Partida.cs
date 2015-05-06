using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegraTenis
{
    public class Partida
    {
        private RegraTenis _regra;
        public Jogador Jogador1 { get; set; }
        public Jogador Jogador2 { get; set; }

        public Partida()
        {
            Jogador1 = new Jogador();
            Jogador2 = new Jogador();
            _regra = new RegraTenis(Jogador1, Jogador2);
        }

        public void MarcarPontoParaJogador1()
        {
            _regra.MarcarPontoPara(Jogador1);
        }

        public void MarcarPontoParaJogador2()
        {
            _regra.MarcarPontoPara(Jogador2);
        }

        public bool Terminou { 
            get { 
                return Jogador1.Pontos == (int)Pontuacao.Vitoria ||
                    Jogador2.Pontos == (int)Pontuacao.Vitoria; 
            } 
        }

        public Jogador Vencedor
        {
            get
            {
                if (Jogador1.Pontos == (int)Pontuacao.Vitoria)
                    return Jogador1;
                
                if (Jogador2.Pontos == (int)Pontuacao.Vitoria)
                    return Jogador2;

                return null;
            }
        }

    }
}
