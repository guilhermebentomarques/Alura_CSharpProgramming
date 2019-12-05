using System;
using System.Collections.Generic;
using System.Text;

namespace Alura_CSharpProgramming_Parte1.Parte01.Parte_05
{
    public class _05_02_Unboxing : IAulaItem
    {
        public void Executar()
        {
            int numero = 57;
            object caixa = numero;

            try
            {
                int unboxed = (short)caixa;
                Console.WriteLine("Unboxing OK.");
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("{0} Erro: unboxing incorreto", e);
            }
        }
    }
}
