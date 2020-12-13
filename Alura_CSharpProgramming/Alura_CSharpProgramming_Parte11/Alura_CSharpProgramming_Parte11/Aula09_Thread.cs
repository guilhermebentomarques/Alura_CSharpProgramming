using System;
using System.Threading;
using System.Threading.Tasks;

namespace Alura_CSharpProgramming_ParteZ11
{
    class Aula09_Thread
    {
        static void Metodo()
        {
            // Thread vs Task

            Thread thread1 = new Thread(Executar);
            thread1.Start();

            // 2 Thread com expressão lambda

            // 3 Passando parametro para a thread

            Console.WriteLine("Término do processamento. Tecle [ENTER] para terminar.");
            Console.ReadLine();
        }

        private static void Executar()
        {
            Console.WriteLine("Thread Iniciou");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Thread Finalizou");
        }
    }
}
