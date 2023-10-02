using webapi.health_clinic.manha.Context;
using webapi.health_clinic.manha.Domains;
using webapi.health_clinic.manha.Interfaces;

namespace webapi.health_clinic.manha.Repository
{
    public class ComentarioConsultaRepository : IComentarioConsultaRepository
    {

        private readonly EventContext _eventContext;

        public ComentarioConsultaRepository()
        {
            _eventContext = new EventContext();
        }
        public void Atualizar(Guid id, ComentarioConsulta comentarioConsulta)
        {
            ComentarioConsulta comentarioConsultaBuscar = _eventContext.ComentarioConsulta.Find(id)!;

            if (comentarioConsultaBuscar != null)
            {
                comentarioConsultaBuscar.Comentario = comentarioConsulta.Comentario;
                comentarioConsultaBuscar.situacao = comentarioConsulta.situacao;
                comentarioConsultaBuscar.IdConsulta = comentarioConsulta.IdConsulta;
            }
            _eventContext.ComentarioConsulta.Update(comentarioConsultaBuscar);
            _eventContext.SaveChanges();
        }

        public void Cadastrar(ComentarioConsulta comentarioConsulta)
        {
            _eventContext.ComentarioConsulta.Add(comentarioConsulta);
            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            ComentarioConsulta comentarioConsultaBuscar = _eventContext.ComentarioConsulta.Find(id)!;
            _eventContext.Remove(comentarioConsultaBuscar);
            _eventContext.SaveChanges();
        }

        public List<ComentarioConsulta> Listar()
        {
            return _eventContext.ComentarioConsulta.ToList();
        }
    }
}
