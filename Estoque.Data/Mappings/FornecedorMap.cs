using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Estoque.Domain.Entities;

namespace Estoque.Data.Mappings;

    public class FornecedorMap : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("Fornecedor");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
            .HasColumnType("varchar(50)")
            .IsRequired();

            builder.Property(x => x.Endereco)
            .HasColumnType("varchar(50)")
            .IsRequired();

            builder.Property(p => p.Numero)
            .HasColumnType("int")
            .IsRequired();

            builder.Property(x => x.Bairro)
            .HasColumnType("varchar(50)")
            .IsRequired();

            builder.Property(x => x.Cep)
            .HasColumnType("char(9)")
            .IsRequired();

            builder.Property(x => x.Contato)
            .HasColumnType("varchar(50)")
            .IsRequired();

            builder.Property(x => x.Cnpj)
            .HasColumnType("char(18)")
            .IsRequired();

            builder.Property(x => x.Inscricao)
            .HasColumnType("varchar(50)")
            .IsRequired();

            builder.HasOne(x => x.Cidade)
            .WithMany(x => x.Fornecedores)
               .HasForeignKey(x => x.IdCidade)
               .OnDelete(DeleteBehavior.Cascade);


        }

    }
