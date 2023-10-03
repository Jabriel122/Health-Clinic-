using webapi.health_clinic.manha.Domains;

namespace webapi.health_clinic.manha.Interfaces
{
    public interface IMedicoRepository
    {
        void Cadastrar(Medico medico);

        void Deletar(Guid id);

        void Atualizar (Guid id, Medico medico);

        List<Medico> Listar();

        Medico BuscarPorId (Guid id);

        Medico BuscarPorEspecialidade (Guid id, Medico medico);
    }
}
