using webapi.health_clinic.manha.Domains;

namespace webapi.health_clinic.manha.Interfaces
{
    public interface IUsuarioRepository
    {

        void Cadastrar(Usuario usuario);

        void Deletar (Guid id);

        void Atulizar (Guid id, Usuario usuario);

        List<Usuario> Listar ();

        Usuario BuscarPorEmailESenha(String email, String senha);
    }
}
