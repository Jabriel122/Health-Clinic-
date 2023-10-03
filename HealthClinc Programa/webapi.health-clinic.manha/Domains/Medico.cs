using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health_clinic.manha.Domains
{
    [Table(nameof(Medico))]
    public class Medico
    {
        [Key]

        public Guid IdMedico { get; set; } = Guid.NewGuid();

        [Column(TypeName = " VARCHAR(8)")]
        [Required(ErrorMessage = "CRM obrigatório")]
        public string CRM { get; set; }

        //ForeignKey 1 - Especialidade

        public Guid IdEspecialidade { get; set; }

        [ForeignKey(nameof(IdEspecialidade))]

        public Especialidades? especialidades { get; set; }

        //ForeingKey 2 - Clinica

        public Guid IdClinica { get; set; }

        [ForeignKey(nameof(IdClinica))]

        public Clinica? clinica { get; set; }

        //Foreing Key - Usuario

        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? usuario { get; set;}




    }
}
