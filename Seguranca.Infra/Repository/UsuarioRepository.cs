using Core.Infra.Interface;
using Microsoft.EntityFrameworkCore;
using Seguranca.Domain.Usuario;
using Seguranca.Domain.Usuario.Interfaces;
using Seguranca.Infra.Context;
using System.Linq;

namespace Seguranca.Infra.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(SegurancaContext context)
            : base(context)
        {

        }

        public Usuario BuscarEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
        }

        public void InserirUsuarioRead(Usuario entity)
        {
            MongoDbContext dbContext = new MongoDbContext();
            dbContext.Usuarios.InsertOne(entity);
        }

    }
}

