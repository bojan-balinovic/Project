using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Service.Models
{
    public class PaginationList<T>
    {
        public IEnumerable<T> _items;
        public int CurrentPage { get; set; }
        public static int PageSize { get; set; }

        public PaginationList(IEnumerable<T> items, int currentPage, int pageSize=5)
        {
            Items = items;
            CurrentPage = currentPage;
            PageSize = pageSize;
        }

        public IEnumerable<T> Items
        {
            get
            {
                return _items.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
            } set
            {
                _items = value;
            }
        }

        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling(decimal.Divide(_items.Count(), PageSize));
            }
        }
    }
}
