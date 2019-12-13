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

            Customer customer = new Customer
            {
                CPF = "789.456.123-99",
                DataNascimento = new DateTime(1980, 1, 1),
                Nome = "Maria de Souza",
                DataUltimaCompra = new DateTime(2018, 1, 1),
                ValorUltimaCompra = 200
            };

            Console.WriteLine(customer);

            Customer person = new Customer
            {
                CPF = "789.456.123-99",
                DataNascimento = new DateTime(1980, 1, 1),
                Nome = "Maria de Souza",
            };
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

    class Employee : Person, IEmployee, IOnDuty
    {
        public Employee(decimal salario)
        {
            this.Salario = salario;
        }

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

    //class CustomerSon : Customer
    //{

    //}

    //class CustomerGrandSon : CustomerSon
    //{

    //}

    sealed class Customer : Person //não pode ser herdada
    {
        public DateTime? DataUltimaCompra { get; set; }
        public decimal? ValorUltimaCompra { get; set; }

        public override string ToString()
        {
            return $"Nome: {Nome}, Data última compra: {DataUltimaCompra}";
        }
    }

    abstract class Person
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
