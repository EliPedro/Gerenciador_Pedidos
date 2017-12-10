using System.Collections.Generic;
using Dominio.Pedidos.Pedidos;
using Dominio.Pedidos.Clientes.ValueObjects;
using System;
using Dominio.Pedidos.DTO;

namespace Dominio.Pedidos.Clientes
{
    public class Cliente
    {
        public Cliente()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int      ClienteId    { get; set; }
        public string   Nome         { get; set; }
        public CPF      CPF          { get; set; }
        public int      EnderecoId   { get; set; }
        public Endereco Endereco     { get; set; }
        public string   Email        { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }


        public Cliente ToCliente(ClienteDTO cliente)
        {
            this.Nome = cliente.Nome;
            this.CPF = new CPF(cliente.CPF);
            this.Email = cliente.Email;
            this.Endereco = new Endereco
            {
                CEP        = cliente.Endereco.CEP,
                Bairro     = cliente.Endereco.Bairro,
                Cidade     = cliente.Endereco.Cidade,
                Estado     = cliente.Endereco.Estado,
                Logradouro = cliente.Endereco.Logradouro,
                Numero     = cliente.Endereco.Numero
            };

            return this;
        }
    }
}
