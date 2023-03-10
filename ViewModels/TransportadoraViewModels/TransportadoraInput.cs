namespace ApiEstoque.ViewModels.TransportadoraViewModels;

public class TransportadoraInput
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

    [Required(ErrorMessage = "Campo Obrigátorio")]
    [MinLength(8, ErrorMessage = "Informe o dado corretamente.")]
    [MaxLength(9, ErrorMessage = "Informe o dado corretamente.")]
    public string Cep { get; set; }

    [MinLength(14, ErrorMessage = "Informe o dado corretamente.")]
    [MaxLength(18, ErrorMessage = "Informe o dado corretamente.")]
    public string Cnpj { get; set; }

    [Required(ErrorMessage = "Campo Obrigátorio.")]
    [MinLength(0, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
    [MaxLength(50, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
    public string Inscricao { get; set; }

    [EmailAddress]
    [Required(ErrorMessage = "Campo Obrigátorio.")]
    [MinLength(0, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
    [MaxLength(50, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
    public string Contato { get; set; }

    [Required(ErrorMessage = "Campo Obrigátorio.")]
    [MinLength(11, ErrorMessage = "Informe o dado corretamente.")]
    [MaxLength(15, ErrorMessage = "Informe o dado corretamente.")]
    public string Telefone { get; set; }

    [Required(ErrorMessage = "Campo Obrigátorio.")]
    public int CidadeId { get; set; }
}
