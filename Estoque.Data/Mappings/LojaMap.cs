using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Estoque.Domain.Entities;

namespace Estoque.Data.Mappings;

    public class LojaMap : IEntityTypeConfiguration<Loja>
    {
        public void Configure(EntityTypeBuilder<Loja> builder)
        {
            builder.ToTable("Loja");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
            .HasColumnType("varchar(50)")
            .IsRequired();

            builder.Property(x => x.Endereco)
            .HasColumnType("varchar(50)")
            .IsRequired();

            builder.Property(x => x.Numero)
            .HasColumnType("int")
            .IsRequired();

            builder.Property(x => x.Bairro)
            .HasColumnType("varchar(50)")
            .IsRequired();

            builder.Property(x => x.Telefone)
            .HasColumnType("char(14)")
            .IsRequired();

            builder.Property(x => x.Inscricao)
            .HasColumnType("varchar(50)")
            .IsRequired();

            builder.Property(x => x.Cnpj)
            .HasColumnType("varchar(18)")
            .IsRequired();

            builder.HasOne(x => x.Cidade)
            .WithMany(x => x.Lojas)
           .HasForeignKey(x => x.IdCidade)
           .OnDelete(DeleteBehavior.Cascade);


        }
    }
