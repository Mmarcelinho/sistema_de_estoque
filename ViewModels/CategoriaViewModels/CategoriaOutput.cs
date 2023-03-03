namespace ApiEstoque.ViewModels.CategoriaViewModels;

public class CategoriaOutput
{

    public CategoriaOutput(int id, string titulo)
    {
        this.Id = id;
        this.Titulo = titulo;

    }
    
    public int Id { get; private set; }

    public string Titulo { get; private set; }

}
