using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Comum
{
    public interface IQuery<TEntity> where TEntity : EntidadeBase
    {
        IQueryable<TEntity> CriarQuery(IQueryable<TEntity> src);
    }
}
