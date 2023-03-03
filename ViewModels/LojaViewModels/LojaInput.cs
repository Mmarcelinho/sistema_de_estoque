namespace ApiEstoque.ViewModels.LojaViewModels;

public class LojaInput
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo Obrigátorio.")]
    [MinLength(0, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
    [MaxLength(50, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Campo Obrigátorio.")]
    [MinLength(0, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
    [MaxLength(50, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
    public string Endereco { get; set; }

    [Required(ErrorMessage = "Campo Obrigátorio.")]
    [Range(0, int.MaxValue)]
    public int Numero { get; set; }

    [Required(ErrorMessage = "Campo Obrigátorio.")]
    [MinLength(0, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
    [MaxLength(50, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
    public string Bairro { get; set; }

    [Required(ErrorMessage = "Campo Obrigátorio.")]
    [MinLength(0, ErrorMessage = "Mínimo de 0 a 14 digitos.")]
    [MaxLength(14, ErrorMessage = "Mínimo de 0 a 14 digitos.")]
    public string Telefone { get; set; }

    [Required(ErrorMessage = "Campo Obrigátorio.")]
    [MinLength(0, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
    [MaxLength(50, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
    public string Inscricao { get; set; }

    [Required(ErrorMessage = "Campo Obrigátorio.")]
    [MinLength(0, ErrorMessage = "Mínimo de 0 a 18 digitos.")]
    [MaxLength(18, ErrorMessage = "Mínimo de 0 a 18 digitos.")]
    public string Cnpj { get; set; }

    [Required(ErrorMessage = "Campo Obrigátorio.")]
    public int CidadeId { get; set; }
}
