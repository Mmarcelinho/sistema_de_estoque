namespace ApiEstoque.ViewModels.CidadeViewModels;

public class CidadeOutput
{
    public CidadeOutput(int id, string nome, string uf)
    {
        this.Id = id;
        this.Nome = nome;
        this.Uf = uf;

    }
    public int Id { get; private set; }

    public string Nome { get; private set; }

    public string Uf { get; private set; }
}
