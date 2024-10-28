using System;


namespace LegacySystem
{
    class MainSistema
    {
        private const int ClienteJoaoId = 1;
        private const int ClienteMariaId = 2;

        private const decimal TransacaoCompraProdutoValor = 100.50m;
        private const decimal TransacaoCompraServicoValor = 200.00m;
        private const decimal TransacaoCompraSoftwareValor = 300.75m;

        static void Main(string[] args)
        {
            var sistemaCliente = new SistemaCliente();
            AdicionarClientes(sistemaCliente);

            var sistemaTransacoes = new SistemaTransacoes();
            AdicionarTransacoes(sistemaTransacoes);

            ExibirInformacoes(sistemaCliente, sistemaTransacoes);

            sistemaCliente.RemoverCliente(ClienteJoaoId);
            sistemaCliente.ExibirTodosOsClientes();

            sistemaCliente.AtualizarNomeCliente(ClienteMariaId, "Maria Silva");

            var relatorio = new Relatorio();
            relatorio.GerarRelatorioCliente(sistemaCliente.Clientes);

            ExibirSomaValoresExemplo();
        }

        #region Métodos de Inicialização

        private static void AdicionarClientes(SistemaCliente sistemaCliente)
        {
            sistemaCliente.AdicionarCliente(ClienteJoaoId, "João", "joao@email.com");
            sistemaCliente.AdicionarCliente(ClienteMariaId, "Maria", "maria@email.com");
        }

        private static void AdicionarTransacoes(SistemaTransacoes sistemaTransacoes)
        {
            sistemaTransacoes.AdicionarTransacao(1, TransacaoCompraProdutoValor, "Compra de Produto");
            sistemaTransacoes.AdicionarTransacao(2, TransacaoCompraServicoValor, "Compra de Serviço");
            sistemaTransacoes.AdicionarTransacao(3, TransacaoCompraSoftwareValor, "Compra de Software");
        }

        #endregion

        private static void ExibirInformacoes(SistemaCliente sistemaCliente, SistemaTransacoes sistemaTransacoes)
        {
            sistemaCliente.ExibirTodosOsClientes();
            sistemaTransacoes.ExibirTransacoes();
        }

        private static void ExibirSomaValoresExemplo()
        {
            int soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += i;
            }

            Console.WriteLine("Soma total: " + soma);
        }
    }
}
