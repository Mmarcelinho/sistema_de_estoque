namespace ApiEstoque.Models;

public class Produto
{
    public Produto(int id, string nome, string descricao, double peso, bool controlado, int quantMinima)
    {
      Id = id;
      Nome = nome;
      Descricao = descricao;
      Peso = peso;
      Controlado = controlado;
      QuantMinima = quantMinima;
    }

    public int Id { get; private set; }

    public string Nome { get; private set; }

    public string Descricao { get; private set; }

    public double Peso { get; private set; }

    public bool Controlado { get; private set; }

    public int QuantMinima { get; private set; }

    public ICollection<ItemEntrada> ItemEntrada { get; private set; } = null!;

    public ICollection<ItemSaida> ItemSaida { get; private set; } = null!;
}