using System;
using System.Collections.Generic;
using System.Text;

namespace Alura_CSharpProgramming_Parte1.Parte_02
{
    class _02_06Dinamicos : IAulaItem
    {
        public void Executar()
        {
            object objeto = 1;
            //objeto = objeto + 3;

            dynamic dinamico = 1;
            dinamico = dinamico + 3;
            Console.WriteLine(dinamico);

            //dinamico.teste();
        }
    }
}
