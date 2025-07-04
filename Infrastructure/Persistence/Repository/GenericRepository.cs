﻿using DomianLayer.Contracts;
using DomianLayer.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class GenericRepository<T, TKey>(StorDbContext _dbContext) : IGenericRepository<T, TKey> where T : BaseEntity<TKey>
    {
        public async Task AddAsync(T entity) => await _dbContext.Set<T>().AddAsync(entity);
    
        public async Task<IEnumerable<T>> GetAllAsync() => await _dbContext.Set<T>().ToListAsync();

        public async Task<T?> GetbyIdAsync(TKey id) => await _dbContext.Set<T>().FindAsync(id);
        public void Remove(T entity) => _dbContext.Set<T>().Remove(entity);

        public void Update(T entity) => _dbContext.Set<T>().Update(entity);

        #region Specifications
        public async Task<IEnumerable<T>> GetAllAsync(ISpecifications<T, TKey> specifications)
        {
            return await SpecificationEvaluator.CreateQuery(_dbContext.Set<T>(), specifications).ToListAsync();
        }


        public async Task<T?> GetbyIdAsync(ISpecifications<T, TKey> specifications)
        {
            return await SpecificationEvaluator.CreateQuery(_dbContext.Set<T>(), specifications).FirstOrDefaultAsync();
        }

        public async Task<int> CountAsync(ISpecifications<T, TKey> Specifications)
        {
            return await SpecificationEvaluator.CreateQuery(_dbContext.Set<T>() , Specifications).CountAsync();
        }
        #endregion


    }
}
