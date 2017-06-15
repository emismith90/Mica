using System;
using System.Linq;
using System.Linq.Expressions;
using Mica.Infrastructure.Models.Abstract;

namespace Mica.Infrastructure.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<TSource> Find<TSource>(this IQueryable<TSource> query, string term)
            where TSource : ISearchableEntity
        {
            if (string.IsNullOrWhiteSpace(term))
            {
                return query;
            }

            return query.Where(e => e.ToSearchableString().ToLower().Contains(term.ToLower()));
        }

        public static IQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> query, string key, string direction)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return query;
            }

            var lambda = (dynamic)CreateExpression(typeof(TSource), key);

            var descending = direction.ToLower() == "desc";
            return descending
                ? Queryable.OrderByDescending(query, lambda)
                : Queryable.OrderBy(query, lambda);
        }

        private static LambdaExpression CreateExpression(Type type, string propertyName)
        {
            var param = Expression.Parameter(type, "x");

            Expression body = param;
            foreach (var member in propertyName.Split('.'))
            {
                body = Expression.PropertyOrField(body, member);
            }

            return Expression.Lambda(body, param);
        }
    }
}
