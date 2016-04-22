using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraMap.Dominio.Mesa.Maquina;

namespace InfraMap.Infraestrutura.Ef.Repositorios
{
    public class MaquinaRepositorio : RepositorioBase<Maquina>, IMaquinaRepositorio
    {
        public Maquina BuscarPorIdModelo(int id)
        {
            using (var db = new DataBaseContext())
            {
                return db.Maquina.FirstOrDefault(m => m.ModeloMaquina_Id == id);
            }
        }
    }
}
