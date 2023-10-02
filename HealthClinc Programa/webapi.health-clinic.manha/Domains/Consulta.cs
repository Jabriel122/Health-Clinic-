using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health_clinic.manha.Domains
{
    [Table(nameof(Consulta))]
    public class Consulta
    {
        [Key]

        public Guid IdConsulta { get; set; } = Guid.NewGuid();

        [Column(TypeName ="SMALLDATETIME")]
        [Required(ErrorMessage = "Data e horario de consulta necessário")]
        public DateTime DataConsultaEHorarioConsulta { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descrição necessária")]
        public string Descricao { get; set; }

        //ForeignKey - Medico

        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]

        public Médico medico { get; set; }

        //ForeignKey - Paciente

        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]

        public Paciente paciente { get; set; }
        
    }
}
