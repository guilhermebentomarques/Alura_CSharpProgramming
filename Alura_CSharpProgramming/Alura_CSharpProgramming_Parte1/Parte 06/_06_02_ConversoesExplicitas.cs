using Alura_CSharpProgramming_Parte1e2.Parte_04;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura_CSharpProgramming_Parte1e2.Parte_06
{
    public class _06_02_ConversoesExplicitas : IAulaItem
    {
        public void Executar()
        {
            double divida = 1_234_567_890.123;
            //long copia = divida;

            double salario = 1_237.89;
            long copiaSalario = (long)salario;

            Console.WriteLine(salario);

            Animal animal = new Gato();
            //Gato gato = animal;
        }
    }
}
