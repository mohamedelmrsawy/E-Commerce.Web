using DomianLayer.Contracts;
using DomianLayer.Models;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class UnitOfWork(StorDbContext _dbContext) : IUnitOfWork
    {
        private readonly Dictionary<string, object> _repositories = [];

        public IGenericRepository<T, TKey> GetRepository<T, TKey>() where T : BaseEntity<TKey>
        {
            var typeName = typeof(T).Name;
            if (_repositories.ContainsKey(typeName))
                return (IGenericRepository<T, TKey>) _repositories[typeName];
            else
            {
                var repo = new GenericRepository<T,TKey>(_dbContext);
                _repositories["typeName"] = repo;
                return repo;
            }
        }



        public async Task<int> SaveChangesAsync() =>await _dbContext.SaveChangesAsync();
        
    }
}
