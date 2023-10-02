using webapi.health_clinic.manha.Context;
using webapi.health_clinic.manha.Domains;
using webapi.health_clinic.manha.Interfaces;

namespace webapi.health_clinic.manha.Repository
{
    public class PacienteRepository : IPacienteRepository
    {

        private readonly EventContext _eventContext;

        public PacienteRepository() 
        {
            _eventContext = new EventContext();
        }

        public void Atulizar(Guid id, Paciente paciente)
        {
            Paciente pacienteBuscar = _eventContext.Paciente.Find(id)!;

            if (pacienteBuscar != null)
            {
                pacienteBuscar.DataDeNascimento = paciente.DataDeNascimento;
                pacienteBuscar.CPF = paciente.CPF;
                pacienteBuscar.Genero = paciente.Genero;
                pacienteBuscar.IdUsuario = paciente.IdUsuario;
            }
            _eventContext.Paciente.Update(pacienteBuscar);
            _eventContext.SaveChanges();
        }

        public Paciente BuscaPorId(Guid id)
        {
            try
            {
                Paciente pacienteBuscar = _eventContext.Paciente.Select(u => new Paciente
                {
                    IdPacioente = u.IdPacioente,
                    DataDeNascimento = u.DataDeNascimento,
                    Genero = u.Genero,
                    CPF = u.CPF,
                    IdUsuario = u.IdUsuario

                }).FirstOrDefault(u => u.IdPacioente == id)!;

                if (pacienteBuscar != null)
                {
                    return pacienteBuscar;
                }
                return null;
            }
            catch(Exception ex)
            {
                throw;
            }
           

        }

        public void Cadastrar(Paciente paciente)
        {
            _eventContext.Paciente.Add(paciente);
            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Paciente pacienteBuscar = _eventContext.Paciente.Find(id);
            _eventContext.Remove(pacienteBuscar);
            _eventContext.SaveChanges();
        }

        public List<Paciente> Listar()
        {
            return _eventContext.Paciente.ToList();
        }
    }
}
