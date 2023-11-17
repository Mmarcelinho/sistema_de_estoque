namespace ApiEstoque.Data.Mappings;

    public class ItemEntradaMap : IEntityTypeConfiguration<ItemEntrada>
    {
        public void Configure(EntityTypeBuilder<ItemEntrada> builder)
        {
            builder.ToTable("ItemEntrada");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Lote)
            .HasColumnType("varchar(50)")
            .IsRequired();

            builder.Property(x => x.Quantidade)
            .HasColumnType("int")
            .IsRequired();

            builder.Property(x => x.Valor)
            .HasColumnType("numeric(38,2)")
            .IsRequired();


            builder.HasOne(x => x.Entrada)
            .WithMany(x => x.ItemEntradas)
               .HasForeignKey(x => x.EntradaId)
               .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(x => x.Produto)
            .WithMany(x => x.ItemEntradas)
               .HasForeignKey(x => x.ProdutoId)
               .OnDelete(DeleteBehavior.Cascade);

        }
    }
