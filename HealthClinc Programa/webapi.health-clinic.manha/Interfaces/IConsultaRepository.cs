using webapi.health_clinic.manha.Domains;

namespace webapi.health_clinic.manha.Interfaces
{
    public interface IConsultaRepository
    {
        void Cadastrar(Consulta consulta);

        void Deletar(Guid id); 

        void Atualizar(Guid Id, Consulta consulta);

        List<Consulta> Listar();

        List<Consulta> ListarPorPaciente (Guid id);

        List<Consulta> ListarPorMedico (Guid id);
    }
}
