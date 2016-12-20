using System.Collections.Generic;
using System.Linq;

namespace Blog_Solution.Web.Framework.Kendoui
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Filter<T>(this IQueryable<T> queryable, Filter filter)
        {
            if (filter != null && filter.Logic != null)
            {
                var filters = filter.All();
                
                var values = filters.Select(f => f.Value).ToArray();
                
                string predicate = filter.ToExpression(filters);
                
                queryable = queryable.Where(predicate, values);
            }

            return queryable;
        }

        public static IQueryable<T> Sort<T>(this IQueryable<T> queryable, IEnumerable<Sort> sort)
        {
            if (sort != null && sort.Any())
            {
                var ordering = string.Join(",", sort.Select(s => s.ToExpression()));
                
                return queryable.OrderBy(ordering);
            }

            return queryable;
        }
    }
}
