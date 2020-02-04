using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploConsole_SorteioNumerosNaoRepetidos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sorteando dez números que estejam entre o intervalo de 1 e 100.
            Console.WriteLine(string.Join(", ", SorteiaNumerosSemRepetir(100, 1, 100)));
            Console.ReadLine();
        }

        private static int[] SorteiaNumerosSemRepetir(int quantidade, int minimo, int maximo)
        {
            // Validações dos argumentos.
            if (quantidade < 0)
                throw new ArgumentException("Quantidade deve ser maior que zero.");
            else if (quantidade > maximo + 1 - minimo)
                throw new ArgumentException("Quantidade deve ser menor do que a diferença entre máximo e mínimo.");
            else if (maximo <= minimo)
                throw new ArgumentException("Máximo deve ser maior do que mínimo.");

            List<int> numerosSorteados = new List<int>();
            Random rnd = new Random();

            while (numerosSorteados.Count < quantidade)
            {
                int numeroSorteado = rnd.Next(minimo, maximo + 1);

                // Número já foi sorteado? Então sorteamos novamente até o número não ter sido sorteado ainda.
                while (numerosSorteados.Contains(numeroSorteado))
                    numeroSorteado = rnd.Next(minimo, maximo + 1);

                numerosSorteados.Add(numeroSorteado);
            }

            return numerosSorteados.ToArray();
        }
    }
}
