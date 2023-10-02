using webapi.health_clinic.manha.Domains;

namespace webapi.health_clinic.manha.Interfaces
{
    public interface IPacienteRepository
    {
        void Cadastrar(Paciente paciente);

        void Deletar (Guid id);

        void Atulizar (Guid id, Paciente paciente);

        List<Paciente> Listar ();

        Paciente BuscaPorId (Guid id);
    }
}
