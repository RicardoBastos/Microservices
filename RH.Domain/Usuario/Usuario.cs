using Core.Domain;
using System;

namespace RH.Domain.Usuario
{
    public class Usuario : BaseEntity<Guid>
    {
        public Usuario()
        {
        }

        public Usuario(Guid id, string nome, decimal salario, string email)
        {
            Id = id;
            Nome = nome;
            Salario = salario;
            Email = email;
        }

        public string Nome { get; private set; }
        public decimal Salario { get; private set; }
        public string Email { get; private set; }
    }

}
