namespace ApiEstoque.Models;

public class Entrada
{
    public Entrada(int id, DateTime dataPedido, DateTime dataEntrada, double total, double frete, int numeroNotaFiscal, double imposto, int transportadoraId)
    {
        Id = id;
        DataPedido = dataPedido;
        DataEntrada = dataEntrada;
        Total = total;
        Frete = frete;
        NumeroNotaFiscal = numeroNotaFiscal;
        Imposto = imposto;
        TransportadoraId = transportadoraId;
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

    public ICollection<ItemEntrada> ItemEntradas { get; private set; } = null!;

}