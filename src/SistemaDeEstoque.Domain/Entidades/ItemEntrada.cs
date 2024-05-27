namespace SistemaDeEstoque.Domain.Entidades;

    public class ItemEntrada : EntidadeBase
    {
        public string Lote { get; set; }

        public double Peso { get; set; }

        public long Quantidade { get; set; }

        public decimal Valor { get; set; }

        public long EntradaId { get; set; }
    }
