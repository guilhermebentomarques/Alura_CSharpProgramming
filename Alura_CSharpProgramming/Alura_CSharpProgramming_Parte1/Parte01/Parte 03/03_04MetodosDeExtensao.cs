using System;
using System.Collections.Generic;
using System.Text;

namespace Alura_CSharpProgramming_Parte1.Parte01.Parte_03
{
    class _03_04MetodosDeExtensao : IAulaItem
    {
        public void Executar()
        {
            Impressora impressora = new Impressora("Este é\r\no meu documento");
            impressora.ImprimirDocumento();
            ImprimirDocumentoHTML(impressora.Documento);
            impressora.ImprimirDocumentoHTML();
            impressora.ImprimirDocumentoComResumo();
        }

        void ImprimirDocumentoHTML(string documento)
        {
            Console.WriteLine($"<html><body>{documento}</body></html>");
        }
    }

    class Impressora
    {
        public string Documento { get; }

        public Impressora(string documento)
        {
            this.Documento = documento;
        }

        public void ImprimirDocumento()
        {
            Console.WriteLine();
            Console.WriteLine(Documento);
        }

        //public void ImprimirDocumentoHTML()
        //{
        //    Console.WriteLine($"<html><body>{Documento}</body></html>");
        //}
    }

    static class ImpressoraExtensions
    {
        public static void ImprimirDocumentoHTML(this Impressora impressora)
        {
            Console.WriteLine($"<html><body>{impressora.Documento}</body></html>");
        }

        public static void ImprimirDocumentoComResumo(this Impressora impressora)
        {
            Console.WriteLine();
            Console.WriteLine($"{impressora.Documento}\r\nRESUMO\r\n======\r\nO documento tem: {impressora.Documento.Length} caracteres.");
        }
    }
}
