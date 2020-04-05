using Core.Domain;
using Core.Infra.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RH.Domain.Usuario.Interface
{
    public interface IProdutoDapperRepository : IDapperRepository<Usuario>
    {
        Task<Result> GetPaging(string nome, Paging paginacao);
        Task<Result> GetUsuarioById(Guid id);
    }
}
