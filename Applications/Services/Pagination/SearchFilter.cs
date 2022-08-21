using System;

namespace Application.Services.Pagination
{
    public class SearchFilter : BasicFilter
    {
        //<summary>
        // The query string used to filter the response, usually by name.
        //</summary>
        public string SearchQuery { get; set; }
    }
}
