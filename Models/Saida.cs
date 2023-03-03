namespace ApiEstoque.Models;

public class Saida
{
    public Saida(int id, double total, double frete, double imposto, int lojaId, int transportadoraId)
    {
        this.Id = id;
        this.Total = total;
        this.Frete = frete;
        this.Imposto = imposto;
        this.LojaId = lojaId;
        this.TransportadoraId = transportadoraId;

    }
    
    public int Id { get; set; }

    public double Total { get; set; }

    public double Frete { get; set; }

    public double Imposto { get; set; }

    public int LojaId { get; set; }

    public int TransportadoraId { get; set; }

    public Loja Loja { get; set; } = null!;

    public Transportadora Transportadora { get; set; } = null!;

    public ICollection<ItemSaida> ItemSaida { get; set; } = null!;

}