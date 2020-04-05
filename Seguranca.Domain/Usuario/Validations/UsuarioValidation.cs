using FluentValidation;
using Seguranca.Domain.Usuario.Commands;
using System;

namespace Seguranca.Domain.Usuario.Validations
{
    public abstract class UsuarioValidation<T> : AbstractValidator<T> where T : UsuarioCommand
    {
        public void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Por favor, digite o nome do usuário")
                .Length(2, 150).WithMessage("O Nome precisa ter entre 2 a 150 caracteres");
        }


        public void ValidarId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

    }
}
