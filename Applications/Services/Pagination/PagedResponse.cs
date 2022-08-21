using System;

namespace Application.Services.Pagination
{
    public class PagedResponse<T>
    {
        public PagedResponse()
        { }

        public IEnumerable<T> Data { get; set; }
        public Uri NextPage { get; set; }
        public Uri PreviousPage { get; set; }
        public int TotalRows { get; set; }
        public int TotalPages { get; set; }

        public PagedResponse(IEnumerable<T> data)
        {
            Data = data;
        }
    }
}
