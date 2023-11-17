namespace Estoque.Domain.Entities;

public class ItemSaida : Entity
{
    public ItemSaida(int id, string lote, int quantidade, double valor, int saidaId, int idProduto)
    {
      Id = id;
      Lote = lote;
      Quantidade = quantidade;
      Valor = valor;
      IdSaida =  IdSaida;
      IdProduto = idProduto; 
    }

    public string Lote { get; private set; }

    public int Quantidade { get; private set; }

    public decimal Valor { get; private set; }

    public int IdSaida { get; private set; }

    public int IdProduto { get; private set; }

    public Saida Saida { get; private set; } = null!;

    public Produto Produto { get; private set; } = null!;
}