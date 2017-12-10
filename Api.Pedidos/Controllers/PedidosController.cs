using Dominio.Pedidos.Pedidos;
using Ecommerce.Aplicacao.UnitOfWork.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Pedidos.Controllers
{
    public class PedidosController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public PedidosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        [HttpPost]
        public IEnumerable<dynamic> ObterPedidosPorPorCliente(int id)
        {
            return _unitOfWork.PedidoRepository.ObterPedidosPorPorCliente(id);
        }

        [HttpPost]
        public void Adicionar(Pedido pedido)
        {

            _unitOfWork.PedidoRepository.Adicionar(pedido);
            _unitOfWork.Commit();
        }
    }
}
