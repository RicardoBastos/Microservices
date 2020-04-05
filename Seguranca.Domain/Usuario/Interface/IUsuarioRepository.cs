using Core.Infra.Interface;

namespace Seguranca.Domain.Usuario.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario BuscarEmail(string email);

        void InserirUsuarioRead(Usuario entity);
    }
}
