using System;

namespace RH.Domain.Usuario.Queries
{
    public class UsuarioQuery
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Salario { get; set; }
        public string Email { get; set; }
    }
}
