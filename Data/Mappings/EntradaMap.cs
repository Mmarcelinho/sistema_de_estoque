namespace ApiEstoque.Mappings;

    public class EntradaMap : IEntityTypeConfiguration<Entrada>
{
    public void Configure(EntityTypeBuilder<Entrada> builder)
    {
        builder.ToTable("Entrada");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.DataPedido)
        .HasColumnType("datetime")
        .IsRequired();

        builder.Property(x => x.DataEntrada)
        .HasColumnType("datetime")
        .IsRequired();

         builder.Property(p => p.Total)
        .HasColumnType("numeric(38,2)")
        .IsRequired();

        builder.Property(p => p.Frete)
        .HasColumnType("numeric(38,2)")
        .IsRequired();

         builder.Property(p => p.NumeroNotaFiscal)
        .HasColumnType("int")
        .IsRequired();

        builder.Property(p => p.Imposto)
        .HasColumnType("numeric(38,2)")
        .IsRequired();

         builder.HasOne(x => x.Transportadora)
         .WithMany(x => x.Entrada)
            .HasForeignKey(x => x.TransportadoraId)
            .OnDelete(DeleteBehavior.NoAction);

        
    }

}
