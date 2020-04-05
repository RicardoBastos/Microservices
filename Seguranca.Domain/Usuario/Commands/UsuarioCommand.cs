using Core.Domain;
using System;

namespace Seguranca.Domain.Usuario.Commands
{
    public abstract class UsuarioCommand : Command
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
