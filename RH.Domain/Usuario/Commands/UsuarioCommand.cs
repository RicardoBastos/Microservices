using Core.Domain;
using System;

namespace RH.Domain.Usuario.Commands
{
    public abstract class UsuarioCommand : Command
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public decimal Salario { get; set; }
    }
}
