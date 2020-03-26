
using RH.Domain.Usuario.Commands;

namespace RH.Domain.Usuario.Validations
{
    public class UsuarioNovoValidation : UsuarioValidation<UsuarioNovoCommand>
    {
        public UsuarioNovoValidation()
        {
            ValidarId();
            ValidarNome();
            ValidarSalario();
        }
    }
}
