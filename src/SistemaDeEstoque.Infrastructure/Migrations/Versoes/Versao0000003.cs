namespace SistemaDeEstoque.Infrastructure.Migrations.Versoes;

[Migration((long)NumeroVersoes.AdicionarIdentificadorUsuario, "Adiciona coluna IdentificadorUsuario à tabela Admins")]
public class Versao0000003 : Migration
{
    public override void Down()
    {
        Delete.Column("IdentificadorUsuario").FromTable("Admins");
    }

    public override void Up()
    {
        Alter.Table("Admins")
            .AddColumn("IdentificadorUsuario").AsGuid().NotNullable();
    }
}
