using Dominio.Pedidos.Clientes.ValueObjects;

namespace Dominio.Pedidos.DTO
{
    public class ClienteDTO
    {
        public string   Nome     { get; set; }
        public string   CPF      { get; set; }
        public Endereco Endereco { get; set; }
        public string   Email    { get; set; }

    }
}
