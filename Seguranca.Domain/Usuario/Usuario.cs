using Core.Domain;
using System;

namespace Seguranca.Domain.Usuario
{
    public class Usuario : BaseEntity<Guid>
    {
        public Usuario()
        {
        }

        public Usuario(Guid id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
    }

}
