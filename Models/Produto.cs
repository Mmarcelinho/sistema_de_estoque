namespace ApiEstoque.Models;

public class Produto
{
    public Produto(int id, string descricao, double peso, bool controlado, int quantMinima)
    {
        this.Id = id;
        this.Descricao = descricao;
        this.Peso = peso;
        this.Controlado = controlado;
        this.QuantMinima = quantMinima;

    }
    public int Id { get; set; }

    public string Descricao { get; set; }

    public double Peso { get; set; }

    public bool Controlado { get; set; }

    public int QuantMinima { get; set; }

    public ICollection<ItemEntrada> ItemEntrada { get; set; } = null!;

    public ICollection<ItemSaida> ItemSaida { get; set; } = null!;

}