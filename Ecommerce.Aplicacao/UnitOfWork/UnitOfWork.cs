using Dominio.Pedidos.Clientes.Repository.Interface;
using Ecommerce.Aplicacao.UnitOfWork.Interface;
using Infra.Dados.Contexto;
using Infra.Dados.Repository;
using System;

namespace Ecommerce.Aplicacao.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposedValue = false;
        private readonly ContextoEcommerce _ContextoEcommerce;
        
        public IClienteRepository _clienteRepository;
        public IPedidoRepository  _pedidoRepository;

        public UnitOfWork(ContextoEcommerce contextoEcommerce)
        {
            _ContextoEcommerce = contextoEcommerce;
        }


        public IClienteRepository ClienteRepository
        {
            get => (_clienteRepository == null) ? new ClienteRepository(_ContextoEcommerce) : _clienteRepository;
        }
        public IPedidoRepository PedidoRepository
        {
            get => (_pedidoRepository == null) ? new PedidoRepository(_ContextoEcommerce) : _pedidoRepository;

        }

        public void  Commit()
        {
            _ContextoEcommerce.SaveChanges();
        }

        #region IDisposable 
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _ContextoEcommerce.Dispose();
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion


    }
}
