using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CasaDoCodigo
{
    public class DataService : IDataService
    {
        private readonly ApplicationContext context;
        private readonly IProductRepository productRepository;
        public DataService(ApplicationContext context, IProductRepository productRepository)
        {
            this.context = context;
            this.productRepository = productRepository;
        }

        public void InitializeDB()
        {
            context.Database.Migrate();
            List<Book> books = GetBooks();
            productRepository.SaveProducts(books);
        }

        private static List<Book> GetBooks()
        {
            var json = File.ReadAllText("books.json");
            var books = JsonConvert.DeserializeObject<List<Book>>(json);
            return books;
        }
    }
}
