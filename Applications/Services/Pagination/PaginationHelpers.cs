using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Pagination
{
    public class PaginationHelpers
    {
        public static PagedResponse<T> CreatePaginatedResponse<T>(IPageHelper pageHelper, string actionName, IFilter filter,FilterResponse<T> response)
        {
            return CreatePaginatedResponse(pageHelper, actionName, filter, response, new { });
        }

        public static PagedResponse<T> CreatePaginatedResponse<T>(IPageHelper pageHelper, string actionName, IFilter filter, FilterResponse<T> response, dynamic customParameters)
        { 
            var page = pageHelper.GetPage(filter, actionName, response.TotalRows, customParameters);

            return new PagedResponse<T>
            { 
             Data = response.Data,
             TotalRows = response.TotalRows,
              NextPage = page.NextPage,
              PreviousPage = page.PreviousPage,
              TotalPages = (int)Math.Ceiling(response.TotalRows / (double) filter.Limit)
            
            };
        }
    }
}
