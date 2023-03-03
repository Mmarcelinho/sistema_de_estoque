namespace ApiEstoque.Data.Mappings;

    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
            .HasColumnType("varchar(50)")
            .IsRequired();

            builder.Property(x => x.Peso)
            .HasColumnType("numeric(38,2)")
            .IsRequired();

            builder.Property(p => p.Controlado)
            .HasColumnType("bit");

            builder.Property(x => x.QuantMinima)
            .HasColumnType("int")
            .IsRequired();


        }
    }
