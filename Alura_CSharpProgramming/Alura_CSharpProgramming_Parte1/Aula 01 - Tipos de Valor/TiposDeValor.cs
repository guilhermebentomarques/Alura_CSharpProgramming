using System;
using System.Collections.Generic;
using System.Text;

namespace Alura_CSharpProgramming_Parte1.Aula_01___Tipos_de_Valor
{
    public class TiposDeValor
    {
        public void Executar()
        {
            int idade;
            idade = 30;
            Console.WriteLine(idade);

            int copiaIdade = idade;
            Console.WriteLine($"Idade: { idade} ");
        }
    }
}
