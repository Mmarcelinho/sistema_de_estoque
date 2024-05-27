namespace SistemaDeEstoque.Domain.Entidades;

    public class Entrada : EntidadeBase
    {
        public DateTime DataPedido { get; set; }

        public DateTime DataEntrega { get; set; }

        public decimal Total { get; set; }

        public decimal Frete { get; set; }

        public string NotaFiscal { get; set; }

        public decimal Imposto { get; set; }

        public long TransportadoraId { get; set; }

        public Transportadora Transportadora { get; set; }

        public ICollection<ItemEntrada> ItemEntradas { get; set; }
    }
