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


    public int Numero { get; set; }

    [Required(ErrorMessage = "Campo Obrigátorio.")]
    [MinLength(0, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
    [MaxLength(50, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
    public string Bairro { get; set; }

    [Required(ErrorMessage = "Campo Obrigátorio.")]
    [MinLength(0, ErrorMessage = "Mínimo de 0 a 14 digitos.")]
    [MaxLength(14, ErrorMessage = "Mínimo de 0 a 14 digitos.")]
    public string Cep { get; set; }

    [Required(ErrorMessage = "Campo Obrigátorio.")]
    [MinLength(0, ErrorMessage = "Mínimo de 0 a 18 digitos.")]
    [MaxLength(18, ErrorMessage = "Mínimo de 0 a 18 digitos.")]
    public string Cnpj { get; set; }

    [Required(ErrorMessage = "Campo Obrigátorio.")]
    [MinLength(0, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
    [MaxLength(50, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
    public string Inscricao { get; set; }

    [Required(ErrorMessage = "Campo Obrigátorio.")]
    [MinLength(0, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
    [MaxLength(50, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
    public string Contato { get; set; }

    [Required(ErrorMessage = "Campo Obrigátorio.")]
    [MinLength(0, ErrorMessage = "Mínimo de 0 a 14 digitos.")]
    [MaxLength(14, ErrorMessage = "Mínimo de 0 a 14 digitos.")]
    public string Telefone { get; set; }

    [Required(ErrorMessage = "Campo Obrigátorio.")]
    public int CidadeId { get; set; }
}
