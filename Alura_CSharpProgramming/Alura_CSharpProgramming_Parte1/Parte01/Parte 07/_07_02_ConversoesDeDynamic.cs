using System;
using System.Collections.Generic;
using System.Text;

namespace Alura_CSharpProgramming_Parte1.Parte01.Parte_07
{
    public class _07_02_ConversoesDeDynamic : IAulaItem
    {
        public void Executar()
        {
            dynamic d1 = 7;
            dynamic d2 = "string qualquer";
            dynamic d3 = DateTime.Now;
            dynamic d4 = new List<int>() { 123, 456, 789 };

            Console.WriteLine(d1);
            Console.WriteLine(d2);
            Console.WriteLine(d3);
            Console.WriteLine(d4);

            int i = d1;
            string str = d2;
            DateTime dt = d3;
            List<int> lista = d4;

            Console.WriteLine(d1);
            Console.WriteLine(d2);
            Console.WriteLine(d3);
            Console.WriteLine(d4);
        }
    }
}
