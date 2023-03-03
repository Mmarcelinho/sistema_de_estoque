namespace ApiEstoque.ViewModels.EntradaViewModels;

public class ListEntradaViewModels
{
    public ListEntradaViewModels(int id, DateTime dataPedido, DateTime dataEntrada, double total, double frete, int numeroNotaFiscal, double imposto, int transportadoraId, string transportadora)
    {
        this.Id = id;
        this.DataPedido = dataPedido;
        this.DataEntrada = dataEntrada;
        this.Total = total;
        this.Frete = frete;
        this.NumeroNotaFiscal = numeroNotaFiscal;
        this.Imposto = imposto;
        this.TransportadoraId = transportadoraId;
        this.Transportadora = transportadora;

    }
    public int Id { get; private set; }

    public DateTime DataPedido { get; private set; }

    public DateTime DataEntrada { get; private set; }

    public double Total { get; private set; }

    public double Frete { get; private set; }

    public int NumeroNotaFiscal { get; private set; }

    public double Imposto { get; private set; }

    public int TransportadoraId { get; private set; }

    public string Transportadora { get; private set; }

}
