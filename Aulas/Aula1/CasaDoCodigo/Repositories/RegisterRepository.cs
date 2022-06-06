using CasaDoCodigo.Models;

namespace CasaDoCodigo.Repositories
{
    public interface IRegisterRepository
    {

    }

    public class RegisterRepository : BaseRepository<Register>, IRegisterRepository
    {
        public RegisterRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
