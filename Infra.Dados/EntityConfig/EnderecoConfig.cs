using Dominio.Pedidos.Clientes.ValueObjects;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Dados.EntityConfig
{
    public class EnderecoConfig :  EntityTypeConfiguration<Endereco>
    {

        public EnderecoConfig()
        { 
           Property(e => e.CEP)
           .IsUnicode(false);
           
           Property(e => e.Bairro)
           .IsUnicode(false);
           
           Property(e => e.Cidade)
           .IsUnicode(false);
           
           Property(e => e.Estado)
           .IsUnicode(false);
           
           Property(e => e.Logradouro)
           .IsUnicode(false);

            ToTable("Enderecos");
        }
    }
}
