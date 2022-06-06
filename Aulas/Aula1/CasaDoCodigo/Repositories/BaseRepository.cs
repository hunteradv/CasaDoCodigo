using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo.Repositories
{
    public class BaseRepository<T> where T : BaseModel
    {
        protected readonly ApplicationContext context;
        protected readonly DbSet<T> DbSet;

        public BaseRepository(ApplicationContext context)
        {
            this.context = context;
            DbSet = context.Set<T>();
        }
    }
}
