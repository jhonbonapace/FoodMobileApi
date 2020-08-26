using System;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Repository
{
    public static class Extensions
    {
        public static (int, IEnumerable<T>) GetPaged<T>(this IQueryable<T> query, int page, int pageSize) where T : class
        {
            var pageCount = (double)query.Count() / pageSize;

            var skip = (page - 1) * pageSize;
            IEnumerable<T> result = query.Skip(skip).Take(pageSize).ToList();

            return ((int)Math.Ceiling(pageCount), result);
        }
    }
}