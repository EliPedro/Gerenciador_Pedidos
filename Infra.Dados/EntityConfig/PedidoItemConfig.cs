using Dominio.Pedidos.Pedidos;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Dados.EntityConfig
{
    public class PedidoItemConfig : EntityTypeConfiguration<PedidoItem>
    {
        public PedidoItemConfig()
        {
             Property(e => e.Produto)
              .IsUnicode(false);

            Property(e => e.Valor)
             .HasPrecision(18, 0);
        }
    }
}
