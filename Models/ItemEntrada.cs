namespace ApiEstoque.Models;

public class ItemEntrada
{
    public ItemEntrada(int id, string lote, int quantidade, double valor, int entradaId, int produtoId)
    {
        this.Id = id;
        this.Lote = lote;
        this.Quantidade = quantidade;
        this.Valor = valor;
        this.EntradaId = entradaId;
        this.ProdutoId = produtoId;

    }
    public int Id { get; set; }

    public string Lote { get; set; }

    public int Quantidade { get; set; }

    public double Valor { get; set; }

    public int EntradaId { get; set; }

    public int ProdutoId { get; set; }

    public Entrada Entrada { get; set; } = null!;

    public Produto Produto { get; set; } = null!;
}