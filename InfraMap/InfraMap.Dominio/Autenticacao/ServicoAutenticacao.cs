using InfraMap.Dominio.Usuario;

namespace InfraMap.Dominio.Autenticacao
{
    public class ServicoAutenticacao
    {
        private IUsuarioRepositorio usuarioRepositorio;
        private IServicoCriptografia servicoCriptografia;

        public ServicoAutenticacao(IUsuarioRepositorio usuarioRepositorio, IServicoCriptografia servicoCriptografia)
        {
            this.usuarioRepositorio = usuarioRepositorio;
            this.servicoCriptografia = servicoCriptografia;
        }

        public Usuario.Usuario BuscarPorAutenticacao(string login, string senha)
        {
            Usuario.Usuario usuario = this.usuarioRepositorio.BuscarPorLogin(login);

            if (usuario != null)
            {
                string senhaCriptografada = servicoCriptografia.CriptografarSenha(senha);

                if (usuario.Senha.ToUpper() != senhaCriptografada)
                {
                    return null;
                }
            }

            return usuario;
        }

    }
}
