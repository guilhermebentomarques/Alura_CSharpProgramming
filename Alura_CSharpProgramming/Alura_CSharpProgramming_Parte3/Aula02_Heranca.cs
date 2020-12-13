using System;
using System.Collections.Generic;
using System.Text;

namespace Alura_CSharpProgramming_Parte3
{
    class Aula02_Heranca
    {
        public void Run()
        {
            ContaCorrente cc = new ContaCorrente();
            cc.Saldo = 1000;
            Console.WriteLine(cc.Saldo);
        }
    }

    public class Conta
    {
        internal decimal Saldo { get; set; }

        public Conta()
        {
            this.Saldo = 1000;
            Console.WriteLine(this.Saldo);
        }

        void Sacar(decimal saque)
        {
            Saldo = Saldo - saque;
        }
    }

    public class ContaCorrente : Conta
    {
        public ContaCorrente()
        {
            this.Saldo = 1000;
            Console.WriteLine(this.Saldo);
        }
    }
}
