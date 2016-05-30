using InfraMap.Dominio.Mesa;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Infraestrutura.Ef.Repositorios
{
    public class MesaRepositorio : IMesaRepositorio
    {
        public Mesa BuscarMesaPorColaborador(string loginColaborador)
        {
            using (var db = new DataBaseContext())
            {
                return db.Mesa.Include("Colaborador").Include("MaquinaPessoal").Include("Ramal").FirstOrDefault(t => t.Colaborador.Login == loginColaborador);
            }
        }

        public Mesa BuscarPorId(int id)
        {
            using (var db = new DataBaseContext())
            {
                return db.Mesa.Include("Colaborador").Include("Ramal").Include("MaquinaPessoal.Maquina.ModeloMaquina").FirstOrDefault(t => t.Id == id);
            }
        }

        public void Adicionar(Mesa entity)
        {
            using (var db = new DataBaseContext())
            {
                db.Mesa.Add(entity);
                db.SaveChanges();
            }
        }

        public void Atualizar(Mesa entity)
        {
            using (var db = new DataBaseContext())
            {
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public IList<Mesa> Buscar()
        {
            using (var db = new DataBaseContext())
            {
                return db.Mesa.ToList();
            }
        }

        public bool TemMaquinaComPatrimonio(int patrimonio)
        {
            using (var db = new DataBaseContext())
            {
                return db.Mesa.Include("MaquinaPessoal").FirstOrDefault(m => m.MaquinaPessoal.Patrimonio == patrimonio) != null;
            }
        }

        public bool TemMaquinaComEtiqueta(string etiqueta)
        {
            using (var db = new DataBaseContext())
            {
                return db.Mesa.Include("MaquinaPessoal").FirstOrDefault(m => m.MaquinaPessoal.EtiquetaServico.ToLower() == etiqueta.ToLower()) != null;
            }
        }

        public Mesa BuscarMesaPorNomeRamalPatrimonio(string palavra)
        {
            using (var db = new DataBaseContext())
            {
                return db.Mesa.Include(x => x.Colaborador).Include(x => x.Ramal).Include(x => x.MaquinaPessoal).Include(x => x.Andar).FirstOrDefault(m => m.Colaborador.Nome.ToLower() == palavra.ToLower() || m.Ramal.Numero.ToString() == palavra || m.MaquinaPessoal.Patrimonio.ToString() == palavra);
            }
        }
    }
}
