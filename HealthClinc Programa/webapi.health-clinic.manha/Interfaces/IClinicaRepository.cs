using webapi.health_clinic.manha.Domains;

namespace webapi.health_clinic.manha.Interfaces
{
    public interface  IClinicaRepository
    {
        void Cadastar(Clinica clínica);

        void Deletar(Guid id);

        void Atulaizar(Guid id, Clinica clínica);

        List<Clinica> Listar();


        Clinica BuscarPorId(Guid id);
    }
}
