using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace IncudeMap
{
    public static class Extensions
    {
        public static IMap<TEntity, TProperty> Include<TEntity, TProperty>(
            this IMap<TEntity> source,
            Expression<Func<TEntity, TProperty>> navigationPropertyPath)
           where TEntity : class
        {
            return source.Create<TEntity, TProperty>(navigationPropertyPath.Body, false);
        }
        public static IMap<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>(
             this IMap<TEntity, TPreviousProperty> source,
             Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath)
            where TEntity : class
        {
            return source.Create<TEntity, TProperty>(navigationPropertyPath.Body);
        }
        public static IMap<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>(
             this IMap<TEntity, IEnumerable<TPreviousProperty>> source,
             Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath) where TEntity : class
        {
            return source.Create<TEntity, TProperty>(navigationPropertyPath.Body);
        }
        public static IMap<T, P> Create<T, P>(this IMap<T> source, Expression expression, bool Trail = true)
        {
            var res = new Map<T, P>()
            {
                propMap = source.propMap
            };
            if (expression is MemberExpression memExp)
            {
                if (Trail)
                    res.propMap.Push($"{res.propMap.Peek()}.{memExp.Member.Name}");
                else
                    res.propMap.Push(memExp.Member.Name);
            }
            return res;
        }
    }
}
