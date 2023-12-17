using Estoque.Domain.Entities.Shared;

namespace Estoque.Domain.Entities;

public class Categoria : Entity
{
    public Categoria(int id, string titulo)
    {
        Id = id;
        Titulo = titulo;
    }

    public string Titulo { get; private set; }

    public ICollection<Produto> Produtos { get; private set; } = null!;

    public void AtualizarCategoria(string titulo) => Titulo = titulo;
}