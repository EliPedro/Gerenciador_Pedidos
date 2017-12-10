using Dominio.Pedidos.Clientes;
using System;
using System.Collections.Generic;

namespace Dominio.Pedidos.Pedidos
{
    public class Pedido
    {
        public Pedido()
        {
            PedidoItem = new HashSet<PedidoItem>();
        }
        public int  PedidoId { get; set; }
        public string Descricao { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual ICollection<PedidoItem> PedidoItem { get; set; }
    }
}
