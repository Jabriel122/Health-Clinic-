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

        public void Atulaizar(Guid id, Clinica clinica)
        {
            Clinica clinicBuscar = _eventContext.Clinica.Find(id)!;

            if (clinicBuscar != null)
            {
                clinicBuscar.NomeFantasia = clinica.NomeFantasia;
                clinicBuscar.Endereco = clinica.Endereco;
                clinicBuscar.CNPJ = clinica.CNPJ;
                clinicBuscar.RazaoSocial = clinica.RazaoSocial;
                clinicBuscar.HorarioAbertura = clinica.HorarioAbertura;
                clinicBuscar.HorarioFechamento = clinica.HorarioFechamento;

            }
            _eventContext.Clinica.Update(clinicBuscar);
            _eventContext.SaveChanges();
        }

        public Clinica BuscarPorId(Guid id)
        {
            try
            {
                Clinica clinicaBuscar = _eventContext.Clinica.Select(u => new Clinica
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

        public void Cadastar(Clinica clínica)
        {
            _eventContext.Clinica.Add(clínica);
            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Clinica clinicaBuscar = _eventContext.Clinica.Find(id);
            _eventContext.Clinica.Remove(clinicaBuscar);
            _eventContext.SaveChanges();
        }

        public List<Clinica> Listar()
        {
            return _eventContext.Clinica.ToList();
        } 
    }
}
