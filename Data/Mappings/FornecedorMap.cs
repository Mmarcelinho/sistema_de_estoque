using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEstoque.Data.Mappings
{
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
            .WithMany(x => x.Fornecedor)
               .HasForeignKey(x => x.CidadeId)
               .OnDelete(DeleteBehavior.NoAction);


        }

    }
}