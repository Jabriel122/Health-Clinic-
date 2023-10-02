using webapi.health_clinic.manha.Domains;

namespace webapi.health_clinic.manha.Interfaces
{
    public interface IMedicoRepository
    {
        void Cadastrar(Médico médico);

        void Deletar(Guid id);

        void Atualizar (Guid id, Médico médico);

        List<Médico> Listar();

        Médico BuscarPorId (Guid id);

        Médico BuscarPorEspecialidade (Guid id, Médico médico);
    }
}
