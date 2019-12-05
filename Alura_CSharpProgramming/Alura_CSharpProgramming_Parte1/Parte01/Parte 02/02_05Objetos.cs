using System;
using System.Collections.Generic;
using System.Text;

namespace Alura_CSharpProgramming_Parte1.Parte01.Parte_02
{
    class _02_05Objetos : IAulaItem
    {
        public void Executar()
        {
            int pontuacao = 10;
            Console.WriteLine($"pontuacao: {pontuacao}");

            Console.WriteLine("OBJECT COM VALOR PRIMITIVO");
            object meuObjeto;
            meuObjeto = pontuacao;
            Console.WriteLine($"meuObjeto: {meuObjeto}");
            Console.WriteLine($"meuObjeto.GetType(): {meuObjeto.GetType()}");
            ///Console.WriteLine($"meuObjeto.ToString(): {meuObjeto.ToString()}");

            Console.WriteLine();
            Console.WriteLine("OBJECT COM REFERÊNCIA DE OBJETO");

            meuObjeto = new Jogador();
            Jogador classRef;
            classRef = (Jogador)meuObjeto; //conversão explícita, ou "cast"
                                           ///classRef = (Jogador)meuObjeto;
            Console.WriteLine($"classRef.Pontuacao: {classRef.Pontuacao}");
        }
    }

    class Jogador
    {
        public int Pontuacao { get; set; } = 10;
    }

}
