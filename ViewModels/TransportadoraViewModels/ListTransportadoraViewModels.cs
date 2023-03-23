namespace ApiEstoque.ViewModels.TransportadoraViewModels;

public class ListTransportadoraViewModels
{
    public ListTransportadoraViewModels(int id, string nome, string endereco, int numero, string bairro, string cep, string cnpj, string inscricao, string contato, string telefone, int cidadeId, string cidade)
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
        Cidade = cidade;
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
