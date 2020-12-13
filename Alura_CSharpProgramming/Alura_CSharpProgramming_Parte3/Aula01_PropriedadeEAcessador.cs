using System;
using System.Collections.Generic;
using System.Text;

namespace Alura_CSharpProgramming_Parte3
{
    class Aula01_PropriedadeEAcessador
    {
        public void Run()
        {
            Funcionario funcionario = new Funcionario(1000);
            funcionario.Salario = 1200;
            Console.WriteLine(funcionario.Salario);
            funcionario.Salario = 2000;
            funcionario.Salario = 800;
        }
    }

    class Funcionario
    {
        public Funcionario(decimal salario)
        {
            if (salario < 0)
            {
                throw new ArgumentOutOfRangeException("Salário não pode ser negativo.");
            }
            this.salario = salario;
        }

        decimal salario;

        public decimal Salario //encapsulamento campo salario
        {
            get
            {
                return salario;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Salário não pode ser negativo.");
                }
                else
                {
                    salario = value;
                }
            }
        }
    }
}
