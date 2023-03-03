namespace ApiEstoque.Data.Mappings;

public class ItemSaidaMap : IEntityTypeConfiguration<ItemSaida>
{
    public void Configure(EntityTypeBuilder<ItemSaida> builder)
    {
        builder.ToTable("ItemSaida");

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


        builder.HasOne(x => x.Saida)
        .WithMany(x => x.ItemSaida)
           .HasForeignKey(x => x.SaidaId)
           .OnDelete(DeleteBehavior.Cascade);


        builder.HasOne(x => x.Produto)
        .WithMany(x => x.ItemSaida)
           .HasForeignKey(x => x.ProdutoId)
           .OnDelete(DeleteBehavior.Cascade);


    }

}
