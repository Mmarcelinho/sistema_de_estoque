namespace ApiEstoque.ViewModels.ItemEntradaViewModels;

public class ListItemEntradaViewModels
{
    public ListItemEntradaViewModels(int id, string lote, int quantidade, double valor, int entradaId, int produtoId, int entrada, string produto)
    {
     Id = id;
     Lote = lote;
     Quantidade = quantidade;
     Valor = valor;
     EntradaId = entradaId;
     ProdutoId = produtoId;
     Entrada = entrada;
     Produto = produto;
    }
    
    public int Id { get; private set; }

    public string Lote { get; private set; }

    public int Quantidade { get; private set; }

    public double Valor { get; private set; }

    public int EntradaId { get; private set; }

    public int ProdutoId { get; private set; }

    public int Entrada { get; private set; }

    public string Produto { get; private set; }
}
