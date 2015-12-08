using System.Collections.Generic;
using InfraMap.Comum;

namespace InfraMap.Dominio.Sede
{
    public interface ISedeRepositorio : IRepositorio<Sede>
    {
        List<Sede> BuscarTodasAsSedes();

        List<Sede> BuscarSedesComAndares();

        Sede BuscarSedePorNome(string nome);

        Sede BuscarSedePorAndar(Andar.Andar andar);
    }
}
