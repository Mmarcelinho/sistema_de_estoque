using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Estoque.Domain.Entities;

namespace Estoque.Data.Mappings;

public class SaidaMap : IEntityTypeConfiguration<Saida>
{
    public void Configure(EntityTypeBuilder<Saida> builder)
    {
        builder.ToTable("Saida");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Total)
        .HasColumnType("numeric(38,2)")
        .IsRequired();

        builder.Property(x => x.Frete)
       .HasColumnType("numeric(38,2)")
       .IsRequired();

        builder.Property(x => x.Imposto)
        .HasColumnType("numeric(38,2)")
        .IsRequired();

        builder.HasOne(x => x.Loja)
       .WithMany(x => x.Saidas)
       .HasForeignKey(x => x.IdLoja)
       .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Transportadora)
        .WithMany(x => x.Saidas)
       .HasForeignKey(x => x.IdTransportadora)
       .OnDelete(DeleteBehavior.Cascade);

    }

}
