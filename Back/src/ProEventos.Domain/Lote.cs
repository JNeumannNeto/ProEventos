using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProEventos.Domain
{
    public class Lote
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public int Quantidade { get; set; }

        //[ForeignKey("Nome da tabela")]
        public int EventoId { get; set; }

        public Evento? Evento { get; set; }

        [NotMapped]
        public int ContagemDias { get; set; }
    }
}