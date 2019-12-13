using System;
using System.Collections.Generic;
using System.Text;

namespace Alura_CSharpProgramming_Parte1e2.Parte_05
{
    public class _05_01_Boxing : IAulaItem
    {
        public void Executar()
        {
            int numero = 57;
            object caixa = numero;

            Console.WriteLine(string.Concat("Resposta", numero, true));
        }
    }
}
