namespace ApiEstoque.ViewModels.CidadeViewModels;

    public class CidadeInput
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Campo obrigátorio.")]
        [MinLength(0, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
        [MaxLength(50, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigátorio.")]
        [MinLength(0, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
        [MaxLength(14, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
        public string Uf { get; set; }
        
    }
