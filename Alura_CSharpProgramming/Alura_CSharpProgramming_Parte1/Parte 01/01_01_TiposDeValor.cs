using System;
using System.Collections.Generic;
using System.Text;

namespace Alura_CSharpProgramming_Parte1e2.Parte_01
{
    class _01_TiposDeValor : IAulaItem
    {
        public void Executar()
        {
            int idade;
            idade = 30;
            Console.WriteLine(idade);

            int copiaIdade = idade;
            Console.WriteLine($"Idade: { idade} ");
            Console.WriteLine($"Idade: { copiaIdade} ");

            idade = 23;

            Console.WriteLine($"Idade: { idade} ");
            Console.WriteLine($"Idade: { copiaIdade} ");

            int? idade2 = null; //FAZER VARIÁVEIS NULAS


        }
    }
}
