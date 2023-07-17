using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiEstoque.Migrations
{
    /// <inheritdoc />
    public partial class ApiEstoque : Migration
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
                    CidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fornecedor_Cidade_CidadeId",
                        column: x => x.CidadeId,
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
                    CidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loja_Cidade_CidadeId",
                        column: x => x.CidadeId,
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
                    CidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportadora", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transportadora_Cidade_CidadeId",
                        column: x => x.CidadeId,
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
                    TransportadoraId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_Entrada_Transportadora_TransportadoraId",
                        column: x => x.TransportadoraId,
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
                    LojaId = table.Column<int>(type: "int", nullable: false),
                    TransportadoraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saida", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Saida_Loja_LojaId",
                        column: x => x.LojaId,
                        principalTable: "Loja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Saida_Transportadora_TransportadoraId",
                        column: x => x.TransportadoraId,
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
                    EntradaId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemEntrada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemEntrada_Entrada_EntradaId",
                        column: x => x.EntradaId,
                        principalTable: "Entrada",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemEntrada_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    SaidaId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSaida", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemSaida_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemSaida_Saida_SaidaId",
                        column: x => x.SaidaId,
                        principalTable: "Saida",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_FornecedorId",
                table: "Entrada",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_TransportadoraId",
                table: "Entrada",
                column: "TransportadoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedor_CidadeId",
                table: "Fornecedor",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemEntrada_EntradaId",
                table: "ItemEntrada",
                column: "EntradaId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemEntrada_ProdutoId",
                table: "ItemEntrada",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSaida_ProdutoId",
                table: "ItemSaida",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSaida_SaidaId",
                table: "ItemSaida",
                column: "SaidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Loja_CidadeId",
                table: "Loja",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_CategoriaId",
                table: "Produto",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_FornecedorId",
                table: "Produto",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Saida_LojaId",
                table: "Saida",
                column: "LojaId");

            migrationBuilder.CreateIndex(
                name: "IX_Saida_TransportadoraId",
                table: "Saida",
                column: "TransportadoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Transportadora_CidadeId",
                table: "Transportadora",
                column: "CidadeId");
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
