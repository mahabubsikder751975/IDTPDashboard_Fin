using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDTPDashboard.DomainModel.Common
{
    public class PagedList<T> //:List<T>
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }

        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages-1;
        public IList<T> Items { get; set; }

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            if (pageNumber == 0) {
                CurrentPage = 1;
            }
            else
            {
                CurrentPage = pageNumber;
            }
            
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            Items = items;
            //AddRange(items);
        }

        public static PagedList<T> ToPagedList(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
