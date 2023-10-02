using webapi.health_clinic.manha.Domains;

namespace webapi.health_clinic.manha.Interfaces
{
    public interface ITipoDeUsuarioRepository
    {
        void Cadastrar(TiposDeUsuario tiposDeUsuario);

        void Deletar(Guid id);

        List<TiposDeUsuario> Listar();
    }
}
