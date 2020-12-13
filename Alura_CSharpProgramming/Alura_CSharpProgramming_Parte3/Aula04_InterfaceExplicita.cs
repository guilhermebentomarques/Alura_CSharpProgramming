using System;
using System.Collections.Generic;
using System.Text;

namespace Alura_CSharpProgramming_Parte3
{
    class Aula04_InterfaceExplicita
    {
        public void Run()
        {
            Colaborador colaborador = new Colaborador(1500);
            colaborador.CPF = "123.456.789-00";
            colaborador.Nome = "123.456.789-00";
            colaborador.DataNascimento = DateTime.Now;

            ((IColaborador)colaborador).CargaHorariaMensal = 168;
            ((IPlantonista)colaborador).CargaHorariaMensal = 32;
            colaborador.EfetuarPagamento();
            colaborador.CrachaGerado += (s, e) =>
            {
                Console.WriteLine("Crachá gerado");
            };
            ((IColaborador)colaborador).GerarCracha();
            ((IPlantonista)colaborador).GerarCracha();
        }
    }

    interface IColaborador
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

    interface IPlantonista
    {
        int CargaHorariaMensal { get; set; }
        void GerarCracha();
    }

    class Colaborador : IColaborador, IPlantonista
    {
        public Colaborador(decimal salario)
        {
            this.Salario = salario;
        }

        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        public event EventHandler CrachaGerado;
        void IColaborador.GerarCracha()
        {

        }
        void IPlantonista.GerarCracha()
        {

        }
        public decimal Salario { get; set; }
        int IColaborador.CargaHorariaMensal { get; set; }
        int IPlantonista.CargaHorariaMensal { get; set; }
        public void EfetuarPagamento()
        {

        }
    }
}
