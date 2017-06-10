using System.Collections.Generic;

namespace Mica.Infrastructure.Helpers
{
    public interface IPagedList<out T> : IPagedList, IEnumerable<T>
    {
        ///<summary>
		/// Gets the element at the specified index.
		///</summary>
        T this[int index] { get; }

        ///<summary>
		/// Gets the number of elements contained on this page.
		///</summary>
        int Count { get; }
    }

    public interface IPagedList
    {
        /// <summary>
        /// Total number of objects contained within the superset.
        /// </summary>
        int TotalItemCount { get; }

        /// <summary>
        /// Total number of pages contained within the superset.
        /// </summary>
        int TotalPageCount { get; }

        /// <summary>
        /// One-based index of this subset within the superset.
        /// </summary>
        int PageNumber { get; }

        /// <summary>
        /// Maximum size any individual subset.
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// Returns true if this is NOT the first subset within the superset.
        /// </summary>
        bool HasPreviousPage { get; }

        /// <summary>
        /// Returns true if this is NOT the last subset within the superset.
        /// </summary>
        bool HasNextPage { get; }
    }
}
