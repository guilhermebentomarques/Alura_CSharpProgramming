using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Alura_CSharpProgramming_ParteZ11
{
    class Aula03_TaskInterruption
    {
        static void Metodo()
        {
            //TAREFA 1: processar uma faixa de 100 itens em paralelo
            //TAREFA 2: completou sem interrupção?
            //TAREFA 3: interromper quando começar o valor 75
            //TAREFA 4: quantos itens foram processados (parcialmente)?

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var result = Parallel.For(0, 99, (int i, ParallelLoopState state) =>
            {
                if (i == 75)
                {
                    state.Break();
                }

                Processar(i);
            });
            Console.WriteLine("Completou em interrupção? {0}", result.IsCompleted);
            Console.WriteLine("quantos itens foram processados (parcialmente)? {0}", result.LowestBreakIteration);

            Console.WriteLine("Término do processamento. Tecle [ENTER] para terminar.");
            Console.ReadLine();
        }

        static void Processar(object item)
        {
            Console.WriteLine("Começando a trabalhar com " + item);
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("Terminando a trabalhar com " + item);
            Console.WriteLine("");
        }
    }
}
