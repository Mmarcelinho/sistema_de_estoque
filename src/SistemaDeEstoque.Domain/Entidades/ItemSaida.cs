namespace SistemaDeEstoque.Domain.Entidades;

    public class ItemSaida : EntidadeBase
    {
        public string Lote { get; set; }

        public double Peso { get; set; }

        public long Quantidade { get; set; }

        public decimal Valor { get; set; }

        public long SaidaId { get; set; }

        public long ProdutoId { get; set; }
    }
