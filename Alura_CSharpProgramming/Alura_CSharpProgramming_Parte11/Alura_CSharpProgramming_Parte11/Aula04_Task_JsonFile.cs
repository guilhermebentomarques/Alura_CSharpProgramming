using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Alura_CSharpProgramming_ParteZ11
{
    class Aula04_Task_JsonFile
    {
        static void Metodo()
        {
            IEnumerable<Filme> filmes =
                JsonConvert.DeserializeObject<IEnumerable<Filme>>(File.ReadAllText("filmes.json"));

            var query =
                   from f in filmes
                   select new Filme
                   {
                       Titulo = f.Titulo,
                       Orcamento = f.Orcamento,
                       Genero = f.Genero,
                       Autor = f.Autor,
                       Faturamento = f.Faturamento,
                       Lucro = (f.Faturamento - f.Orcamento),
                       PorcentagemFaturamento = ((f.Faturamento - f.Lucro) / f.Orcamento)
                   };

            //CONSULTA 1
            Console.WriteLine("Filmes de Ação - Normal");
            var consulta1 =
                from f in filmes
                where f.Genero == "Ação"
                select f;

            //CONSULTA 2 - as parallel
            Console.WriteLine("Filmes de Ação - as parallel");
            var consulta2 =
                from f in filmes.AsParallel()
                where f.Genero == "Ação"
                select f;

            //CONSULTA 3 - Execução default
            Console.WriteLine("Filmes de Ação - execução default");
            var consulta3 =
                from f in filmes.AsParallel()
                .WithExecutionMode(ParallelExecutionMode.Default)
                where f.Genero == "Ação"
                select f;

            //CONSULTA 4 - Execução force paralelism
            Console.WriteLine("Filmes de Ação - force paralelismo");
            var consulta4 =
                from f in filmes.AsParallel()
                .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                where f.Genero == "Ação"
                select f;

            //CONSULTA 5 - Execução grau de paralelismo
            Console.WriteLine("Filmes de Ação - grau de paralelismo");
            var consulta5 =
                from f in filmes.AsParallel()
                .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                .WithDegreeOfParallelism(4)
                where f.Genero == "Ação"
                select f;

            //CONSULTA 6 - Execução grau de paralelismo
            Console.WriteLine("Filmes de Ação - grau de paralelismo");
            var consulta6 =
                from f in filmes
                .AsParallel()
                .AsOrdered()
                where f.Genero == "Ação"
                select f;

            //CONSULTA 7 - Execução grau de paralelismo
            Console.WriteLine("Filmes de Ação - grau de paralelismo");
            var consulta7 =
                (from f in filmes.AsParallel()
                 where f.Genero == "Ação"
                 orderby f.Faturamento descending
                 select f).Take(4);

            //CONSULTA 8 - Execução grau de paralelismo
            Console.WriteLine("Filmes de Ação - grau de paralelismo");
            var consulta8 =
                from f in filmes.AsParallel()
                where f.Genero == "Ação"
                select f;

            consulta8.ForAll(filme =>
            {
                Console.WriteLine(filme.Titulo);
            });

            Console.WriteLine("Término do processamento. Tecle [ENTER] para terminar.");
            Console.ReadLine();
        }

        static void Processar(object item)
        {
            Console.WriteLine("Começando a trabalhar com " + item);
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("Terminando a trabalhar com " + item);
            Console.WriteLine("");
        }
    }

    public class Filme
    {
        public string Titulo { get; set; }
        public decimal Orcamento { get; set; }
        public decimal Faturamento { get; set; }
        public decimal Lucro { get; set; }
        public decimal PorcentagemFaturamento { get; set; }
        public string Genero { get; set; }
        public string Autor { get; set; }
    }
}
