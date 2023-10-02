using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health_clinic.manha.Domains
{
    [Table(nameof(Especialidades))]
    [Index(nameof(NomeEspecialidade))]
    public class Especialidades
    {

        [Key]

        public Guid idEspecialidade { get; set; } =
        Guid.NewGuid();

        [Column(TypeName ="VARCHAR(100)")]
        [Required(ErrorMessage = "Necessário o nome da especialidade")]
        public string? NomeEspecialidade { get; set;}
    }
}
