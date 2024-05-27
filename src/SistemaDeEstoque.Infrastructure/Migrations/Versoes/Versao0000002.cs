namespace SistemaDeEstoque.Infrastructure.Migrations.Versoes;

[Migration((long)NumeroVersoes.AtualizarTabelaAdmin, "Atualiza tabela admin, removendo coluna Administrador e adicionando coluna Role")]
public class Versao0000002 : Migration
{
    public override void Down()
    {
        Delete.Column("Role").FromTable("Admins");
        Alter.Table("Admins")
            .AddColumn("Administrador").AsBoolean().WithDefaultValue(true).NotNullable();
    }

    public override void Up()
    {
        Delete.Column("Administrador").FromTable("Admins");
        Alter.Table("Admins")
            .AddColumn("Role").AsString().NotNullable().WithDefaultValue(Roles.ADMIN);
    }
}
