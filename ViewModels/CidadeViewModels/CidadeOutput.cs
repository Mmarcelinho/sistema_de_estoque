namespace ApiEstoque.ViewModels.CidadeViewModels;

public class CidadeOutput
{
    public CidadeOutput(int id, string nome, string uf)
    {
        Id = id;
        Nome = nome;
        Uf = uf;
    }

    public int Id { get; private set; }

    public string Nome { get; private set; }

    public string Uf { get; private set; }
}
