using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Data.Map
{
    public class PessoaMap : IEntityTypeConfiguration<PessoaModel>
    {
        public void Configure(EntityTypeBuilder<PessoaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Idade).IsRequired().HasMaxLength(2);
            builder.Property(x => x.Cep).IsRequired().HasMaxLength(255);

        }
    }
}