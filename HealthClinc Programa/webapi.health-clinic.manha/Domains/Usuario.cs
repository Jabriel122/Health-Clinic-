using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health_clinic.manha.Domains
{
    [Table(nameof(Usuario))]
    [Index(nameof(Email))]
    public class Usuario
    {
        [Key]

        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName ="VARCHAR(100)")]
        [Required(ErrorMessage = "Email Necessário")]
        public string Email { get; set; }

        [Column(TypeName = "CHAR(60)")]
        [Required(ErrorMessage = "Senha Necessário")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "Senha deve conter de 6 a 60 caracteres")]
        public string Senha { get; set; }

        [Column(TypeName ="VARCHAR(150)")]
        [Required(ErrorMessage = "Nome obrigatório")]
        public string Nome { get; set; }


        //ForeignKey 

        public Guid IdTipoDeUsuario { get; set; }

        [ForeignKey(nameof(IdTipoDeUsuario))]

        public TiposDeUsuario? TiposDeUsuario { get; set; }
    }
}
