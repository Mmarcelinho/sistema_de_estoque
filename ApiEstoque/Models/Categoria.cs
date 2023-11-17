namespace ApiEstoque.Models;

public class Categoria
{
    public Categoria(int id, string titulo)
    {
        Id = id;
        Titulo = titulo;
    }
    public int Id { get; private set; }

    public string Titulo { get; private set; }

    public ICollection<Produto> Produtos { get; private set; } = null!;
}