using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Data.Map
{
    public class ProdutoMap : IEntityTypeConfiguration<ProdutoModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Modelo).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Quantidade).IsRequired().HasMaxLength(5);
            builder.Property(x => x.PessoaId);
            builder.HasOne(x => x.Pessoa)
           .WithMany() 
           .HasForeignKey(x => x.PessoaId)
           .OnDelete(DeleteBehavior.SetNull); 
        }
    }
    }
