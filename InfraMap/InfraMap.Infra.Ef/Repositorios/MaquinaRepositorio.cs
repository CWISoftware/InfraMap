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

        public ModeloMaquina RetornaNomeMaquina(Maquina maquina)
        {
            using (var db = new DataBaseContext())
            {
                return db.ModeloMaquina.FirstOrDefault(m => m.Id == maquina.ModeloMaquina_Id);

            }
        }

        public new void Atualizar(Maquina entity)
        {
            using (var db = new DataBaseContext())
            {
               db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
               db.Maquina.Attach(entity);
               db.Entry(entity.ModeloMaquina).State = System.Data.Entity.EntityState.Modified;
               db.SaveChanges();
            }
        }
    }
}
