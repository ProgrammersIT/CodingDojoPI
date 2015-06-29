using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedindoPizza
{
    public class PedindoPizza
    {
        private List<Pessoa> pessoasNaReuniao;
        private List<Pizza> opcoesPizzas;

        public PedindoPizza(List<Pessoa> pessoasNaReuniao, List<Pizza> opcoesPizzas)
        {            
            this.pessoasNaReuniao = pessoasNaReuniao;
            this.opcoesPizzas = opcoesPizzas;
        }

        public PedindoPizza()
        {
            
        }
        public void Avaliar(Pessoa pessoa, Pizza pizza, int nota) {
            if (!IsVotoValido(nota))
                throw new ArgumentOutOfRangeException("Nota deve ser de 1 a 5");

            pizza.nota += nota;
            pizza.totalVoto++;

            CalcularMedia(pizza);
        }

        public void CalcularMedia(Pizza pizza)
        {
            pizza.media = pizza.nota / pizza.totalVoto;
        }
     
        private bool IsVotoValido(int nota)
        {
            return (nota >= 1 && nota <= 5);
        }

        public List<Pizza> ProcessarRanking()
        {
            return this.opcoesPizzas.OrderByDescending(x => x.media).ToList();
        }
    }
}
