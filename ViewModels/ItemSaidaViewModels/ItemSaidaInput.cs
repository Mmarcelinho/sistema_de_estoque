namespace ApiEstoque.ViewModels.ItemSaidaViewModels;

public class ItemSaidaInput
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo Obrigátorio.")]
    [MinLength(0, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
    [MaxLength(50, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
    public string Lote { get; set; }

    [Required(ErrorMessage = "Campo Obrigátorio.")]
    [Range(0, int.MaxValue)]
    public int Quantidade { get; set; }

    [Required(ErrorMessage = "Campo Obrigátorio.")]
    [Range(0, double.MaxValue)]
    public double Valor { get; set; }

    [Required(ErrorMessage = "Campo Obrigátorio.")]
    public int SaidaId { get; set; }

    [Required(ErrorMessage = "Campo Obrigátorio.")]
    public int ProdutoId { get; set; }

}
