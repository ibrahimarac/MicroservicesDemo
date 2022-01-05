using System.Collections.Generic;

namespace ContactReport.Application.Parameters
{
    public class PagedRequest<T> where T : class
    {
        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public int TotalItems { get; set; }

        public string OrderByColumn { get; set; }

        public bool OrderByAsc { get; set; }

        public IEnumerable<T> Data { get; set; }
    }

}
