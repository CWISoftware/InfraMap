namespace InfraMap.Dominio.Autenticacao
{
    public interface IServicoCriptografia
    {
        string CriptografarSenha(string senha);
    }
}
