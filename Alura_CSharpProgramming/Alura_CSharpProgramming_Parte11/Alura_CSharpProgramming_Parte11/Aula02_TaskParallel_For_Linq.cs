using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Alura_CSharpProgramming_ParteZ11
{
    class Aula02_TaskParallel_For_Linq
    {
        static void Metodo()
        {
            //TAREFA 1: processar 100 itens em série
            //TAREFA 2: processar 100 itens em paralelo - percorrendo uma faixa
            //TAREFA 3: processar 100 itens em paralelo - percorrendo uma coleção

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Console.WriteLine("Tarefa 1: processar 100 itens em série.");
            for (int i = 0; i < 100; i++)
            {
                Processar(i);
            }
            stopwatch.Stop();
            Console.WriteLine("[Tarefa 1] Tempo decorrido: {0} segundos",
                stopwatch.ElapsedMilliseconds / 1000);
            Console.WriteLine();

            stopwatch.Restart();
            Console.WriteLine("Tarefa 2: processar 100 itens em série. percorrendo uma faixa");
            Parallel.For(0, 100, (i) => Processar(i));
            stopwatch.Stop();
            Console.WriteLine("[Tarefa 2] Tempo decorrido: {0} segundos",
                stopwatch.ElapsedMilliseconds / 1000);
            Console.WriteLine();

            stopwatch.Restart();
            Console.WriteLine("Tarefa 3: processar 100 itens em série. percorrendo uma coleção");
            var itens = Enumerable.Range(0, 100);
            Parallel.ForEach(itens, (i) => Processar(i));
            stopwatch.Stop();
            Console.WriteLine("[Tarefa 3] Tempo decorrido: {0} segundos",
                stopwatch.ElapsedMilliseconds / 1000);
            Console.WriteLine();

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
