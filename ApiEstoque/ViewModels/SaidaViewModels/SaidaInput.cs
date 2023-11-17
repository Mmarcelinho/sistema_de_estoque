namespace ApiEstoque.ViewModels.SaidaViewModels;

public class SaidaInput
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo Obrigátorio.")]
    [Range(0, double.MaxValue)]
    public double Total { get; set; }

    [Required(ErrorMessage = "Campo Obrigátorio.")]
    [Range(0, double.MaxValue)]
    public double Frete { get; set; }

    [Required(ErrorMessage = "Campo Obrigátorio.")]
    [Range(0, double.MaxValue)]
    public double Imposto { get; set; }

    [Required(ErrorMessage = "Campo Obrigátorio.")]
    public int LojaId { get; set; }
    
    [Required(ErrorMessage = "Campo Obrigátorio.")]
    public int TransportadoraId { get; set; }

}
