using Mica.Infrastructure.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Mica.Infrastructure.Helpers
{
    public class PagedList<T> : IPagedList<T>
    {
        /// <summary>
        /// 	The subset of items contained only within this one page of the superset.
        /// </summary>
        protected readonly List<T> Subset = new List<T>();

        public int TotalItemCount { get; protected set; }
        public int TotalPageCount { get; protected set; }
        public int PageNumber { get; protected set; }
        public int PageSize { get; protected set; }
        public bool HasPreviousPage { get; protected set; }
        public bool HasNextPage { get; protected set; }

        public PagedList(IQueryable<T> superset, int pageNumber, int pageSize)
        {
            pageNumber = pageNumber.NoLessThan(1);
            pageSize = pageSize.NoLessThan(1);

            PageSize = pageSize;
            PageNumber = (pageNumber == int.MaxValue) ? TotalPageCount : pageNumber;

            // set source to blank list if superset is null to prevent exceptions
            TotalItemCount = superset == null ? 0 : superset.Count();
            TotalPageCount = TotalItemCount > 0
                        ? (int)Math.Ceiling(TotalItemCount / (double)PageSize)
                        : 0;

            HasPreviousPage = PageNumber > 1;
            HasNextPage = PageNumber < TotalPageCount;

            // add items to internal list
            if (superset != null && TotalItemCount > 0)
                Subset.AddRange(pageNumber == 1
                    ? superset.Take(pageSize).ToList()
                    : superset.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList()
                );
        }

        public PagedList(IEnumerable<T> superset, int pageNumber, int pageSize)
           : this(superset.AsQueryable(), pageNumber, pageSize)
        {
        }

        public PagedList(IList<T> superset, int pageNumber, int pageSize)
           : this(superset.AsQueryable(), pageNumber, pageSize)
        {
        }

        #region IPagedList<T> Members
        public IEnumerator<T> GetEnumerator()
        {
            return Subset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T this[int index]
        {
            get { return Subset[index]; }
        }

        public virtual int Count
        {
            get { return Subset.Count; }
        }
        #endregion

        public static PagedList<T> Empty()
        {
            return new PagedList<T>((IQueryable<T>) null, 1, 1);
        }
    }
}
