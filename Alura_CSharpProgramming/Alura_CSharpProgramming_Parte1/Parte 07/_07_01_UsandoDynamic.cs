using System;
using System.Collections.Generic;
using System.Text;

namespace Alura_CSharpProgramming_Parte1e2.Parte_07
{
    public class _07_01_UsandoDynamic : IAulaItem
    {
        public void Executar()
        {
            //Tipo definido na compilação
            string s = "Certificação C#";
            //Tipo definido na compilação (por inferência)
            var v = "Certificação C#";
            //Tipo definido na compilação
            object o = "Certificação C#";

            Console.WriteLine(s);
            Console.WriteLine(v);
            Console.WriteLine(o);

            s = s.ToUpper();
            v = v.ToUpper();
            o = ((string)o).ToUpper();

            //s = 123;
            //v = 123;
            o = 123;

            o = (int)o + 4;

            Console.WriteLine(o);

            //Tipo definido na execução
            dynamic d = "Certificação C#";
            Console.WriteLine(d);
            d = d.ToUpper();
            Console.WriteLine(d);
            d = 123;
            Console.WriteLine(d);
            d = d + 4;
            Console.WriteLine(d);
        }
    }
}
