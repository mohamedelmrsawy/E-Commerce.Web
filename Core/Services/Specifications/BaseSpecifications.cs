using DomianLayer.Contracts;
using DomianLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    abstract class BaseSpecifications<T, TKey> : ISpecifications<T, TKey> where T : BaseEntity<TKey>
    {
        protected BaseSpecifications(Expression<Func<T, bool>>? CriteriaExpression)
        {
            Criteria = CriteriaExpression;
        }

        public Expression<Func<T, bool>>? Criteria {  get; private set; }

        #region Include
        public List<Expression<Func<T, object>>> IncludeExpressions { get; } = [];
        protected void AddInclude(Expression<Func<T, object>> includeExpression) => IncludeExpressions.Add(includeExpression); 
        #endregion

        #region Order
        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression) => OrderBy = orderByExpression;

        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescending) => OrderByDescending = orderByDescending;

        #endregion


    }
}

