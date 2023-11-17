namespace ApiEstoque.ViewModels.CategoriaViewModels;

    public class CategoriaInput
    {
        [Key]
         public int Id { get; set; }

         [Required(ErrorMessage = "Campo Obrigátorio.")]
        [MinLength(0, ErrorMessage = "Mínimo de 0 caracteres.")]
        [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres.")]
        public string Titulo { get; set; }
    }
