using Dominio.Pedidos.Clientes.ValueObjects;
using System;
using System.Collections.Generic;

namespace Dominio.Pedidos.Clientes.Repository.Interface
{
    public interface IClienteRepository
    {
        void Adicionar(Cliente cliente);
        IEnumerable<Cliente> ObterTodos();
        Endereco ObterEnderecoPorId(int id);
        Int32 EhValidoCPF(String cpf);
    }
}
