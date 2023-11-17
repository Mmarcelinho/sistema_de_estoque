namespace Estoque.Domain.Entities;

public class ItemEntrada : Entity
{
    public ItemEntrada(int id, string lote, int quantidade, double valor, int idEntrada, int idProduto)
    {
     Id = id;
     Lote = lote;
     Quantidade = quantidade;
     Valor = valor;
     IdEntrada = idEntrada;
     IdProduto = idProduto;
    }

    public string Lote { get; private set; }

    public int Quantidade { get; private set; }

    public decimal Valor { get; private set; }

    public int IdEntrada { get; private set; }

    public int IdProduto { get; private set; }

    public Entrada Entrada { get; private set; } = null!;

    public Produto Produto { get; private set; } = null!;
}