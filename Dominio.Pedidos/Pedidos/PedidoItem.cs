namespace Dominio.Pedidos.Pedidos
{
    public class PedidoItem
    {
        public int     PedidoItemId    { get; set; }
        public string  Produto         { get; set; }
        public decimal Valor           { get; set; }
        public int     Quantidade      { get; set; }
        public int     PedidoId        { get; set; }
        public virtual Pedido Pedidos { get; set; }
    }
}
