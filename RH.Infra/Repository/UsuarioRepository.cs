using Microsoft.EntityFrameworkCore;
using RH.Domain.Usuario;
using RH.Domain.Usuario.Interfaces;
using RH.Infra.Context;
using System.Linq;

namespace RH.Infra.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(RHContext context)
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

