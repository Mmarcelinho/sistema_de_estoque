using System;

namespace Estoque.Domain.Entities;

public class Entrada : Entity
{
    public Entrada(int id, DateTime dataPedido, double total, double frete, int numeroNotaFiscal, double imposto, int idTransportadora)
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

    public Transportadora Transportadora { get; private set; }

    public ICollection<ItemEntrada> ItemEntradas { get; private set; } = null!;

}