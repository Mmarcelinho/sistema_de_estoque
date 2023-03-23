 namespace ApiEstoque.Models;

public class Transportadora
{
    public Transportadora(int id, string nome, string endereco, int numero, string bairro, string cep, string cnpj, string inscricao, string contato, string telefone, int cidadeId)
    {
     Id = id;
     Nome = nome;
     Endereco = endereco;
     Numero = numero;
     Bairro = bairro;
     Cep = cep;
     Cnpj = cnpj;
     Inscricao = inscricao;
     Contato = contato;
     Telefone = telefone;
     CidadeId = cidadeId;
    }

    public int Id { get; private set; }

    public string Nome { get; private set; }

    public string Endereco { get; private set; }

    public int Numero { get; private set; }

    public string Bairro { get; private set; }

    public string Cep { get; private set; }

    public string Cnpj { get; private set; }

    public string Inscricao { get; private set; }

    public string Contato { get; private set; }

    public string Telefone { get; private set; }

    public int CidadeId { get; private set; }

    public Cidade Cidade { get; private set; } = null!;

    public ICollection<Entrada> Entrada { get; private set; } = null!;

    public ICollection<Saida> Saida { get; private set; } = null!;
}