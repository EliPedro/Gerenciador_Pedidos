using Dominio.Pedidos.Clientes.Repository.Interface;
using Ecommerce.Aplicacao.UnitOfWork;
using Ecommerce.Aplicacao.UnitOfWork.Interface;
using Infra.Dados.Contexto;
using Infra.Dados.Repository;
using SimpleInjector;

namespace Infra.CrossCutting.IoC.loC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            container.Register<ContextoEcommerce>(Lifestyle.Scoped); 
            container.Register<IClienteRepository>(() => new ClienteRepository(new ContextoEcommerce()),Lifestyle.Scoped);
            container.Register<IPedidoRepository>(() => new PedidoRepository(new ContextoEcommerce()),Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped); 
        }
    }
}
