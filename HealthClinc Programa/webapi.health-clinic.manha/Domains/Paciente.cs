using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health_clinic.manha.Domains
{
    [Table(nameof(Paciente))]
    [Index(nameof(CPF), IsUnique = true)] 
    public class Paciente
    {
        [Key]
        public Guid IdPacioente { get; set; } = Guid.NewGuid();

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data deve ser mencionada")]
        public DateTime DataDeNascimento { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O genero que você se identifica deve ser mencionado")]
        public string Genero { get; set; }

        [Column(TypeName = "VARCHAR(11)")]
        [Required(ErrorMessage = "O CPF é obrigatório")]
        public string CPF { get; set; }

        //Foreign Key - Tipo de Usuario 

        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario Usuario { get; set; }
    }
}
