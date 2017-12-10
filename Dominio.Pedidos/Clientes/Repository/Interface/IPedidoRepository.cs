using Dominio.Pedidos.Pedidos;
using System.Collections.Generic;

namespace Dominio.Pedidos.Clientes.Repository.Interface
{
    public interface IPedidoRepository
    {
        void Adicionar(Pedido pedido);
        IEnumerable<dynamic> ObterPedidosPorPorCliente(int id);
    }
}
