using webapi.health_clinic.manha.Context;
using webapi.health_clinic.manha.Domains;
using webapi.health_clinic.manha.Interfaces;

namespace webapi.health_clinic.manha.Repository
{
    public class TiposDeUsuarioRepository : ITipoDeUsuarioRepository
    {
        private readonly EventContext _eventContext;

        public TiposDeUsuarioRepository() 
        {
            _eventContext = new EventContext();
        }
        public void Cadastrar(TiposDeUsuario tiposDeUsuario)
        {
            _eventContext.TiposDeUsuario.Add(tiposDeUsuario);
            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            TiposDeUsuario tiposDeUsuario = _eventContext.TiposDeUsuario.Find(id);
            _eventContext.TiposDeUsuario.Remove(tiposDeUsuario);
            _eventContext.SaveChanges();
        }

        public List<TiposDeUsuario> Listar()
        {
            return _eventContext.TiposDeUsuario.ToList();
        }
    }
}
