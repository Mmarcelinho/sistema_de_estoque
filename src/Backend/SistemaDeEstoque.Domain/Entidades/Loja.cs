namespace SistemaDeEstoque.Domain.Entidades;

public class Loja
{
    public string Nome { get; set; }

    public string Endereco { get; set; }

    public int Numero { get; set; }

    public string Bairro { get; set; }

    public string Telefone { get; set; }

    public string Inscricao { get; set; }

    public string Cnpj { get; set; }

    public ICollection<Saida> Saidas { get; set; }
}
