using Alura_CSharpProgramming_Parte1.Parte01.Parte_01;
using Alura_CSharpProgramming_Parte1.Parte01.Parte_02;
using Alura_CSharpProgramming_Parte1.Parte01.Parte_03;
using Alura_CSharpProgramming_Parte1.Parte01.Parte_04;
using Alura_CSharpProgramming_Parte1.Parte01.Parte_05;
using Alura_CSharpProgramming_Parte1.Parte01.Parte_06;
using Alura_CSharpProgramming_Parte1.Parte01.Parte_07;
using System;
using System.Collections.Generic;

namespace Alura_CSharpProgramming_Parte1
{
    class Program
    {
        static IList<MenuItem> menuItems;
        static void Main(string[] args)
        {
            IAulaItem itemSelecionado;
            menuItems = GetMenuItems();

            while (true)
            {
                ImprimirMenuItems(menuItems);
                var opcao = Console.ReadLine();

                int.TryParse(opcao, out int valorOpcao);

                if (valorOpcao == 0)
                {
                    break;
                }

                if (valorOpcao > menuItems.Count)
                {
                    break;
                }

                itemSelecionado = Executar(valorOpcao);
                Console.ReadKey();
            }
        }

        private static IAulaItem Executar(int valorOpcao)
        {
            IAulaItem itemSelecionado;
            MenuItem menuItem = menuItems[valorOpcao - 1];
            Type tipoClasse = menuItem.TipoClasse;
            itemSelecionado = (IAulaItem)Activator.CreateInstance(tipoClasse);

            Console.WriteLine();
            string titulo = $"EXECUTANDO: {menuItem.Titulo}";
            Console.WriteLine(titulo);
            Console.WriteLine(new string('=', titulo.Length));

            itemSelecionado.Executar();
            Console.WriteLine();
            Console.WriteLine("Tecle algo para continuar...");
            return itemSelecionado;
        }

        private static void ImprimirMenuItems(IList<MenuItem> menuItems)
        {
            int i = 1;
            Console.WriteLine("SELECIONE UMA OPÇÃO");
            Console.WriteLine("===================");
            Console.WriteLine("0 - Sair");
            foreach (var menuItem in menuItems)
            {
                Console.WriteLine((i++).ToString() + " - " + menuItem.Titulo);
            }
        }

        private static IList<MenuItem> GetMenuItems()
        {
            return new List<MenuItem>
            {
                new MenuItem("Tipos de Valor", typeof(_01_TiposDeValor)),
                new MenuItem("Tipos Inteiros", typeof(_02_Inteiros)),
                new MenuItem("Ponto Flututante", typeof(_03PontoFlutuante)),
                new MenuItem("Decimal", typeof(_04Decimal)),
                new MenuItem("Booleanos", typeof(_05Booleano)),
                new MenuItem("Estruturas", typeof(Estruturas)),
                new MenuItem("Enumeracoes", typeof(_07Enums)),
                new MenuItem("Tipos de Refêrencia", typeof(_02_01_TiposReferencia)),
                new MenuItem("Classes", typeof(_02_02Classes)),
                new MenuItem("Interfaces", typeof(_02_03Interfaces)),
                new MenuItem("Delegates", typeof(_02_04Delegates)),
                new MenuItem("Objetos", typeof(_02_05Objetos)),
                new MenuItem("Dinâmicos", typeof(_02_06Dinamicos)),
                new MenuItem("Strings", typeof(_02_07Strings)),
                new MenuItem("Metodos", typeof(_03_01Metodos)),
                new MenuItem("Parâmetros Nomeados", typeof(_03_02ParametroNomeados)),
                new MenuItem("Parâmetros Opcionais", typeof(_03_03ParametrosOpcionais)),
                new MenuItem("Métodos de Extensão", typeof(_03_04MetodosDeExtensao)),
                new MenuItem("Propriedades Indexadas", typeof(_03_05PropriedadesIndexadas)),
                new MenuItem("Sobrecargas", typeof(_04_01MetodosSobrecarregados)),
                new MenuItem("Métodos Substituidos", typeof(_04_02MetodosSubstituidos)),
                new MenuItem("Boxing", typeof(_05_01_Boxing)),
                new MenuItem("Unboxing", typeof(_05_02_Unboxing)),
                new MenuItem("Conversoes Implícitas", typeof(_06_01_ConversoesImplicitas)),
                new MenuItem("Conversoes Explícitas", typeof(_06_02_ConversoesExplicitas)),
                new MenuItem("Operadores IS e AS", typeof(_06_03_OperadoresIseAs)),
                new MenuItem("Operadores de Conversão", typeof(_06_04_OperadoresDeConversao)),
                new MenuItem("Métodos Auxiliares de Conversão", typeof(_06_05_MetodosAuxiliares)),
                new MenuItem("Usando Dynamic", typeof(_07_01_UsandoDynamic)),
                new MenuItem("Conversões de Dynamic", typeof(_07_02_ConversoesDeDynamic)),
                new MenuItem("Resolucão de Sobrecarga", typeof(_07_03_ResolucaoSobrecarga)),
                new MenuItem("Usando ExpandObject", typeof(_07_04_UsandExpandObject)),
                new MenuItem("Interoperabilidade COM", typeof(_07_05_InteropCOM))                
            };
        }
    }

    class MenuItem
    {
        public MenuItem(string titulo, Type tipoClasse)
        {
            Titulo = titulo;
            TipoClasse = tipoClasse;
        }

        public string Titulo { get; set; }
        public Type TipoClasse { get; set; }
    }
}
