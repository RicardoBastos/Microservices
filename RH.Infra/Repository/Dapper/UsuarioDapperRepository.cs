using Core.Domain;
using Core.Infra;
using Dapper;
using Microsoft.Extensions.Configuration;
using RH.Domain.Usuario;
using RH.Domain.Usuario.Interface;
using RH.Domain.Usuario.Queries;
using System;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Infra.Repository.Dapper
{
    public class UsuarioDapperRepository : DapperRepositoryBase<Usuario>, IUsuarioDapperRepository
    {
        public UsuarioDapperRepository(IConfiguration configuration) : base(configuration) { }
        public Result result = new Result();



        public async Task<Result> GetUsuarioById(Guid id)
        {
            result.data = await conn.QueryFirstOrDefaultAsync<UsuarioQuery>(
                @"select * from usuario where id = @Id", param: new { Id = id });

            return result;
        }


        public async Task<Result> GetPaging(string nome, Paging paginacao)
        {
            var query = new StringBuilder();
            dynamic param = new ExpandoObject();

            param.nome = nome;
            param.top = paginacao.Top > 0 ? paginacao.Top : 10;
            param.skip = paginacao.Skip >= 0 ? paginacao.Skip : 0;
            param.orderBy = string.IsNullOrEmpty(paginacao.OrderBy) ? "nome" : paginacao.OrderBy;
            param.orderDirection = string.IsNullOrEmpty(paginacao.OrderDirection) ? "asc" : paginacao.OrderDirection;


            query.AppendLine(@"select
                                   u.id,
                                   u.nome,
                                   u.email,
                                   u.salario
                               from usuario u where 1=1");


            if (!string.IsNullOrWhiteSpace(nome))
                query.AppendLine("AND u.[nome] like '%' + @nome + '%'");

            string queryTotalCount = Helper.TratarQueryParaSelectCount(query.ToString(), "from usuario");
            var order = $"{param.orderBy} {param.orderDirection}";
            query.AppendLine($"ORDER BY {order}");

            query.AppendLine(" OFFSET @skip ROWS");
            query.AppendLine(" FETCH NEXT @top ROWS ONLY");

            var sql = queryTotalCount.ToString() + ";" + query.ToString();

            using (var multi = await conn.QueryMultipleAsync(sql, (object)param))
            {
                result.totalRecords = multi.Read<int>().Single();
                result.data = multi.Read<UsuarioQuery>().ToList();

                return result;
            }
        }

       
    }
}
