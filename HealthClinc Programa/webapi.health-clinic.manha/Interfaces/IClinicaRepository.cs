using webapi.health_clinic.manha.Domains;

namespace webapi.health_clinic.manha.Interfaces
{
    public interface  IClinicaRepository
    {
        void Cadastar(Clínica clínica);

        void Deletar(Guid id);

        void Atulaizar(Guid id, Clínica clínica);

        List<Clínica> Listar();


        Clínica BuscarPorId(Guid id);
    }
}
