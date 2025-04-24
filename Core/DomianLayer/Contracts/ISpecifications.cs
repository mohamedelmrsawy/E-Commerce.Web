using DomianLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DomianLayer.Contracts
{
    public interface ISpecifications<T,TKey> where T : BaseEntity<TKey>
    {
        public Expression<Func<T, bool>>? Criteria { get; }
        List<Expression<Func<T,object>>> IncludeExpressions { get; }

        Expression<Func<T,object>> OrderBy {  get; }
        Expression<Func<T,object>> OrderByDescending {  get; }

    }
}
