namespace Estoque.Domain.Entities;

public class Cidade : Entity
{
    public Cidade(int id, string nome, string uf)
    {
        Id = id;
        Nome = nome;
        Uf = uf;
    }

    public string Nome { get; private set; }

    public string Uf { get; private set; }

    public ICollection<Fornecedor> Fornecedores { get; private set; } = null!;

    public ICollection<Loja> Lojas { get; private set; } = null!;

    public ICollection<Transportadora> Transportadoras { get; private set; } = null!;

}
