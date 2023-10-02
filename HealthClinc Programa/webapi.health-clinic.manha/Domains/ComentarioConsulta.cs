using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health_clinic.manha.Domains
{
    [Table(nameof(ComentarioConsulta))]
    public class ComentarioConsulta
    {
        [Key]

        public Guid IdComentarioConsulta { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Comentário obrigatório")]
        public string Comentario { get; set; }

        public bool situacao { get; set; }

        //Foreign KEy - Consulta

        public Guid IdConsulta { get; set; }

        [ForeignKey(nameof(IdConsulta))]

        public Consulta Consulta { get; set; }

    }
}
