namespace ApiEstoque.ViewModels.ProdutoViewModels;

public class ProdutoInput
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo Obrigátorio.")]
    [MinLength(0, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
    [MaxLength(50, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "Campo Obrigátorio.")]
    [Range(0, double.MaxValue)]
    public double Peso { get; set; }

    [Required(ErrorMessage = "Campo Obrigátorio.")]
    public bool Controlado { get; set; }

    [Required(ErrorMessage = "Campo Obrigátorio.")]
    [Range(0, int.MaxValue)]
    public int QuantMinima { get; set; }
}
