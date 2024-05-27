namespace SistemaDeEstoque.Domain.Entidades;

    public class HistoricoEstoque : EntidadeBase
    {
        public long ProdutoId { get; set; }

        public DateTime DataMovimentacao { get; set; }

        public string TipoMovimentacao { get; set; }

        public int QuantidadeMovimentada { get; set; }

        public int SaldoQuantidade { get; set; }
    }
