namespace ApiEstoque.ViewModels.CategoriaViewModels;

public class CategoriaOutput
{
    public CategoriaOutput(int id, string titulo)
    {
        Id = id;
        Titulo = titulo;
    }

    public int Id { get; private set; }

    public string Titulo { get; private set; }
}
