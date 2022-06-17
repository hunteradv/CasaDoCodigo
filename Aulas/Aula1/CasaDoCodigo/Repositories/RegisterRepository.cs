using CasaDoCodigo.Models;

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
            throw new System.NotImplementedException();
        }
    }
}
