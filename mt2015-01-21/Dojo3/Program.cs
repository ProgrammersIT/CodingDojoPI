using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo3
{
    public class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            Dictionary<string, bool[]> dados = new Dictionary<string, bool[]>
            {
                {"peixe", new[]{true,false,false,false}},
                {"cachorro", new[]{false,false,true,false}},
                {"cobra", new[]{false,false,false,true}},
                {"tucano", new[]{false,true,false,false}},
                {"batima", new[]{false,true,true,false}},
            };

            var perguntas = new[]
            {
                "Ele nada?",
                "Ele voa?",
                "É um mamífero?",
                "É um reptil?",
            };

            Console.WriteLine("Pense em um animal e tecle alguma coisa...");
            Console.ReadKey();

            bool[] respostas = program.ColetaRespostas(perguntas);

            var animal = program.DescobrirAnimal(dados, respostas);

            Console.WriteLine(animal);

            Console.ReadKey();
        }

        public string DescobrirAnimal(Dictionary<string, bool[]> dados, bool[] respostas)
        {
            var match = dados.FirstOrDefault(x =>
            {
                var result = true;

                for (int i = 0; i < x.Value.Length; i++)
                {
                    result = result && x.Value[i] == respostas[i];
                }

                return result;
            });

            return match.Key;
        }

        public bool UsuarioRespondeuSim(string resp)
        {
            return resp != null && resp.ToLower() == "sim";
        }

        public bool[] ColetaRespostas(String[] perguntas)
        {
            var resultado = new List<bool>();

            foreach (var pergunta in perguntas)
            {
                Console.WriteLine(pergunta);
                var resposta = Console.ReadLine();
                resultado.Add(UsuarioRespondeuSim(resposta));
            }

            return resultado.ToArray();
        }


    }
}
