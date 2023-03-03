namespace ApiEstoque.ViewModels.CategoriaViewModels;

    public class CategoriaInput
    {
        [Key]
         public int Id { get; set; }

        [Required]
        [MinLength(0, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
        [MaxLength(50, ErrorMessage = "Mínimo de 0 a 50 caracteres.")]
        public string Titulo { get; set; }
    }
