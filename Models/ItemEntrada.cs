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
    public int Id { get; private set; }

    public string Lote { get; private set; }

    public int Quantidade { get; private set; }

    public double Valor { get; private set; }

    public int EntradaId { get; private set; }

    public int ProdutoId { get; private set; }

    public Entrada Entrada { get; private set; } = null!;

    public Produto Produto { get; private set; } = null!;
}