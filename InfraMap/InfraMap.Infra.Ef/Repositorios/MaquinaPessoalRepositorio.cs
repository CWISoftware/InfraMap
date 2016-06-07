using InfraMap.Dominio.Mesa.Maquina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Infraestrutura.Ef.Repositorios
{
    public class MaquinaPessoalRepositorio : RepositorioBase<MaquinaPessoal>,IMaquinaPessoalRepositorio
    {
        public new MaquinaPessoal Adicionar(MaquinaPessoal entity)
        {
            using (var db = new DataBaseContext())
            {
                db.Entry(entity.Maquina.ModeloMaquina).State = System.Data.Entity.EntityState.Unchanged;
                db.Entry(entity).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
                return entity;
            }
        }

        public int BuscarPorPatrimonio(MaquinaPessoal maquina)
        {
            // se retorna o id da mesa deveria estar no repositorio da mesa, não precisa buscar a maquina já que recebe por parametro
            using (var db = new DataBaseContext())
            {
                var maq = db.MaquinaPessoal.FirstOrDefault(t => t.Patrimonio == maquina.Patrimonio);
                if (maq != null)
                {
                    var mesa = db.Mesa.First(r => r.MaquinaPessoal_Id == maq.Id);
                    return mesa.Id;
                }
                else
                    return 0;
            }
        }

        public int BuscarPorEtiquetaServico(MaquinaPessoal maquina)
        {
            using (var db = new DataBaseContext())
            {
                var maq = db.MaquinaPessoal.FirstOrDefault(t => t.EtiquetaServico == maquina.EtiquetaServico);
                if (maq != null)
                {
                    var mesa = db.Mesa.First(r => r.MaquinaPessoal_Id == maq.Id);
                    return mesa.Id;
                }
                else
                    return 0;
            }
        }

        public MaquinaPessoal BuscarPorPatrimonio2(int patrimonio)
        {
            using (var db = new DataBaseContext())
            {
                return db.MaquinaPessoal.Include("Maquina.ModeloMaquina").FirstOrDefault(m => m.Patrimonio == patrimonio);
            }
        }

        public List<MaquinaPessoal> BuscarTodas()
        {
            using (var db = new DataBaseContext())
            {
                return db.MaquinaPessoal.Include("Maquina.ModeloMaquina").ToList();
            }
        }
    }
}
