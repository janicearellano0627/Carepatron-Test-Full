using System.Collections.Generic;

namespace Application.Services.Pagination
{
    public class FilterResponse<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int TotalRows { get; set; }
    }
}
