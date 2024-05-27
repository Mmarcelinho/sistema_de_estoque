namespace SistemaDeEstoque.Domain.Entidades;

    public class Fornecedor : EntidadeBase
    {
        public string Nome { get; set; }

        public Endereco Endereco { get; set; }

        public int Numero { get; set; }

        public string Cnpj { get; set; }

        public string Inscricao { get; set; }

        public ICollection<Entrada> Entradas { get; set; }

        public ICollection<Produto> Produtos { get; set; }
    }
