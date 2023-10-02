using webapi.health_clinic.manha.Context;
using webapi.health_clinic.manha.Domains;
using webapi.health_clinic.manha.Interfaces;

namespace webapi.health_clinic.manha.Repository
{
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly EventContext _eventContext;

        public ClinicaRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atulaizar(Guid id, Clínica clínica)
        {
            Clínica clinicBuscar = _eventContext.Clinica.Find(id)!;

            if (clinicBuscar != null)
            {
                clinicBuscar.NomeFantasia = clínica.NomeFantasia;
                clinicBuscar.Endereco = clínica.Endereco;
                clinicBuscar.CNPJ = clínica.CNPJ;
                clinicBuscar.RazaoSocial = clínica.RazaoSocial;
                clinicBuscar.HorarioAbertura = clínica.HorarioAbertura;
                clinicBuscar.HorarioFechamento = clínica.HorarioFechamento;

            }
            _eventContext.Clinica.Update(clinicBuscar);
            _eventContext.SaveChanges();
        }

        public Clínica BuscarPorId(Guid id)
        {
            try
            {
                Clínica clinicaBuscar = _eventContext.Clinica.Select(u => new Clínica
                {
                    IdClinica = u.IdClinica,
                    NomeFantasia = u.NomeFantasia,
                    Endereco = u.Endereco,
                    CNPJ = u.CNPJ,
                    RazaoSocial = u.RazaoSocial,
                    HorarioAbertura = u.HorarioAbertura,
                    HorarioFechamento = u.HorarioFechamento


                }).FirstOrDefault(u => u.IdClinica == id)!;

                if (clinicaBuscar != null)
                {
                    return clinicaBuscar;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public void Cadastar(Clínica clínica)
        {
            _eventContext.Clinica.Add(clínica);
            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Clínica clinicaBuscar = _eventContext.Clinica.Find(id);
            _eventContext.Clinica.Remove(clinicaBuscar);
            _eventContext.SaveChanges();
        }

        public List<Clínica> Listar()
        {
            return _eventContext.Clinica.ToList();
        }
    }
}
