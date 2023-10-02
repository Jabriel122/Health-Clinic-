using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health_clinic.manha.Domains
{
    [Table(nameof(Clínica))]
    public class Clínica
    {
        [Key]
        public Guid IdClinica { get; set; } =
        Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome fantasia é obrigatório")]
        public string NomeFantasia { get; set; }

        [Column(TypeName ="VARCHAR(150)")]
        [Required(ErrorMessage = "Endereço obrigatório")]
        public string Endereco { get; set; }

        [Column(TypeName = "VARCHAR(200)" )]
        [Required(ErrorMessage = "Razão social é obrigatório")]
        public string RazaoSocial { get; set; }

        [Column(TypeName = "SMALLDATETIME")]
        [Required(ErrorMessage = "Horairo de Abertura é obrigatório")]
        public DateTime HorarioAbertura { get; set; }

        [Column(TypeName = "SMALLDATETIME")]
        [Required(ErrorMessage = "Horairo de Fechamento é obrigatório")]
        public DateTime HorarioFechamento { get; set;}

        [Column(TypeName = "CHAR(14)")]
        [Required(ErrorMessage = "CNPJ Obrigatória")]
        public string CNPJ { get; set; }
    }
}
