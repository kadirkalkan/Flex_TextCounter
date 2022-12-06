using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Common.Models.Pagination;

public class PaginationResponse<T> where T : class
{
    public PaginationResponse() : this(new List<T>(), new Page())
    {
    }

    public PaginationResponse(IList<T> results, Page pageInfo)
    {
        Results = results;
        PageInfo = pageInfo;
    }

    public IList<T> Results { get; set; }
    public Page PageInfo { get; set; }
}