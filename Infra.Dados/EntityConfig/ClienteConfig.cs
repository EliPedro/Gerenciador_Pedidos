using Dominio.Pedidos.Clientes;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Dados.EntityConfig
{
    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            Property(f => f.CPF.Codigo)
               .HasColumnName("CPF");

            Property(e => e.Nome)
            .IsUnicode(false);

            Property(e => e.CPF.Codigo)
                .IsUnicode(false);

            Property(e => e.Email)
                .IsUnicode(false);

            ToTable("Clientes");
        }
    }
}
