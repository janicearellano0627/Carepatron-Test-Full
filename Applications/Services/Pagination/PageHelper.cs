using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Dynamic;

namespace Application.Services.Pagination
{
    public class PageHelper : IPageHelper
    {
        private readonly IUrlHelper _urlHelper;
        public PageHelper(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }

        public Page GetPage(IFilter filter, string actionName, int totalRows)
        {
            return GetPage(filter, actionName, totalRows, new { });
        }

        public Page GetPage(IFilter filter, string actionName, int totalRows, dynamic customParameters)
        {
            var nextUrl = string.Empty;

            var jsonQueryParameters = JsonConvert.SerializeObject(customParameters);
            var parameters = JsonConvert.DeserializeObject(jsonQueryParameters, typeof(ExpandoObject));

            var clonedFilter = filter.Clone() as BasicFilter;
            parameters.Limit = clonedFilter.Limit;

            if (totalRows > filter.Page * filter.Limit)
            {
                parameters.Page = clonedFilter.Page + 1;
                nextUrl = _urlHelper.Action(actionName, null, (object)parameters, _urlHelper.ActionContext.HttpContext.Request.Scheme);
            }

            parameters.Page = clonedFilter.Page - 1;
            var previousUrl = parameters.Page <= 0 ? null : _urlHelper.Action(actionName, null, (object)parameters, _urlHelper.ActionContext.HttpContext.Request.Scheme);

            return new Page
            {
                NextPage = !string.IsNullOrWhiteSpace(nextUrl) ? new Uri(nextUrl) : null,
                PreviousPage = !string.IsNullOrWhiteSpace(previousUrl) ? new Uri(previousUrl) : null
            };
        }
    }
}
