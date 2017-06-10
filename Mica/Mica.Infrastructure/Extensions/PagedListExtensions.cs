using Mica.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mica.Infrastructure.Extensions
{
    public static class PagedListExtensions
    {
        public static IPagedList<T> ToPagedList<T>(this IEnumerable<T> superset, int pageNumber, int pageSize)
        {
            return new PagedList<T>(superset, pageNumber, pageSize);
        }
    }
}
