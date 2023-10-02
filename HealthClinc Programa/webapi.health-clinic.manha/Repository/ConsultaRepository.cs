using webapi.health_clinic.manha.Context;
using webapi.health_clinic.manha.Domains;
using webapi.health_clinic.manha.Interfaces;

namespace webapi.health_clinic.manha.Repository
{
    public class ConsultaRepository : IConsultaRepository
    {

        private readonly EventContext _eventContext;

        public ConsultaRepository()
        {
            _eventContext = new EventContext();
        }


        public void Atualizar(Guid Id, Consulta consulta)
        {
            Consulta consultaBuscar = _eventContext.Consulta.Find(Id)!;

            if (consultaBuscar != null)
            {
                consultaBuscar.DataConsultaEHorarioConsulta = consulta.DataConsultaEHorarioConsulta;
                consultaBuscar.Descricao = consulta.Descricao;
                consultaBuscar.IdMedico = consulta.IdMedico;
                consultaBuscar.IdPaciente = consulta.IdPaciente;
            }
            _eventContext.Consulta.Update(consultaBuscar);
            _eventContext.SaveChanges();
        }

        public void Cadastrar(Consulta consulta)
        {
            _eventContext.Add(consulta);
            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Consulta consultaBiscar = _eventContext.Consulta.Find(id);
            _eventContext.Remove(consultaBiscar);
            _eventContext.SaveChanges();
        }

        public List<Consulta> Listar()
        {
            return _eventContext.Consulta.ToList();
        }

        public List<Consulta> ListarPorMedico(Guid id)
        {
            List<Consulta> lista = new List<Consulta>();

            foreach (var consulta in _eventContext.Consulta)
            {
                if (consulta.IdMedico == id)
                {
                    lista.Add(consulta);
                }
            }

            return lista;
        }

        public List<Consulta> ListarPorPaciente(Guid id)
        {
            List<Consulta> lista = new List<Consulta>();

            foreach (var consulta in _eventContext.Consulta)
            {
                if(consulta.IdPaciente == id)
                {
                    lista.Add(consulta);
                }
            }

            return lista;
        }
    }
}
