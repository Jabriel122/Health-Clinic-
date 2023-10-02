using webapi.health_clinic.manha.Domains;

namespace webapi.health_clinic.manha.Interfaces
{
    public interface IEspecialidadeRepository
    {
        void Cadastrar(Especialidades especialidades);

        void Deletar (Guid id);

        List<Especialidades> Listar();
    }
}
