using Alura_CSharpProgramming_Parte1e2.Parte_02;
using Alura_CSharpProgramming_Parte1e2.Parte_04;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura_CSharpProgramming_Parte1e2.Parte_06
{
    public class _06_03_OperadoresIseAs : IAulaItem
    {
        public void Executar()
        {
            Animal animal = new Animal();
            Gato gato = new Gato();
            Cliente cliente = new Cliente("José da Silva", 30);

            Alimentar(animal);
            Alimentar(gato);
            Alimentar(cliente);
        }

        public void Alimentar(object obj)
        {
            if (obj is Animal animal)
            {
                animal.Beber();
                animal.Beber();
                return;
            }

            Console.WriteLine("obj não é um animal!");
        }
    }
}
