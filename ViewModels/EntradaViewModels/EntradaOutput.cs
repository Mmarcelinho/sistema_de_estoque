namespace ApiEstoque.ViewModels.EntradaViewModels
{
    public class EntradaOutput
    {

        public EntradaOutput(int id, double total, DateTime dataPedido, DateTime dataEntrada, double frete, int numeroNotaFiscal, double imposto, int transportadoraId)
        {
            this.Id = id;
            this.Total = total;
            this.DataPedido = dataPedido;
            this.DataEntrada = dataEntrada;
            this.Frete = frete;
            this.NumeroNotaFiscal = numeroNotaFiscal;
            this.Imposto = imposto;
            this.TransportadoraId = transportadoraId;

        }
        public int Id { get; private set; }

        public double Total { get; private set; }

        public DateTime DataPedido { get; private set; }

        public DateTime DataEntrada { get; private set; }

        public double Frete { get; private set; }

        public int NumeroNotaFiscal { get; private set; }

        public double Imposto { get; private set; }

        public int TransportadoraId { get; private set; }


    }
}