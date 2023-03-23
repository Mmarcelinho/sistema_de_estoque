namespace ApiEstoque.Models;

public class Cidade
{

     public Cidade(string nome, string uf)
    {
        Nome = nome;
        Uf = uf;
    }
    public Cidade(int id, string nome, string uf)
    {
        Id = id;
        Nome = nome;
        Uf = uf;

    }
    public int Id { get; private set; }

    public string Nome { get; private set; }

    public string Uf { get; private set; }

    public ICollection<Fornecedor> Fornecedor { get; private set; } = null!;

    public ICollection<Loja> Loja { get; private set; } = null!;

    public ICollection<Transportadora> Transportadora { get; private set; } = null!;

}
