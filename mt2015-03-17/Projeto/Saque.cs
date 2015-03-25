using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto
{
    public class Nota
    {
        public int Valor { get; set; }
    }

    public class CaixaEletronico
    {
        List<int> _valoresDasNotasDisponiveis = new List<int> { 100, 50, 20, 10 };
        List<Nota> result = new List<Nota>();

        
        public List<Nota> RealizaSaque(int valorDoSaque)
        {
            VerificaValoresAbaixoDoMinimo(valorDoSaque);

            int numeroNotas = 0;
            
            _valoresDasNotasDisponiveis.ForEach(nota => {
                numeroNotas = valorDoSaque / nota;

                valorDoSaque -= (numeroNotas * nota);
                IncluirNota(numeroNotas, nota);
            });

            return result;
        }

        private void VerificaValoresAbaixoDoMinimo(int valorDoSaque)
        {
            var menorValorDeNota = _valoresDasNotasDisponiveis.Min();

            if (valorDoSaque < menorValorDeNota)
                throw new ArgumentException();
        }

        void IncluirNota(int numeroNotas, int valorNota)
        {
            for (var numero = 1; numero <= numeroNotas; numero++)
                result.Add(new Nota { Valor = valorNota });
        }
    }
}
