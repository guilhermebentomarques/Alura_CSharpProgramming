using Alura_CSharpProgramming_Parte1e2.Parte_04;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura_CSharpProgramming_Parte1e2.Parte_06
{
    public class _06_01_ConversoesImplicitas : IAulaItem
    {
        public void Executar()
        {
            int inteiro = 2_123_456_789;
            long inteirolongo = inteiro;

            Console.WriteLine(inteirolongo);

            //inteiro = inteirolongo;
            Gato gato = new Gato();
            Animal animal = gato;
            Console.WriteLine(animal.GetType());
            IAnimal ianimal = gato;
            Console.WriteLine(ianimal.GetType());
            //gato = ianimal;

        }
    }
}
