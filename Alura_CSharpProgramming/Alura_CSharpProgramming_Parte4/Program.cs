using System;
using System.IO;

namespace Alura_CSharpProgramming_Parte4
{
    class Program
    {
        static void Main(string[] args)
        {
            //ContaBancaria conta = new ContaBancaria(100);
            //conta.SacarDinheiro(35);
            //conta.SacarDinheiro(150);

            Emprestimo emprestimo = new Emprestimo("A1234");
            emprestimo.OnPrazoMaximoEstourado += Emprestimo_OnPrazoMaximoEstourado;
            emprestimo.Prazo = 3;
            emprestimo.Prazo = 7;
            emprestimo.CalcularJuros(6000, 3);
            emprestimo.CalcularJuros(8500, 6);
            emprestimo.CalcularJuros(11500, 4);
            //emprestimo.finalizar();

        }

        private static void Emprestimo_OnPrazoMaximoEstourado(object source, EventArgs e)
        {
            Console.WriteLine("Prazo Estourado");
        }
    }

    public class ContaBancaria
    {
        private decimal saldo = 0m;

        public ContaBancaria(decimal saldo)
        {
            this.saldo = saldo;
            Console.WriteLine(this);
        }

        public ResultadoOperacao SacarDinheiro(decimal quantia)
        {
            if (saldo < quantia)
            {
                Console.WriteLine("Saldo Insuficiente.");
                return ResultadoOperacao.SaldoInsuficiente;
            }

            //sacar(quantia);
            return ResultadoOperacao.Sucesso;
            ImprimirComprovante();
        }

        private bool TemSaldoSuficiente(decimal quantia)
        {
            return quantia <= saldo;
        }

        private void ImprimirComprovante()
        {

        }

    }

    public enum ResultadoOperacao
    {
        OperacaoIniciada = 0,
        SaldoInsuficiente = 1,
        Sucesso = 2,
        ErroNaoTemDinheiro = 3,
        ErroComunicacaoServidor = 4,
    }

    class CaixaEletronico
    {
        public ContaBancaria Conta { get; set; }

        public CaixaEletronico(ContaBancaria conta)
        {
            this.Conta = conta;
        }

        public void Sacar(decimal quantia)
        {
            ContaBancaria conta = new ContaBancaria(1000);
            var resultado = Conta.SacarDinheiro(quantia);

            switch (resultado)
            {
                case ResultadoOperacao.OperacaoIniciada:
                    Console.WriteLine("Resultado: Operação Iniciada.");
                    break;
                case
                    ResultadoOperacao.SaldoInsuficiente:
                    Console.WriteLine("Resultado: Saldo Insuficiente.");
                    break;
                case
                    ResultadoOperacao.Sucesso:
                    Console.WriteLine("Resultado: Sucesso.");
                    break;
                case
                    ResultadoOperacao.ErroNaoTemDinheiro:
                    Console.WriteLine("Resultado: Erro não tem dinheiro.");
                    break;
                case
                    ResultadoOperacao.ErroComunicacaoServidor:
                    Console.WriteLine("Resultado: Erro de comunicação com o servidor.");
                    break;
                default:
                    Console.WriteLine("Resultado: Erro Desconhecido.");
                    break;
            }
        }
    }

    class Emprestimo
    {
        private int prazo;
        private const int PRAZO_MAXIMO_PAGAMENTOS_ANOS = 5;
        private const decimal JUROS = 0.034m;
        private const string ARQUIVO_LOG_TESTE = @"monitoramento/logs.txt";
        private const string ARQUIVO_LOG_PRODUCAO = @"prod/logs.txt";
        private string codigoContrato { get; set; }

        public Emprestimo(string codigoContrato)
        {
            if (ValidarCodigo(codigoContrato))
            {
                this.codigoContrato = codigoContrato;
                Console.WriteLine($"Novo Emprestimo: {codigoContrato}");
            }
            else
            {
                //Lançar uma exceção
            }
        }

        public decimal CalcularJuros(decimal valor, int prazo)
        {
            decimal valorJuros;
            decimal taxaJuros = 0;

            if (prazo > 0 && prazo < 5 && valor < 7000)
            {
                taxaJuros = 0.035m;
            }
            else if (prazo > 5 && valor > 7000)
            {
                taxaJuros = 0.075m;
            }
            else
            {
                taxaJuros = 0.085m;
            }

            valorJuros = valor * taxaJuros * prazo;
            Console.WriteLine($"valorJuros: {valorJuros}");
            GravarLog($"O valor calculado dos juros é: {valorJuros}");
            return valorJuros;
        }

        public void GravarLog(string mensagem)
        {
            const bool DEBUG = true;

            string arquivo = "";
#if (DEBUG)
            arquivo = ARQUIVO_LOG_TESTE;
#else
            arquivo = ARQUIVO_LOG_PRODUCAO;
#endif

            Directory.CreateDirectory(Path.GetDirectoryName(arquivo));
            using (var writer = new StreamWriter(arquivo, append: true))
            {
                writer.WriteLine(mensagem);
            }
        }

        public void Finalizar()
        {
            AvaliarEmprestimo();
            ProcessarEmprestimo();
            FinanciarEmprestimo();
        }

        private bool ValidarCodigo(string codigoContrato)
        {
            bool codigoContratoValido = true;
            foreach (var caractere in codigoContrato)
            {
                bool numerico = Char.IsDigit(caractere);
                bool maiuscula = Char.IsUpper(caractere);
                bool valido = numerico || maiuscula;
                if (!(valido))
                {
                    codigoContratoValido = false;
                    break;
                }
            }

            return codigoContratoValido;
        }

        public event PrazoMaximoEstrouradoHandler OnPrazoMaximoEstourado;

        public int Prazo
        {
            get { return prazo; }
            set
            {
                //se o novo prazo for maior que o prazo máximo
                //lançar um evento de "prazo estourado"
                //senão, definir novo prazo.
                if (value > PRAZO_MAXIMO_PAGAMENTOS_ANOS)
                {
                    OnPrazoMaximoEstourado?.Invoke(this, new EventArgs());
                    return;
                }
                prazo = value;
                Console.WriteLine($"Novo Prazo: {prazo}");
            }
        }

    }

    public delegate void PrazoMaximoEstrouradoHandler(object source, EventArgs e);
}
