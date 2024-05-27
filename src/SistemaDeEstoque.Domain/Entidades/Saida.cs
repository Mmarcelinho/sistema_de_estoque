namespace SistemaDeEstoque.Domain.Entidades;

    public class Saida : EntidadeBase
    {
        public double Total { get; set; }

        public double Frete { get; set; }

        public double Imposto { get; set; }

        public int LojaId { get; set; }

        public long TransportadoraId { get; set; }
    }
