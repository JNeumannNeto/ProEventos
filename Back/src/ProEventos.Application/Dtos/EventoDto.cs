using System.ComponentModel.DataAnnotations;

namespace ProEventos.Application.Dtos
{
    public class EventoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        public string Local {get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        public string DataEvento { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [MinLength(3, ErrorMessage = "{0} deve ter no mínimo 3 caracteres.")]
        [MaxLength(50, ErrorMessage = "{0} deve ter no máximo 50 caracteres.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0} deve ter entre 3 e 50 caracteres.")]
        public string Tema { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [Display(Name = "Qtd de pessoas")]
        [Range(1, 500, ErrorMessage = "{0} precisa estar entre 1 e 500.")]
        public int QtdPessoas {get ;set;}

        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$", ErrorMessage = "Não é uma imagem válida (gif, jpg, jpeg, bmp ou png)")]
        public string ImagemURL { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [Phone(ErrorMessage = "{0} aceita apenas números")]
        public string Telefone { get; set; }

        [Display(Name = "e-mail")]
        [Required(ErrorMessage = "{0} é obrigatório.")]
        [EmailAddress(ErrorMessage = "{0} precisa ser um endereço válido.")]
        public string Email { get; set; }

        public IEnumerable<LoteDto> Lotes {get; set;}

        public IEnumerable<RedeSocialDto> RedesSociais { get; set; }

        public IEnumerable<PalestranteDto> Palestrantes { get; set; }
    }
}