using Core.Domain;
using Core.Infra.Interface;
using System;
using System.Threading.Tasks;

namespace Seguranca.Domain.Usuario.Interface
{
    public interface IUsuarioDapperRepository : IDapperRepository<Usuario>
    {
        Task<Result> GetPaging(string nome, Paging paginacao);
        Task<Result> GetUsuarioById(Guid id);
    }
}
