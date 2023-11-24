using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estoque.Data.Migrations
{
    /// <inheritdoc />
    public partial class Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Uf = table.Column<string>(type: "char(14)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(50)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(50)", nullable: false),
                    Cep = table.Column<string>(type: "char(9)", nullable: false),
                    Contato = table.Column<string>(type: "varchar(50)", nullable: false),
                    Cnpj = table.Column<string>(type: "char(18)", nullable: false),
                    Inscricao = table.Column<string>(type: "varchar(50)", nullable: false),
                    IdCidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fornecedor_Cidade_IdCidade",
                        column: x => x.IdCidade,
                        principalTable: "Cidade",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(50)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(50)", nullable: false),
                    Telefone = table.Column<string>(type: "char(14)", nullable: false),
                    Inscricao = table.Column<string>(type: "varchar(50)", nullable: false),
                    Cnpj = table.Column<string>(type: "varchar(18)", nullable: false),
                    IdCidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loja_Cidade_IdCidade",
                        column: x => x.IdCidade,
                        principalTable: "Cidade",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transportadora",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(50)", nullable: false),
                    Cep = table.Column<string>(type: "char(14)", nullable: false),
                    Cnpj = table.Column<string>(type: "varchar(18)", nullable: false),
                    Inscricao = table.Column<string>(type: "varchar(50)", nullable: false),
                    Contato = table.Column<string>(type: "varchar(50)", nullable: false),
                    Telefone = table.Column<string>(type: "char(14)", nullable: false),
                    IdCidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportadora", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transportadora_Cidade_IdCidade",
                        column: x => x.IdCidade,
                        principalTable: "Cidade",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: false),
                    Peso = table.Column<decimal>(type: "numeric(38,2)", nullable: false),
                    Controlado = table.Column<bool>(type: "bit", nullable: false),
                    QuantMinima = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: true),
                    FornecedorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Produto_Fornecedor_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Entrada",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPedido = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "datetime", nullable: false),
                    Total = table.Column<decimal>(type: "numeric(38,2)", nullable: false),
                    Frete = table.Column<decimal>(type: "numeric(38,2)", nullable: false),
                    NumeroNotaFiscal = table.Column<int>(type: "int", nullable: false),
                    Imposto = table.Column<decimal>(type: "numeric(38,2)", nullable: false),
                    IdTransportadora = table.Column<int>(type: "int", nullable: false),
                    FornecedorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entrada_Fornecedor_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Entrada_Transportadora_IdTransportadora",
                        column: x => x.IdTransportadora,
                        principalTable: "Transportadora",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Saida",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total = table.Column<decimal>(type: "numeric(38,2)", nullable: false),
                    Frete = table.Column<decimal>(type: "numeric(38,2)", nullable: false),
                    Imposto = table.Column<decimal>(type: "numeric(38,2)", nullable: false),
                    IdLoja = table.Column<int>(type: "int", nullable: false),
                    IdTransportadora = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saida", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Saida_Loja_IdLoja",
                        column: x => x.IdLoja,
                        principalTable: "Loja",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Saida_Transportadora_IdTransportadora",
                        column: x => x.IdTransportadora,
                        principalTable: "Transportadora",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItemEntrada",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lote = table.Column<string>(type: "varchar(50)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric(38,2)", nullable: false),
                    IdEntrada = table.Column<int>(type: "int", nullable: false),
                    IdProduto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemEntrada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemEntrada_Entrada_IdEntrada",
                        column: x => x.IdEntrada,
                        principalTable: "Entrada",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItemEntrada_Produto_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Produto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItemSaida",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lote = table.Column<string>(type: "varchar(50)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric(38,2)", nullable: false),
                    IdSaida = table.Column<int>(type: "int", nullable: false),
                    IdProduto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSaida", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemSaida_Produto_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Produto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItemSaida_Saida_IdSaida",
                        column: x => x.IdSaida,
                        principalTable: "Saida",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_FornecedorId",
                table: "Entrada",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_IdTransportadora",
                table: "Entrada",
                column: "IdTransportadora");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedor_IdCidade",
                table: "Fornecedor",
                column: "IdCidade");

            migrationBuilder.CreateIndex(
                name: "IX_ItemEntrada_IdEntrada",
                table: "ItemEntrada",
                column: "IdEntrada");

            migrationBuilder.CreateIndex(
                name: "IX_ItemEntrada_IdProduto",
                table: "ItemEntrada",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSaida_IdProduto",
                table: "ItemSaida",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSaida_IdSaida",
                table: "ItemSaida",
                column: "IdSaida");

            migrationBuilder.CreateIndex(
                name: "IX_Loja_IdCidade",
                table: "Loja",
                column: "IdCidade");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_CategoriaId",
                table: "Produto",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_FornecedorId",
                table: "Produto",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Saida_IdLoja",
                table: "Saida",
                column: "IdLoja");

            migrationBuilder.CreateIndex(
                name: "IX_Saida_IdTransportadora",
                table: "Saida",
                column: "IdTransportadora");

            migrationBuilder.CreateIndex(
                name: "IX_Transportadora_IdCidade",
                table: "Transportadora",
                column: "IdCidade");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemEntrada");

            migrationBuilder.DropTable(
                name: "ItemSaida");

            migrationBuilder.DropTable(
                name: "Entrada");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Saida");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Fornecedor");

            migrationBuilder.DropTable(
                name: "Loja");

            migrationBuilder.DropTable(
                name: "Transportadora");

            migrationBuilder.DropTable(
                name: "Cidade");
        }
    }
}
