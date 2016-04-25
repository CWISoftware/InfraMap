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

        public new void Adicionar(Maquina entity)
        {
            using (var db = new DataBaseContext())
            {
                db.Maquina.Add(entity);
                db.SaveChanges();
            }
        }

        public new void Atualizar(Maquina entity)
        {
            using (var db = new DataBaseContext())
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

    }
}
