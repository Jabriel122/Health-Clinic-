using webapi.health_clinic.manha.Context;
using webapi.health_clinic.manha.Domains;
using webapi.health_clinic.manha.Interfaces;
using webapi.health_clinic.manha.Utils;

namespace webapi.health_clinic.manha.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EventContext _eventContext;

        public UsuarioRepository()
        {
            _eventContext = new EventContext();
        }
        public void Atulizar(Guid id, Usuario usuario)
        {
            Usuario usuarioBuscar =_eventContext.Usuario.Find(id)!;

            if(usuarioBuscar != null)
            {
                usuarioBuscar.Email = usuario.Email;
                usuarioBuscar.Nome= usuario.Nome;
                usuarioBuscar.Senha= usuario.Senha;
                usuarioBuscar.IdTipoDeUsuario = usuario.IdTipoDeUsuario;
            }
            _eventContext.Usuario.Update(usuarioBuscar);
            _eventContext.SaveChanges();
        }

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _eventContext.Usuario
                    .Select(u => new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        Nome = u.Nome,
                        Email = u.Email,
                        Senha = u.Senha,

                        TiposDeUsuario = new TiposDeUsuario
                        {
                            IdTipoDeUsuario = u.IdTipoDeUsuario,
                            Titulo = u.TiposDeUsuario!.Titulo
                        }
                    }).FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }
                }
                return null;
            }
            catch
            {
                throw;
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                _eventContext.Usuario.Add(usuario);
                _eventContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            Usuario usuarioBuscar = _eventContext.Usuario.Find(id);
            _eventContext.Usuario.Remove(usuarioBuscar);
            _eventContext.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return _eventContext.Usuario.ToList();
        }
    }
}
