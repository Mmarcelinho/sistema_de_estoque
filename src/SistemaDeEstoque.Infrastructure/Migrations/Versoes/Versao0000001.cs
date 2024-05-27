namespace SistemaDeEstoque.Infrastructure.Migrations.Versoes;

[Migration((long)NumeroVersoes.CriarTabelaAdmin, "Cria tabela admin")]
public class Versao0000001 : Migration
{
    public override void Down() { }

    public override void Up()
    {
        var tabela = VersaoBase.InserirColunasPadrao(Create.Table("Admins"));

        tabela
            .WithColumn("Nome").AsString(100).NotNullable()
            .WithColumn("Email").AsString().NotNullable()
            .WithColumn("Senha").AsString(2000).NotNullable()
            .WithColumn("Telefone").AsString(14).NotNullable()
            .WithColumn("Administrador").AsBoolean().WithDefaultValue(true).NotNullable();
    }
}
