using System;
using System.Collections.Generic;
using System.Text;

namespace Alura_CSharpProgramming_Parte3
{
    class _05_ClasseBase
    {
        public void Run()
        {
            Employee Employee = new Employee(1500);
            Employee.CPF = "123.456.789-00";
            Employee.Nome = "123.456.789-00";
            Employee.DataNascimento = DateTime.Now;

            ((IEmployee)Employee).CargaHorariaMensal = 168;
            ((IOnDuty)Employee).CargaHorariaMensal = 32;
            Employee.EfetuarPagamento();
            Employee.CrachaGerado += (s, e) =>
            {
                Console.WriteLine("Crachá gerado");
            };
            ((IEmployee)Employee).GerarCracha();
            ((IOnDuty)Employee).GerarCracha();
        }
    }

    interface IEmployee
    {
        string CPF { get; set; }
        string Nome { get; set; }

        DateTime DataNascimento { get; set; }

        event EventHandler CrachaGerado;

        void GerarCracha();

        decimal Salario { get; }
        int CargaHorariaMensal { get; set; }

        void EfetuarPagamento();
    }

    interface IOnDuty
    {
        int CargaHorariaMensal { get; set; }
        void GerarCracha();
    }

    class Employee : IEmployee, IOnDuty
    {
        public Employee(decimal salario)
        {
            this.Salario = salario;
        }

        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        public event EventHandler CrachaGerado;
        void IEmployee.GerarCracha()
        {

        }
        void IOnDuty.GerarCracha()
        {

        }
        public decimal Salario { get; set; }
        int IEmployee.CargaHorariaMensal { get; set; }
        int IOnDuty.CargaHorariaMensal { get; set; }
        public void EfetuarPagamento()
        {

        }
    }
}
