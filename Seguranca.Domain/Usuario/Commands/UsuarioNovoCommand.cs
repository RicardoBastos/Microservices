using FluentValidation.Results;
using Seguranca.Domain.Usuario.Commands;
using Seguranca.Domain.Usuario.Validations;

namespace Seguranca.Domain.Usuario.Commands
{
    public class UsuarioNovoCommand : UsuarioCommand
    {
        public UsuarioNovoCommand()
        {

        }

        public override bool IsValid()
        {
            ValidationResult = new UsuarioNovoValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
