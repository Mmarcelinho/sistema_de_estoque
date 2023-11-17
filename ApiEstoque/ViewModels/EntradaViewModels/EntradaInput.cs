namespace ApiEstoque.ViewModels.EntradaViewModels;

public class EntradaInput
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo obrigátorio.")]
    [Range(0, double.MaxValue)]
    public double Total { get; set; }

    [Required(ErrorMessage = "Campo obrigátorio.")]
    [Range(0, double.MaxValue)]
    public double Frete { get; set; }

    [Required(ErrorMessage = "Campo obrigátorio.")]
    [Range(0, int.MaxValue)]
    public int NumeroNotaFiscal { get; set; }

    [Required(ErrorMessage = "Campo obrigátorio.")]
    [Range(0, double.MaxValue)]
    public double Imposto { get; set; }

    [Required(ErrorMessage = "Campo obrigátorio.")]
    public int TransportadoraId { get; set; }

}
