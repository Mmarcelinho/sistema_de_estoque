namespace ApiEstoque.Models;

public class Entrada
{
    public Entrada(int id, DateTime dataPedido, DateTime dataEntrada, double total, double frete, int numeroNotaFiscal, double imposto, int transportadoraId)
    {
        this.Id = id;
        this.DataPedido = dataPedido;
        this.DataEntrada = dataEntrada;
        this.Total = total;
        this.Frete = frete;
        this.NumeroNotaFiscal = numeroNotaFiscal;
        this.Imposto = imposto;
        this.TransportadoraId = transportadoraId;
   

    }
    public int Id { get; private set; }

    public DateTime DataPedido { get; private set; }

    public DateTime DataEntrada { get; private set; }

    public double Total { get; private set; }

    public double Frete { get; private set; }

    public int NumeroNotaFiscal { get; private set; }

    public double Imposto { get; private set; }

    public int TransportadoraId { get; private set; }

    public Transportadora Transportadora { get; private set; }

    public ICollection<ItemEntrada> ItemEntrada { get; private set; } = null!;

}