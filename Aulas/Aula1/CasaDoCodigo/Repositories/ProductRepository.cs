using CasaDoCodigo.Models;
using System.Collections.Generic;

namespace CasaDoCodigo.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext context;

        public ProductRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public void SaveProducts(List<Book> books)
        {
            foreach (var book in books)
            {
                context.Set<Product>().Add(new Product(book.Code, book.Name, book.Price));
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
