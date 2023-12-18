using Estoque.Domain.Entities.Shared;

namespace Estoque.Domain.Entities;

public class Entrada : Entity
{
    public Entrada(int id,decimal total, decimal frete, int numeroNotaFiscal, decimal imposto, int idTransportadora)
    {
        Id = id;
        DataPedido = DateTime.Now;
        DataEntrada = DateTime.Now;
        Total = total;
        Frete = frete;
        NumeroNotaFiscal = numeroNotaFiscal;
        Imposto = imposto;
        IdTransportadora = idTransportadora;
    }
    
    public DateTime DataPedido { get; private set; }

    public DateTime DataEntrada { get; private set; }

    public decimal Total { get; private set; }

    public decimal Frete { get; private set; }

    public int NumeroNotaFiscal { get; private set; }

    public decimal Imposto { get; private set; }

    public int IdTransportadora { get; private set; }

    public Transportadora Transportadora { get; private set; } = null!;

    public ICollection<ItemEntrada> ItemEntradas { get; private set; } = null!;

    public void AtualizarEntrada(decimal total, decimal frete, int numeroNotaFiscal, decimal imposto, int idTransportadora)
    {
        DataPedido = DateTime.Now;
        DataEntrada = DateTime.Now;
        Total = total;
        Frete = frete;
        NumeroNotaFiscal = numeroNotaFiscal;
        Imposto = imposto;
        IdTransportadora = idTransportadora;
    }

}