using System.Collections.Generic;
using Dominio.Pedidos.Clientes.Repository.Interface;
using Dominio.Pedidos.Pedidos;
using Infra.Dados.Contexto;
using System.Linq;

namespace Infra.Dados.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly ContextoEcommerce _contextoEcommerce;

        public PedidoRepository(ContextoEcommerce contextoEcommerce)
        {
            _contextoEcommerce = contextoEcommerce;

        }
        public void Adicionar(Pedido pedido)
        {
            _contextoEcommerce.Pedidos.Add(pedido);
        }
        
        public IEnumerable<dynamic> ObterPedidosPorPorCliente(int id)
        {
            return (from  pedido     in _contextoEcommerce.Pedidos
                     join pedidoItem in _contextoEcommerce.PedidoItem on pedido.PedidoId equals pedidoItem.PedidoId
                     where pedido.ClienteId == id
                     select new 
                     {
                         PedidoId = pedido.PedidoId,
                         Descricao = pedido.Descricao,
                         DataCadastro = pedido.DataCadastro,
                         PedidoItem = pedidoItem,
                     });
            }     
    }
}
