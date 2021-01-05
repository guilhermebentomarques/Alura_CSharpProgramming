//#define RELATORIO_RESUMIDO
#define RELATORIO_DETALHADO

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Alura_CSharpProgramming_Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Relatorio relatorio = new Relatorio("Relatório de vendas");
            relatorio.Imprimir();

            if (Attribute.IsDefined(typeof(Venda), typeof(SerializableAttribute)))
            {
                Console.WriteLine("A classe venda DEFINE o atributo Serializable");
            }
            else
            {
                Console.WriteLine("A classe venda NÃO DEFINE o atributo Serializable");
            }
        }
    }

    interface IRelatorio
    {
        public string Nome { get; set; }
        void Imprimir();
    }

    class Relatorio : IRelatorio
    {
        public string Nome { get; set; }

        readonly IList<Venda> vendas;

        public Relatorio(string nome)
        {
            this.Nome = nome;
            vendas = null; // CARREGAR JSON
        }

        public void Imprimir()
        {
            Cabecalho();
            //#if RELATORIO_RESUMIDO
            ListagemResumida();
            //#endif
            //#if RELATORIO_DETALHADO
            ListagemDetalhada();
            //#endif
            Console.WriteLine();
        }

        [Conditional("RELATORIO_RESUMIDO")]
        [Conditional("RELATORIO_DETALHADO")]
        void Cabecalho()
        {
            Console.WriteLine("Cabecalho");
        }

        [Conditional("RELATORIO_RESUMIDO")]
        void ListagemResumida()
        {
            Console.WriteLine("Listagem Resumida");

            Attribute a = Attribute.GetCustomAttribute(typeof(Venda), typeof(FormatoResumidoAttribute));
            FormatoResumidoAttribute formatoResumido = (FormatoResumidoAttribute)a;

            Console.WriteLine(formatoResumido.Formato, "a", "b", 10, "d");
        }

        [Conditional("RELATORIO_DETALHADO")]
        void ListagemDetalhada()
        {
            Console.WriteLine("Listagem Detalhada");

            Attribute a = Attribute.GetCustomAttribute(typeof(Venda), typeof(FormatoDetalhadoAttribute));
            FormatoDetalhadoAttribute formatoDetalhado = (FormatoDetalhadoAttribute)a;

            Console.WriteLine(formatoDetalhado.Formato, "a", "b", "c", "d", 10, "f");
            
        }
    }

    [Serializable]
    [FormatoResumido("{0,-12} {1,-12} {2,12:c} {3,-12}")]
    [FormatoDetalhado("{0,-12} {1,-12} {2,-12} {3,-12} {4,-12:c} {5,-12}")]
    class Venda
    {
        public int Preco;
        [NonSerialized]
        public string Nome;
        public string Produto;
        public string Data;
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    class FormatoResumidoAttribute : Attribute
    {
        public string Formato { get; }

        public FormatoResumidoAttribute(string formato)
        {
            this.Formato = formato;
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    class FormatoDetalhadoAttribute : Attribute
    {
        public string Formato { get; }

        public FormatoDetalhadoAttribute(string formato)
        {
            this.Formato = formato;
        }
    }
}
