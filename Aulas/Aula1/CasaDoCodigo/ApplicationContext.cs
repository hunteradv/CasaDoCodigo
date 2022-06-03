using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasKey(p => p.Id);

            
            modelBuilder.Entity<Request>().HasKey(p => p.Id);
            //tabela 1 - n (cada pedido tem muitos itens de pedido)
            modelBuilder.Entity<Request>().HasMany(p => p.Items).WithOne(p => p.Request);
            //tabela 1 - 1 (cada pedido tem um cadastro)
            modelBuilder.Entity<Request>().HasOne(p => p.Register).WithOne(p => p.Request).IsRequired();

            //tabela 1 - 1
            modelBuilder.Entity<ItemRequest>().HasKey(p => p.Id);
            modelBuilder.Entity<ItemRequest>().HasOne(p => p.Request);
            modelBuilder.Entity<ItemRequest>().HasOne(p => p.Product);

            modelBuilder.Entity<Register>().HasKey(p => p.Id);
            modelBuilder.Entity<Register>().HasOne(p => p.Request);
        }
    }
}
