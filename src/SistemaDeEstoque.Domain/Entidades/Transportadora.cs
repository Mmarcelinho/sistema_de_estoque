namespace SistemaDeEstoque.Domain.Entidades;

    public class Transportadora : EntidadeBase
    {
      public string Nome { get; set; }

      public Endereco Endereco { get; set; }

      public int Numero { get; set; }

      public string Cnpj { get; set; }

      public string Inscricao { get; set; }

      public string Contato { get; set; }

      public string Telefone { get; set; }

      public ICollection<Entrada> Entradas { get; set; }

      public ICollection<Saida> Saidas { get; set; }
    }
