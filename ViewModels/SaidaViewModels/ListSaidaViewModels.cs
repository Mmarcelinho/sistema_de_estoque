namespace ApiEstoque.ViewModels.SaidaViewModels;

public class ListSaidaViewModels
{
    public ListSaidaViewModels(int id, double total, double frete, double imposto, int lojaId, int transportadoraId, string loja, string transportadora)
    {
        this.Id = id;
        this.Total = total;
        this.Frete = frete;
        this.Imposto = imposto;
        this.LojaId = lojaId;
        this.TransportadoraId = transportadoraId;
        this.Loja = loja;
        this.Transportadora = transportadora;

    }
    public int Id { get; private set; }

    public double Total { get; private set; }

    public double Frete { get; private set; }

    public double Imposto { get; private set; }

    public int LojaId { get; private set; }

    public int TransportadoraId { get; private set; }

    public string Loja { get; private set; }

    public string Transportadora { get; private set; }



}
