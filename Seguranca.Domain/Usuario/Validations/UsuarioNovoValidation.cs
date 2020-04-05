
using Seguranca.Domain.Usuario.Commands;

namespace Seguranca.Domain.Usuario.Validations
{
    public class UsuarioNovoValidation : UsuarioValidation<UsuarioNovoCommand>
    {
        public UsuarioNovoValidation()
        {
            ValidarId();
            ValidarNome();
        }
    }
}
