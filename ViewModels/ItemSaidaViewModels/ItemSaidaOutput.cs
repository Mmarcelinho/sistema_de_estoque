namespace ApiEstoque.ViewModels.ItemSaidaViewModels;

public class ItemSaidaOutput
{
    public ItemSaidaOutput(int id, string lote, int quantidade, double valor, int saidaId, int produtoId)
    {
        this.Id = id;
        this.Lote = lote;
        this.Quantidade = quantidade;
        this.Valor = valor;
        this.SaidaId = saidaId;
        this.ProdutoId = produtoId;

    }
    public int Id { get; private set; }

    public string Lote { get; private set; }

    public int Quantidade { get; private set; }

    public double Valor { get; private set; }

    public int SaidaId { get; private set; }

    public int ProdutoId { get; private set; }
}
