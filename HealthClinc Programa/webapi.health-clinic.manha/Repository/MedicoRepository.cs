using webapi.health_clinic.manha.Context;
using webapi.health_clinic.manha.Domains;
using webapi.health_clinic.manha.Interfaces;

namespace webapi.health_clinic.manha.Repository
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly EventContext _eventContext;

        public MedicoRepository()
        {
            _eventContext = new EventContext();
        }
        public void Atualizar(Guid id, Médico médico)
        {
            Médico medicoBuscar = _eventContext.Médico.Find(id)!;

            if (medicoBuscar != null)
            {
                medicoBuscar.CRM = médico.CRM;
                medicoBuscar.IdClinica = médico.IdClinica;
                medicoBuscar.IdEspecialidade = médico.IdEspecialidade;
                medicoBuscar.IdUsuario = médico.IdUsuario;
            }
            _eventContext.Médico.Update(medicoBuscar);
            _eventContext.SaveChanges();
        }

        public Médico BuscarPorEspecialidade(Guid id, Médico médico)
        {
            throw new NotImplementedException();
        }

        public Médico BuscarPorId(Guid id)
        {
            try
            {
                Médico medicoBuscar = _eventContext.Médico.Select(u => new Médico
                {
                    idMedico = u.idMedico,
                    CRM = u.CRM,
                    IdEspecialidade = u.IdEspecialidade,
                    IdClinica = u.IdClinica,
                    IdUsuario = u.IdUsuario

                }).FirstOrDefault(u => u.idMedico == id)!;

                if (medicoBuscar  != null)
                {
                    return medicoBuscar;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Cadastrar(Médico médico)
        {
            médico.idMedico = Guid.NewGuid();

            _eventContext.Add(médico);
            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Médico medicoBuscar = _eventContext.Médico.Find(id);

            _eventContext.Remove(medicoBuscar);
            _eventContext.SaveChanges();
        }

        public List<Médico> Listar()
        {
            return _eventContext.Médico.ToList();
        }
    }
}
