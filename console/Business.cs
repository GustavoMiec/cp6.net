using System;
using System.Collections.Generic;

namespace LegacySystem
{
    // Classe Cliente
    public class Cliente
    {
        public int Id { get; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public DateTime Cadastro { get; }

        public Cliente(int id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Cadastro = DateTime.Now;
        }

        public void MudarNome(string novoNome)
        {
            if (!string.IsNullOrWhiteSpace(novoNome))
            {
                Nome = novoNome;
            }
        }

        public void AtualizarEmail(string novoEmail)
        {
            if (!string.IsNullOrWhiteSpace(novoEmail) && novoEmail.Contains("@"))
            {
                Email = novoEmail;
            }
        }

        public void ExibirDados()
        {
            Console.WriteLine($"Id: {Id} Nome: {Nome} Email: {Email} Cadastro: {Cadastro}");
        }
    }

    public class Transacao
    {
        public int Id { get; }
        public decimal Valor { get; }
        public DateTime Data { get; }
        public string Descricao { get; }

        public Transacao(int id, decimal valor, string descricao)
        {
            Id = id;
            Valor = valor;
            Data = DateTime.Now;
            Descricao = descricao;
        }

        public void ExibirTransacao()
        {
            Console.WriteLine($"Id: {Id} Valor: {Valor} Descricao: {Descricao} Data: {Data}");
        }
    }


    public class SistemaTransacoes
    {
        private readonly List<Transacao> _listaDeTransacoes = new List<Transacao>();

        public void AdicionarTransacao(int id, decimal valor, string descricao)
        {
            var transacao = new Transacao(id, valor, descricao);
            _listaDeTransacoes.Add(transacao);
        }

        public void ExibirTransacoes()
        {
            foreach (var transacao in _listaDeTransacoes)
            {
                transacao.ExibirTransacao();
            }
        }
    }

    public class SistemaCliente
    {
        private readonly List<Cliente> _clientes = new List<Cliente>();

        // Propriedade para acessar a lista de clientes
        public IReadOnlyList<Cliente> Clientes => _clientes.AsReadOnly();

        public void AdicionarCliente(int id, string nome, string email)
        {
            _clientes.Add(new Cliente(id, nome, email));
        }

        public void RemoverCliente(int id)
        {
            var cliente = _clientes.Find(c => c.Id == id);
            if (cliente != null)
            {
                _clientes.Remove(cliente);
            }
        }

        public void ExibirTodosOsClientes()
        {
            foreach (var cliente in _clientes)
            {
                cliente.ExibirDados();
            }
        }

        public void AtualizarNomeCliente(int id, string novoNome)
        {
            var cliente = _clientes.Find(c => c.Id == id);
            if (cliente != null)
            {
                cliente.MudarNome(novoNome);
            }
        }
    }

    public class Relatorio
    {
        public void GerarRelatorioCliente(IEnumerable<Cliente> clientes)
        {
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"Cliente: {cliente.Nome} | Email: {cliente.Email}");
            }
        }
    }
}
