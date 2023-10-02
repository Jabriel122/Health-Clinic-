using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using webapi.health_clinic.manha.Domains;

namespace webapi.health_clinic.manha.Context
{
    public class EventContext : DbContext
    {

        public DbSet<Clínica> Clinica { get; set; }
        public DbSet<ComentarioConsulta> ComentarioConsulta { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Especialidades> Especialidades { get; set; }
        public DbSet<Médico> Médico { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<TiposDeUsuario> TiposDeUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = DESKTOP-VLQ1I1C; Database = healthclinic_manha; User Id= sa; Pwd= Senai@134; TrustServerCertificate= True;");
            base.OnConfiguring(optionsBuilder) ;

        }
    }
}
