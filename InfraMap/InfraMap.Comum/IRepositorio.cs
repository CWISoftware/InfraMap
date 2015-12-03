using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Comum
{
    public interface IRepositorio<TEntity> where TEntity : EntidadeBase
    {
        void Adicionar(TEntity entity);

        void Atualizar(TEntity entity);

        void Deletar(TEntity entity);

        TEntity BuscarPorId(int id);

        IList<TEntity> Buscar(params IQuery<TEntity>[] queries);
    }
}
