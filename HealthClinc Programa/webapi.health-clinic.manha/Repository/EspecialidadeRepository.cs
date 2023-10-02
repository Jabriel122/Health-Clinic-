using webapi.health_clinic.manha.Context;
using webapi.health_clinic.manha.Domains;
using webapi.health_clinic.manha.Interfaces;

namespace webapi.health_clinic.manha.Repository
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly EventContext _eventContext;

        public EspecialidadeRepository()
        {
            _eventContext = new EventContext();
        }

        public void Cadastrar(Especialidades especialidades)
        {
            _eventContext.Add(especialidades);
            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Especialidades especialidadesBuscar = _eventContext.Especialidades.Find(id);
            _eventContext.Remove(especialidadesBuscar);
            _eventContext.SaveChanges();
        }

        public List<Especialidades> Listar()
        {
            return _eventContext.Especialidades.ToList();
        }
    }
}
