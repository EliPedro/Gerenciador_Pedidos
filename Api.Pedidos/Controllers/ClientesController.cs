using Api.Pedidos.Utils;
using Dominio.Pedidos.Clientes;
using Dominio.Pedidos.Clientes.ValueObjects;
using Dominio.Pedidos.DTO;
using Ecommerce.Aplicacao.UnitOfWork.Interface;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.ServiceModel.Activation;
using System.Web.Http;

namespace Api.Pedidos.Controllers
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ClientesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpPost]
        public IEnumerable<Cliente> ObterTodos()
        {
            return _unitOfWork.ClienteRepository.ObterTodos();
        }
        
        [HttpPost]
        public void Adicionar(ClienteDTO cliente)
        {

            var novoCliente = new Cliente().ToCliente(cliente);
            _unitOfWork.ClienteRepository.Adicionar(novoCliente);
            _unitOfWork.Commit();

        }

        [HttpPost]
        public Int32 EhValidoCPF(string cpf)
        {
            if(new CPF(cpf).IsValid())
            {
                return _unitOfWork.ClienteRepository.EhValidoCPF(cpf);
            }

            return (Int32)Erro.INVALIDO;
        }

        [HttpPost]
        public Endereco ObterEndereco(int id)
        {
            return _unitOfWork.ClienteRepository.ObterEnderecoPorId(id);
        }
    }
}
