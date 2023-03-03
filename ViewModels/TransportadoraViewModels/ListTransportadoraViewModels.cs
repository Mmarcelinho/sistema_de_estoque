namespace ApiEstoque.ViewModels.TransportadoraViewModels;

public class ListTransportadoraViewModels
{
    public ListTransportadoraViewModels(int id, string nome, string endereco, int numero, string bairro, string cep, string cnpj, string inscricao, string contato, string telefone, int cidadeId, string cidade)
    {
        this.Id = id;
        this.Nome = nome;
        this.Endereco = endereco;
        this.Numero = numero;
        this.Bairro = bairro;
        this.Cep = cep;
        this.Cnpj = cnpj;
        this.Inscricao = inscricao;
        this.Contato = contato;
        this.Telefone = telefone;
        this.CidadeId = cidadeId;
        this.Cidade = cidade;

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

    public string Cidade { get; private set; }
}
