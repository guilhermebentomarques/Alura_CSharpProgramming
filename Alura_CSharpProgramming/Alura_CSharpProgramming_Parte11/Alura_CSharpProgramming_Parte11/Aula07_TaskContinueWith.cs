using System;
using System.Threading.Tasks;

namespace Alura_CSharpProgramming_ParteZ11
{
    class Aula07_TaskContinueWith
    {
        static void Metodo()
        {
            Task tarefa = Task.Run(() => Ola());

            tarefa.ContinueWith((tarefaAnterior) => Mundo(),
                TaskContinuationOptions.NotOnFaulted); // Não executar se houve falha

            tarefa.ContinueWith((tarefaAnterior) => Erro(tarefaAnterior),
                TaskContinuationOptions.OnlyOnFaulted);

            Console.WriteLine("Término do processamento. Tecle [ENTER] para terminar.");
            Console.ReadLine();
        }

        static void Ola()
        {
            Console.WriteLine("Olá");
            throw new ApplicationException("Opa! Ocorreu um erro no método olá");
        }

        static void Mundo()
        {
            Console.WriteLine("Mundo");
        }

        private static void Erro(Task tarefaAnterior)
        {
            var excecoes = tarefaAnterior.Exception.InnerExceptions;

            foreach (var excecao in excecoes)
            {
                Console.WriteLine(excecao);
            }
        }
    }
}
