using System;
using System.Collections.Generic;
using System.Text;

namespace Alura_CSharpProgramming_Parte1e2.Parte_04
{
    class _04_02MetodosSubstituidos : IAulaItem
    {
        public void Executar()
        {
            Animal gato = new Gato() { Nome = "Bichano" };
            gato.Beber();
            gato.Comer();
            gato.Andar();
        }
    }

    interface IAnimal
    {
        void Beber();
        void Comer();
        void Andar();
    }

    class Animal : IAnimal
    {
        public String Nome { get; set; }

        public void Beber()
        {
            Console.WriteLine("Animal.Beber");
        }

        public virtual void Comer()
        {
            Console.WriteLine("Animal.Comer");
        }

        public void Andar()
        {
            Console.WriteLine("Animal.Andar");
        }
    }

    class Gato : Animal
    {
        public new void Beber()
        {
            Console.WriteLine("Gato.Beber");
        }

        public override void Comer()
        {
            Console.WriteLine("Gato.Comer");
        }

        public new void Andar()
        {
            Console.WriteLine("Gato.Andar");
        }
    }
}
