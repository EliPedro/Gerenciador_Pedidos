using System.Collections.Generic;
using Dominio.Pedidos.Clientes;
using Dominio.Pedidos.Clientes.Repository.Interface;
using Infra.Dados.Contexto;
using System.Linq;
using Dominio.Pedidos.Clientes.ValueObjects;
using Dapper;
using Infra.Dados.Utils;

namespace Infra.Dados.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ContextoEcommerce _contextoEcommerce;
        public ClienteRepository(ContextoEcommerce contextoEcommerce)
        {
            _contextoEcommerce = contextoEcommerce;
        }
        public void Adicionar(Cliente cliente)
        {
            _contextoEcommerce.Clientes.Add(cliente);
        }

        public int EhValidoCPF(string cpf)
        {
            var pesquisa = _contextoEcommerce.Database.Connection.Query<string>($"SELECT CPF  FROM Clientes WHERE CPF = '{cpf}'").AsList();
            
            if (pesquisa.Count > 0) return (int)Erro.CPF_JA_CADASTRADO;

            return (int)Erro.CPF_NAO_CADASTRADO;
        }

        public Endereco ObterEnderecoPorId(int id)
        {
            return _contextoEcommerce.Enderecos.FirstOrDefault(e => e.EnderecoId == id);
        }
        
        public IEnumerable<Cliente> ObterTodos()
        {
            return _contextoEcommerce.Clientes.ToList();
        }
        
    }
}
