using Estoque.Domain.Entities.Shared;

namespace Estoque.Domain.Entities;

public class Fornecedor : Entity
{
    public Fornecedor(){

    }
    public Fornecedor(int id, string nome, string endereco, int numero, string bairro, string cep, string contato, string cnpj, string inscricao, int idCidade)
    {
     Id = id;
     Nome = nome;
     Endereco = endereco;
     Numero = numero;
     Bairro = bairro;
     Cep = cep;
     Contato = contato;
     Cnpj = cnpj;
     Inscricao = inscricao;
     IdCidade = idCidade;
    }

    public string Nome { get; private set; }

    public string Endereco { get; private set; }

    public int Numero { get; private set; }

    public string Bairro { get; private set; }

    public string Cep { get; private set; }

    public string Contato { get; private set; }

    public string Cnpj { get; private set; }

    public string Inscricao { get; private set; }

    public int IdCidade { get; private set; }

    public Cidade Cidade { get; private set; } = null!;

    public ICollection<Entrada> Entradas { get; private set; } = null!;

    public ICollection<Produto> Produtos { get; private set; } = null!;

}