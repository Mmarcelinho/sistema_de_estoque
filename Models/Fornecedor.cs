namespace ApiEstoque.Models;

public class Fornecedor
{
    public Fornecedor(int id, string nome, string endereco, int numero, string bairro, string cep, string contato, string cnpj, string inscricao, int cidadeId)
    {
        this.Id = id;
        this.Nome = nome;
        this.Endereco = endereco;
        this.Numero = numero;
        this.Bairro = bairro;
        this.Cep = cep;
        this.Contato = contato;
        this.Cnpj = cnpj;
        this.Inscricao = inscricao;
        this.CidadeId = cidadeId;

    }
    public int Id { get; set; }

    public string Nome { get; set; }

    public string Endereco { get; set; }

    public int Numero { get; set; }

    public string Bairro { get; set; }

    public string Cep { get; set; }

    public string Contato { get; set; }

    public string Cnpj { get; set; }

    public string Inscricao { get; set; }

    public int CidadeId { get; set; }

    public Cidade Cidade { get; set; } = null!;

    public ICollection<Entrada> Entrada { get; set; } = null!;

    public ICollection<Produto> Produto { get; set; } = null!;
}