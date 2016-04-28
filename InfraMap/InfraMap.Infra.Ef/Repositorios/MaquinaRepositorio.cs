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
                db.ModeloMaquina.Attach(entity.ModeloMaquina);
                db.Entry(entity.ModeloMaquina).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
             }
         }

        public new void Deletar(Maquina entity)
        {
            using (var dbContext = new DataBaseContext())
            {
                var dbEntity = this.BuscarPorId(entity.Id);
                dbContext.Maquina.Attach(dbEntity);
                dbContext.Maquina.Remove(dbEntity);
                dbContext.SaveChanges();
            }
        }
    }
}
