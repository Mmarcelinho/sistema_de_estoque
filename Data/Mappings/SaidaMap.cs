namespace ApiEstoque.Data.Mappings;

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
       .WithMany(x => x.Saida)
       .HasForeignKey(x => x.LojaId)
       .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Transportadora)
        .WithMany(x => x.Saida)
       .HasForeignKey(x => x.TransportadoraId)
       .OnDelete(DeleteBehavior.NoAction);

    }

}
