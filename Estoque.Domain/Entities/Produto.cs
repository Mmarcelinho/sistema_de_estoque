using Estoque.Domain.Entities.Shared;

namespace Estoque.Domain.Entities;

public class Produto : Entity
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

    public string Nome { get; private set; }

    public string Descricao { get; private set; }

    public double Peso { get; private set; }

    public bool Controlado { get; private set; }

    public int QuantMinima { get; private set; }

    public ICollection<ItemEntrada> ItemEntradas { get; private set; } = null!;

    public ICollection<ItemSaida> ItemSaidas { get; private set; } = null!;

    public void AtualizarProduto(string nome, string descricao, double peso, bool controlado, int quantMinima)
    {
      Nome = nome;
      Descricao = descricao;
      Peso = peso;
      Controlado = controlado;
      QuantMinima = quantMinima;
    }


}