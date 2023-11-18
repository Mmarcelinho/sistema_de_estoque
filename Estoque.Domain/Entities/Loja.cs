using Estoque.Domain.Entities.Shared;

namespace Estoque.Domain.Entities;

public class Loja : Entity
{
    public Loja(int id, string nome, string endereco, int numero, string bairro, string telefone, string inscricao, string cnpj, int idCidade)
    {
     Id = id;
     Nome = nome;
     Endereco = endereco;
     Numero = numero;
     Bairro = bairro;
     Telefone = telefone;
     Inscricao = inscricao;
     Cnpj = cnpj;
     IdCidade = idCidade;
    }

    public string Nome { get; private set; }

    public string Endereco { get; private set; }

    public int Numero { get; private set; }

    public string Bairro { get; private set; }

    public string Telefone { get; private set; }

    public string Inscricao { get; private set; }

    public string Cnpj { get; private set; }

    public int IdCidade { get; private set; }

    public Cidade Cidade { get; private set; } = null!;

    public ICollection<Saida> Saidas { get; private set; } = null!;
}