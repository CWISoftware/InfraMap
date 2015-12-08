namespace InfraMap.Dominio.Sede.Andar
{
    public interface IAndarRepositorio 
    {
        Andar BuscarPorId(int id);

        Andar BuscarPorMesa(Mesa.Mesa mesa);
    }
}
