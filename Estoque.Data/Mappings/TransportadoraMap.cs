using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Estoque.Domain.Entities;

namespace Estoque.Data.Mappings;

public class TransportadoraMap : IEntityTypeConfiguration<Transportadora>
{
    public void Configure(EntityTypeBuilder<Transportadora> builder)
    {
        builder.ToTable("Transportadora");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Bairro)
       .HasColumnType("varchar(50)")
       .IsRequired();

        builder.Property(x => x.Cep)
        .HasColumnType("char(14)")
        .IsRequired();

        builder.Property(x => x.Cnpj)
        .HasColumnType("varchar(18)")
        .IsRequired();

        builder.Property(x => x.Inscricao)
        .HasColumnType("varchar(50)")
        .IsRequired();

        builder.Property(x => x.Contato)
        .HasColumnType("varchar(50)")
        .IsRequired();

        builder.Property(x => x.Telefone)
        .HasColumnType("char(14)")
        .IsRequired();

        builder.HasOne(x => x.Cidade)
       .WithMany(x => x.Transportadoras)
       .HasForeignKey(x => x.IdCidade)
       .OnDelete(DeleteBehavior.Cascade);
    }

}
