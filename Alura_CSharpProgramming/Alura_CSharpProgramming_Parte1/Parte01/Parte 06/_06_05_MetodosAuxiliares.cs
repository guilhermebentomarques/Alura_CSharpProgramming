using System;
using System.Collections.Generic;
using System.Text;

namespace Alura_CSharpProgramming_Parte1.Parte01.Parte_06
{
    public class _06_05_MetodosAuxiliares : IAulaItem
    {
        public void Executar()
        {
            string textoDigitado = "123";
            //int numeroConvertido = textoDigitado;
            int numeroConvertido = int.Parse(textoDigitado);
            Console.WriteLine(numeroConvertido);

            textoDigitado = "abc";
            //numeroConvertido = int.Parse(textoDigitado);
            int.TryParse(textoDigitado, out numeroConvertido);

            if (int.TryParse(textoDigitado, out numeroConvertido))
            {
                Console.WriteLine(numeroConvertido);
            }
            else
            {
                Console.WriteLine("Texto não é um número.");
            }

            textoDigitado = "$ 123.45";
            decimal.TryParse(textoDigitado, 
                System.Globalization.NumberStyles.Currency, //Moeda
                System.Globalization.CultureInfo.CurrentCulture, //pt-BR
                out decimal valorConvertido);
            Console.WriteLine(valorConvertido);

        }
    }
}
