using Estoque.Domain.Entities.Shared;

namespace Estoque.Domain.Entities;

public class Saida : Entity
{
    public Saida(int id, double total, double frete, double imposto, int idLoja, int idTransportadora)
    {
     Id = id;
     Total = total;
     Frete = frete;
     Imposto = imposto;
     IdLoja = idLoja;
     IdTransportadora = idTransportadora;
    }

    public double Total { get; private set; }

    public double Frete { get; private set; }

    public double Imposto { get; private set; }

    public int IdLoja { get; private set; }

    public int IdTransportadora { get; private set; }

    public Loja Loja { get; private set; } = null!;

    public Transportadora Transportadora { get; private set; } = null!;

    public ICollection<ItemSaida> ItemSaidas { get; private set; } = null!;

    public void AtualizarSaida(double total, double frete, double imposto, int idLoja, int idTransportadora)
    {
     Total = total;
     Frete = frete;
     Imposto = imposto;
     IdLoja = idLoja;
     IdTransportadora = idTransportadora;
    }
}