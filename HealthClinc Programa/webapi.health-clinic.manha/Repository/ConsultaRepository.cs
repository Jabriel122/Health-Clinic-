using webapi.health_clinic.manha.Domains;
using webapi.health_clinic.manha.Interfaces;

namespace webapi.health_clinic.manha.Repository
{
    public class ConsultaRepository : IConsultaRepository
    {
        public void Atualizar(Guid Id, Consulta consulta)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Consulta consulta)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Consulta> Listar()
        {
            throw new NotImplementedException();
        }

        public List<Consulta> ListarPorMedico(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Consulta> ListarPorPaciente(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
