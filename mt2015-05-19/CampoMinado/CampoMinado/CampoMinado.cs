using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampoMinado
{
    public class CampoMinado : ICampoMinado
    {
        public Celula[,] Campo { get; private set; }

        public const int VALOR_BOMBA = 9;
        int _linhas;
        int _colunas;

        public CampoMinado(int linhas, int colunas)
        {
            _linhas = linhas;
            _colunas = colunas;

            InicializarCelulas();
        }

        public void AdicionarBomba(Posicao posicao)
        {
            try
            {
                Campo[posicao.X, posicao.Y].Valor = VALOR_BOMBA;

                var obterAdjacentes = ObterPosicoesAdjacentes(posicao.X, posicao.Y);

                obterAdjacentes.ForEach(p => Campo[p.X, p.Y].Valor++);

            }
            catch (IndexOutOfRangeException)
            {
                throw new ArgumentException();
            }
        }

        private void InicializarCelulas()
        {
            Campo = new Celula[_linhas, _colunas];

            for (var linha = 0; linha < _linhas; linha++)
                for (var coluna = 0; coluna < _colunas; coluna++)
                    Campo[linha, coluna] = new Celula();
        }

        private List<Posicao> ObterPosicoesAdjacentes(int x, int y)
        {
            var adjacentes = new List<Posicao>();

            for (int adjX = x - 1; adjX <= x + 1; adjX++)
            {
                for (int adjY = y - 1; adjY <= y + 1; adjY++)
                {
                    if (adjX == x && adjY == y)
                        continue;
                    if (adjX < 0 || adjX >= _linhas)
                        continue;
                    if (adjY < 0 || adjY >= _colunas)
                        continue;

                    adjacentes.Add(new Posicao(adjX, adjY));
                }
            }

            return adjacentes;
        }
    }
}
