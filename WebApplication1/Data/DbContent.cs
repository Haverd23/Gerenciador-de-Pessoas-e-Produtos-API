using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Map;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class DbContent : DbContext
    {
        public DbContent(DbContextOptions<DbContent> options) : base(options)
        {
        }
        public DbSet<PessoaModel> Pessoas { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}