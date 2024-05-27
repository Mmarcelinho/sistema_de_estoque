namespace SistemaDeEstoque.Domain.Entidades;

    public class Produto : EntidadeBase
    {
        public Categoria Categoria { get; set; }
        
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public double Peso { get; set; }

        public bool Controlado { get; set; }

        public long QuantAtual { get; set; }

        public long QuantMinima { get; set; }

        public ICollection<ItemEntrada>  ItemEntradas { get; set; }

        public ICollection<ItemSaida> ItemSaidas { get; set; }
    }
