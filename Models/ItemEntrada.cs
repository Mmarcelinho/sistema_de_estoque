 namespace ApiEstoque.Models;

public class ItemEntrada
{
    public ItemEntrada(int id, string lote, int quantidade, double valor, int entradaId, int produtoId)
    {
     Id = id;
     Lote = lote;
     Quantidade = quantidade;
     Valor = valor;
     EntradaId = entradaId;
     ProdutoId = produtoId;
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