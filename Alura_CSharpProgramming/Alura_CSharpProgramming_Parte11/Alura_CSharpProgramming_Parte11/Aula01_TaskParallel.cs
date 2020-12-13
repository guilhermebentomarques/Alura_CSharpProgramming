using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Alura_CSharpProgramming_ParteZ11
{
    class Aula01_TaskParallel
    {
        static void Metodo()
        {
            //TAREFA 1: Cozinhar e refogar EM SÉRIE
            //TAREFA 2: Cozinha e refogar EM PARALELO
            //TAREFA 3: Medir o tempo dos dois procedimentos

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            CozinharMacarrao();
            RefogarMolho();
            stopwatch.Stop();

            Console.WriteLine("[SEQUENCIAL] Tempo decorrido: {0} segundos", 
                stopwatch.ElapsedMilliseconds / 1000);

            stopwatch.Reset();
            stopwatch.Restart();

            Parallel.Invoke(() => CozinharMacarrao(), () => RefogarMolho());

            Console.WriteLine("[PARALELO] Tempo decorrido: {0} segundos",
                stopwatch.ElapsedMilliseconds / 1000);

            Console.WriteLine("Retire do fogo e ponha o molho sobre o macarrão"+ 
                "Bom Apetite");

            Console.ReadLine();
        }

        static void CozinharMacarrao()
        {
            Console.WriteLine("Cozinhando Macarrão");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Cozinhando já está cozido!");
            Console.WriteLine("");
        }

        static void RefogarMolho()
        {
            Console.WriteLine("Refogando Molho");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("Molho já está refogado!");
            Console.WriteLine("");
        }
    }
}
