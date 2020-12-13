using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Alura_CSharpProgramming_ParteZ11
{
    class Program
    {
        static void Main(string[] args)
        {
            Task tarefa1 = new Task(() => ExecutaTrabalho(1));
            tarefa1.Start();

            Task tarefa2 = Task.Run(() => ExecutaTrabalho(1));

            Console.WriteLine("Término do processamento. Tecle [ENTER] para terminar.");
            Console.ReadLine();

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
    }
}
