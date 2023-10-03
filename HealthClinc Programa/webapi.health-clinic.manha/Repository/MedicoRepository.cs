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
        public void Atualizar(Guid id, Medico medico)
        {
            Medico medicoBuscar = _eventContext.Medico.Find(id)!;  

            if (medicoBuscar != null)
            {
                medicoBuscar.CRM = medico.CRM;
                medicoBuscar.IdClinica = medico.IdClinica;
                medicoBuscar.IdEspecialidade = medico.IdEspecialidade;
                medicoBuscar.IdUsuario = medico.IdUsuario;
            }
            _eventContext.Medico.Update(medicoBuscar);
            _eventContext.SaveChanges();
        }

        public Medico BuscarPorEspecialidade(Guid id, Medico medico)
        {
            throw new NotImplementedException();
        }

        public Medico BuscarPorId(Guid id)
        {
            try
            {
                Medico medicoBuscar = _eventContext.Medico.Select(u => new Medico
                {
                    IdMedico = u.IdMedico,
                    CRM = u.CRM,
                    IdEspecialidade = u.IdEspecialidade,
                    IdClinica = u.IdClinica,
                    IdUsuario = u.IdUsuario

                }).FirstOrDefault(u => u.IdMedico == id)!;

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

        public void Cadastrar(Medico medico)
        {
            _eventContext.Medico.Add(medico);
            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Medico medicoBuscar = _eventContext.Medico.Find(id);

            _eventContext.Medico.Remove(medicoBuscar);
            _eventContext.SaveChanges();
        }

        public List<Medico> Listar()
        {
            return _eventContext.Medico.ToList();
        } 
    }
}
