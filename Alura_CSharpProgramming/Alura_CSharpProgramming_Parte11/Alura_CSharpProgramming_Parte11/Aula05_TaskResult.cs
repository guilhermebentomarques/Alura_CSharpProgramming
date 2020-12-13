using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Alura_CSharpProgramming_ParteZ11
{
    class Aula05_TaskResult
    {
        static void Metodo()
        {
            Task tarefa1 = new Task(() => ExecutaTrabalho(1));
            tarefa1.Start();
            tarefa1.Wait();

            Task tarefa2 = Task.Run(() => ExecutaTrabalho(1));
            tarefa2.Wait();

            Task<int> tarefa3 = Task.Run(() =>
            {
                return CalcularResultado(1, 3);
            });
            Console.WriteLine("O resultado é {0}", tarefa3.Result);

            Console.WriteLine("Término do processamento. Tecle [ENTER] para terminar.");
            Console.ReadLine();
        }

        static void ExecutaTrabalho(object item)
        {
            Console.WriteLine("Trabalho Iniciado: {0} " + item);
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("Trabalho Terminado: {0} " + item);
            Console.WriteLine("");
        }

        public static int CalcularResultado(int num1, int num2)
        {
            Console.WriteLine("Trabalho Iniciado");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("Trabalho Terminado");
            Console.WriteLine("");
            return num1 + num2;
        }
    }
}
