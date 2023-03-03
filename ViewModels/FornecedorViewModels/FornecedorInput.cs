namespace ApiEstoque.ViewModels.FornecedorViewModels;

public class FornecedorInput
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo Obrigátorio")]
    [MinLength(0, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
    [MaxLength(50, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Campo Obrigátorio")]
    [MinLength(0, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
    [MaxLength(50, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
    public string Endereco { get; set; }

    [Required(ErrorMessage = "Campo Obrigátorio")]
    [Range(0, int.MaxValue)]
    public int Numero { get; set; }

    [Required(ErrorMessage = "Campo Obrigátorio")]
    [MinLength(0, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
    [MaxLength(50, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
    public string Bairro { get; set; }

    [Required(ErrorMessage = "Campo Obrigátorio")]
    [MinLength(0, ErrorMessage = "Mínimo de 0 a 9 digitos")]
    [MaxLength(9, ErrorMessage = "Mínimo de 0 a 9 digitos")]
    public string Cep { get; set; }

    [MinLength(0, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
    [MaxLength(50, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
    public string Contato { get; set; }

    [MinLength(0, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
    [MaxLength(18, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
    public string Cnpj { get; set; }

    [MinLength(0, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
    [MaxLength(50, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
    public string Inscricao { get; set; }

    [Required(ErrorMessage = "Campo Obrigátorio")]
    public int CidadeId { get; set; }
}
