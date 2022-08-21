using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Pagination
{
    public interface IPageHelper
    {
        Page GetPage(IFilter filter, string actionName, int totalRows);
        Page GetPage(IFilter filter, string actionName, int totalRows, dynamic customParameters);
    }
}
