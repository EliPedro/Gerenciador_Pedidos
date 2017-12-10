using Dominio.Pedidos.Clientes.Repository.Interface;
using System;

namespace Ecommerce.Aplicacao.UnitOfWork.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IClienteRepository ClienteRepository { get; }
        IPedidoRepository  PedidoRepository   { get; }

        void Commit();
    }
}
