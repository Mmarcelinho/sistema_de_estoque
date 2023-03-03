namespace ApiEstoque.Models;

public class Categoria
{

    public Categoria(string titulo)
    {
        this.Titulo = titulo;
    }
    public Categoria(int id, string titulo)
    {
        this.Id = id;
        this.Titulo = titulo;

    }
    public int Id { get; private set; }

    public string Titulo { get; private set; }

    public ICollection<Produto> Produto { get; private set; } = null!;

}