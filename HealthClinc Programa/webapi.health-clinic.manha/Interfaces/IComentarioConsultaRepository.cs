using webapi.health_clinic.manha.Domains;

namespace webapi.health_clinic.manha.Interfaces
{
    public interface IComentarioConsultaRepository
    {
        void Cadastrar(ComentarioConsulta comentarioConsulta);

        void Deletar(Guid id);

        void Atualizar (Guid id, ComentarioConsulta comentarioConsulta);

        List<ComentarioConsulta> Listar();
    }
}
