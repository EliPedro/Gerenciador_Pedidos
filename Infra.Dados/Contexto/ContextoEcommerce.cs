namespace Infra.Dados.Contexto
{
    using System.Data.Entity;
    using Dominio.Pedidos.Clientes;
    using Dominio.Pedidos.Clientes.ValueObjects;
    using Dominio.Pedidos.Pedidos;
    using Infra.Dados.EntityConfig;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using System;

    public partial class ContextoEcommerce : DbContext
    {
        public ContextoEcommerce()
            : base("name=ContextoEcommerce")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Cliente> Clientes      { get; set; }
        public virtual DbSet<Endereco> Enderecos    { get; set; }
        public virtual DbSet<PedidoItem> PedidoItem { get; set; }
        public virtual DbSet<Pedido> Pedidos        { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new ClienteConfig());
            modelBuilder.Configurations.Add(new EnderecoConfig());
            modelBuilder.Configurations.Add(new PedidoConfig());
            modelBuilder.Configurations.Add(new PedidoItemConfig());   
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
