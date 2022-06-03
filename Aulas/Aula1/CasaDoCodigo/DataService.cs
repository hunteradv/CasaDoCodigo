using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CasaDoCodigo
{
    public class DataService : IDataService
    {
        private readonly ApplicationContext context;
        public DataService(ApplicationContext context)
        {
            this.context = context;
        }

        public void InitializeDB()
        {
            context.Database.Migrate();

            var json = File.ReadAllText("books.json");
            var books = JsonConvert.DeserializeObject<List<Book>>(json);
        }
    }

    public class Book
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
