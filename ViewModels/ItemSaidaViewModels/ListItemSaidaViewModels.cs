namespace ApiEstoque.ViewModels.ItemSaidaViewModels;

public class ListItemSaidaViewModels
{
    public ListItemSaidaViewModels(int id, string lote, int quantidade, double valor, int saidaId, int produtoId, double saida, string produto)
    {
        this.Id = id;
        this.Lote = lote;
        this.Quantidade = quantidade;
        this.Valor = valor;
        this.SaidaId = saidaId;
        this.ProdutoId = produtoId;
        this.Saida = saida;
        this.Produto = produto;

    }
    public int Id { get; private set; }

    public string Lote { get; private set; }

    public int Quantidade { get; private set; }

    public double Valor { get; private set; }

    public int SaidaId { get; private set; }

    public int ProdutoId { get; private set; }

    public double Saida { get; private set; }

    public string Produto { get; private set; }
}
