 namespace ApiEstoque.Models;

public class Saida
{
    public Saida(int id, double total, double frete, double imposto, int lojaId, int transportadoraId)
    {
     Id = id;
     Total = total;
     Frete = frete;
     Imposto = imposto;
     LojaId = lojaId;
     TransportadoraId = transportadoraId;
    }
    
    public int Id { get; private set; }

    public double Total { get; private set; }

    public double Frete { get; private set; }

    public double Imposto { get; private set; }

    public int LojaId { get; private set; }

    public int TransportadoraId { get; private set; }

    public Loja Loja { get; private set; } = null!;

    public Transportadora Transportadora { get; private set; } = null!;

    public ICollection<ItemSaida> ItemSaida { get; private set; } = null!;
}