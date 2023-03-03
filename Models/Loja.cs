namespace ApiEstoque.Models;

public class Loja
{
    public Loja(int id, string nome, string endereco, int numero, string bairro, string telefone, string inscricao, string cnpj, int cidadeId)
    {
        this.Id = id;
        this.Nome = nome;
        this.Endereco = endereco;
        this.Numero = numero;
        this.Bairro = bairro;
        this.Telefone = telefone;
        this.Inscricao = inscricao;
        this.Cnpj = cnpj;
        this.CidadeId = cidadeId;

    }
    public int Id { get; private set; }

    public string Nome { get; private set; }

    public string Endereco { get; private set; }

    public int Numero { get; private set; }

    public string Bairro { get; private set; }

    public string Telefone { get; private set; }

    public string Inscricao { get; private set; }

    public string Cnpj { get; private set; }

    public int CidadeId { get; private set; }

    public Cidade Cidade { get; private set; } = null!;

    public ICollection<Saida> Saida { get; private set; } = null!;


}