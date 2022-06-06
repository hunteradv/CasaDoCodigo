using CasaDoCodigo.Models;
using System.Collections.Generic;
using System.Linq;

namespace CasaDoCodigo.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationContext context) : base(context)
        {
        }

        public IList<Product> GetProducts()
        {
            return DbSet.ToList();
        }

        public void SaveProducts(List<Book> books)
        {
            foreach (var book in books)
            {                
                if (!DbSet.Where(p => p.Code == book.Code).Any())
                {
                    DbSet.Add(new Product(book.Code, book.Name, book.Price));
                }
            }

            context.SaveChanges();
        }
    }
    public class Book
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
