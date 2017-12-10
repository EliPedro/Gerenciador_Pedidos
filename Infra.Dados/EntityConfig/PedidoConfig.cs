using Dominio.Pedidos.Pedidos;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Dados.EntityConfig
{
    public class PedidoConfig : EntityTypeConfiguration<Pedido>
    {
        public PedidoConfig()
        {
            Property(e => e.Descricao)
              .IsUnicode(false);

            ToTable("Pedidos");
        }  
    }
}
