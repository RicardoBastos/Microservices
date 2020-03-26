using FluentValidation.Results;
using RH.Domain.Usuario.Validations;

namespace RH.Domain.Usuario.Commands
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
