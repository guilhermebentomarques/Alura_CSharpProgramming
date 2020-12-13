using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Alura_CSharpProgramming_ParteZ11
{
    class Aula06_TaskWaitAll
    {
        static void Metodo()
        {
            Console.WriteLine("Número de Threads - Início");
            Console.WriteLine(Process.GetCurrentProcess().Threads.Count);

            Task[] tarefas = new Task[10];

            for (int i = 0; i < tarefas.Length; i++)
            {
                int numeroCorredor = i;
                Task.Run(() => Correr(numeroCorredor));

            }

            Task.WaitAll(tarefas);

            Console.WriteLine("Número de Threads - Fim");
            Console.WriteLine(Process.GetCurrentProcess().Threads.Count);

            Console.WriteLine("Término do processamento. Tecle [ENTER] para terminar.");
            Console.ReadLine();
        }

        static void Correr(int numCorredor)
        {
            Console.WriteLine("Corredor {0} largou " + numCorredor);
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Corredor {0} terminou " + numCorredor);
            Console.WriteLine("");
        }
    }
}
