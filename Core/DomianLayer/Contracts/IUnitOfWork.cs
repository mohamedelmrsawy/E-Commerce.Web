using DomianLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomianLayer.Contracts
{
    public interface IUnitOfWork
    {
        IGenericRepository<T, TKey> GetRepository<T, TKey>() where T : BaseEntity<TKey>;
        Task<int> SaveChangesAsync();
    }
}
