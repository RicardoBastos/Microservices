using Core.Infra.Interface;

namespace RH.Domain.Usuario.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario BuscarEmail(string email);

        void InserirUsuarioRead(Usuario entity);
    }
}
