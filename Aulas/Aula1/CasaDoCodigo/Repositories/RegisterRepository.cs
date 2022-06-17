using CasaDoCodigo.Models;
using System;
using System.Linq;

namespace CasaDoCodigo.Repositories
{
    public interface IRegisterRepository
    {
        Register Update(int registerId, Register newRegister);
    }

    public class RegisterRepository : BaseRepository<Register>, IRegisterRepository
    {
        public RegisterRepository(ApplicationContext context) : base(context)
        {
        }

        public Register Update(int registerId, Register newRegister)
        {
            var registerDb = DbSet.Where( c => c.Id == registerId )
                .SingleOrDefault();

            if( registerDb is null)
            {
                throw new ArgumentException("cadastro");
            }

            registerDb.Update(newRegister);

            context.SaveChanges();
            return registerDb;
        }
    }
}
