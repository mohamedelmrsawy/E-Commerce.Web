using DomianLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomianLayer.Contracts
{
    public interface IGenericRepository<T , TKey> where T : BaseEntity<TKey>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetbyIdAsync(TKey id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);

        #region Specifications
        Task<IEnumerable<T>> GetAllAsync(ISpecifications<T, TKey> specifications);
        Task<T?> GetbyIdAsync(ISpecifications<T, TKey> specifications);
        Task<int> CountAsync(ISpecifications<T, TKey> Specifications);
        #endregion
    }
}
