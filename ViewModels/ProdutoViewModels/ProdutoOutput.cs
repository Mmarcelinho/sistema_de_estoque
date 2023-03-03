namespace ApiEstoque.ViewModels.ProdutoViewModels;

public class ProdutoOutput
{
    public ProdutoOutput(int id, string descricao, double peso, bool controlado, int quantMinima)
    {
        this.Id = id;
        this.Descricao = descricao;
        this.Peso = peso;
        this.Controlado = controlado;
        this.QuantMinima = quantMinima;

    }
    public int Id { get; private set; }

    public string Descricao { get; private set; }

    public double Peso { get; private set; }

    public bool Controlado { get; private set; }

    public int QuantMinima { get; private set; }

}
