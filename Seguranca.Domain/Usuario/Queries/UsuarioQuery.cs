using System;

namespace Seguranca.Domain.Usuario.Queries
{
    public class UsuarioQuery
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
