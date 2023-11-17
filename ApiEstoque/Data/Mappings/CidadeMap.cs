namespace ApiEstoque.Mappings;


public class CidadeMap : IEntityTypeConfiguration<Cidade>
{
    public void Configure(EntityTypeBuilder<Cidade> builder)
    {
        builder.ToTable("Cidade");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
        .HasColumnType("varchar(50)")
        .IsRequired();

         builder.Property(x => x.Uf)
        .HasColumnType("char(14)")
        .IsRequired();

       
    }

}