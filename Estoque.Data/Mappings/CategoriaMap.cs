using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Estoque.Domain.Entities;

namespace Estoque.Data.Mappings;

    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
         public void Configure(EntityTypeBuilder<Categoria> builder)
         {
            builder.ToTable("Categoria");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Titulo)
            .HasColumnType("varchar(50)")
            .IsRequired();
         }
    }
