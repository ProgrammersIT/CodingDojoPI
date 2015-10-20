using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuvemVulcao
{
    public class EspacoAereo
    {
        public const string NUVEM = "*";
        public const string AEROPORTO = "A";

        public string[,] Representacao { get; set; }
        private int LimiteColuna { get; set; }
        private int LimiteLinha { get; set; }

        public EspacoAereo(int colunas, int linhas)
        {
            Representacao = new string[colunas, linhas];
            LimiteColuna = colunas;
            LimiteLinha = linhas;
        }

        public void PosicionarNuvem(int coluna, int linha)
        {
            if (PosicaoInvalida(coluna, linha))
                throw new ArgumentException("Fora do limite da Matriz");
                
            Representacao[coluna, linha] = NUVEM;
        }

        public void PosicionarAeroporto(int coluna, int linha)
        {
            if (PosicaoInvalida(coluna, linha))
                throw new ArgumentException("Fora do limite da Matriz");

            if (Representacao[coluna, linha] != NUVEM)
                Representacao[coluna, linha] = AEROPORTO;
        }

        private bool PosicaoInvalida(int coluna, int linha)
        {
            return !(coluna < LimiteColuna && linha < LimiteLinha
                            && coluna >= 0 && linha >= 0);
        }

        public void Expandir()
        {
            var representacaoAtual = new string[LimiteColuna, LimiteLinha];
            Array.Copy(Representacao, representacaoAtual, Representacao.Length);

            for(var coluna = 0; coluna < LimiteColuna; coluna++)
                for (var linha = 0; linha < LimiteLinha; linha++)
                {
                    if(representacaoAtual[coluna, linha] == NUVEM)
                    {
                       List<Tuple<int, int>> posicoes = RetornaPosicoesAdjentes(coluna, linha);

                       foreach (var posicao in posicoes)
                       {
                           if (!PosicaoInvalida(posicao.Item1, posicao.Item2))
                               Representacao[posicao.Item1, posicao.Item2] = NUVEM;
                       }
                    }
                }


        }

        private List<Tuple <int, int>> RetornaPosicoesAdjentes(int coluna, int linha)
        {
            List<Tuple<int, int>> result = new List<Tuple<int, int>>();

            result.Add(new Tuple<int, int>(coluna,linha + 1));
            result.Add(new Tuple<int, int>(coluna, linha - 1));
            result.Add(new Tuple<int, int>(coluna + 1, linha));
            result.Add(new Tuple<int, int>(coluna - 1, linha));

            return result;

            

            

            

        }
    }
}
