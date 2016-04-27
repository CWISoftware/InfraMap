using InfraMap.Dominio.Mesa.Maquina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Infraestrutura.Ef.Repositorios
{
    public class ModeloMaquinaRepositorio : RepositorioBase<ModeloMaquina>, IModeloMaquinaRepositorio
    {
        public List<ModeloMaquina> BuscarTodos()
        {
            using (var db = new DataBaseContext())
            {
                return db.ModeloMaquina.ToList();
            }
        }

        public new void Deletar(ModeloMaquina entity)
        {
            using (var dbContext = new DataBaseContext())
            {
                var dbEntity = this.BuscarPorId(entity.Id);
                dbContext.ModeloMaquina.Attach(dbEntity);
                dbContext.ModeloMaquina.Remove(dbEntity);
                dbContext.SaveChanges();
            }
        }
    }
}
