using System;
using System.Threading.Tasks;

namespace Alura_CSharpProgramming_ParteZ11
{
    class Aula08_TaskHierarchy
    {
        static void Metodo()
        {
            //PROBLEMA. CRIAR E EXECUTAR TAREFA MAE
            //E 10 TAREFAS FILHAS

            Task tarefaMae =
                Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Inicio Tarefa Mãe");

                    for (int i = 0; i < 10; i++)
                    {
                        int tarefaID = i;

                        Task tarefaFilha =
                        Task.Factory.StartNew((id) =>
                        ExecutarFilha(id),
                        tarefaID,
                        TaskCreationOptions.AttachedToParent);
                    }
                });

            tarefaMae.Wait();
            Console.WriteLine("Fim Tarefa Mãe");

            Console.ReadLine();

            Console.WriteLine("Término do processamento. Tecle [ENTER] para terminar.");
            Console.ReadLine();
        }

        private static void ExecutarFilha(object i)
        {
            Console.WriteLine("Tarefa filha {0} iniciou", i);
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Tarefa filha {0} terminou", i);
        }
    }
}
