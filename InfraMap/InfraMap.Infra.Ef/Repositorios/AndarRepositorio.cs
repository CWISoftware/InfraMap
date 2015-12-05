using InfraMap.Dominio.ModuloAndar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Infraestrutura.Ef.Repositorios
{
    public class AndarRepositorio : RepositorioBase<Andar>, IAndarRepositorio
    {
        public List<Andar> BuscarAndaresPorSede(int idSede)
        {
            using (var db = new DataBaseContext())
            {
                return null;
            }
        }
    }
}
