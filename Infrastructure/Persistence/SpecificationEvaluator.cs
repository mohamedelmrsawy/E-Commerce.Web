using DomianLayer.Contracts;
using DomianLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    static class SpecificationEvaluator
    {
        public static IQueryable<T> CreateQuery<T, TKey>(IQueryable<T> InputQuery, ISpecifications<T, TKey> specifications) where T : BaseEntity<TKey>
        {
            var Query = InputQuery;
            if (specifications.Criteria is not null)
            {
                Query = Query.Where(specifications.Criteria);
            }

            if (specifications.OrderBy is not null)
            {
                    Query = Query.OrderBy(specifications.OrderBy);
            } 

            if(specifications.OrderByDescending is not null)
            {
                Query = Query.OrderByDescending(specifications.OrderByDescending);
            }


            if(specifications.IncludeExpressions is not null && specifications.IncludeExpressions.Count > 0)
            {
                //foreach (var expression in specifications.IncludeExpressions)
                //    Query = Query.Include(expression);

                Query = specifications.IncludeExpressions.Aggregate(Query, (CurrentQuery, IncludeExp) => CurrentQuery.Include(IncludeExp));
            }
            return Query;
        }
    }
}
