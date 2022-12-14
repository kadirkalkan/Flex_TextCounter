using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Common.Models.Pagination;

public class PaginationRequest
{
    public PaginationRequest()
    {
    }

    public PaginationRequest(int currentPage, int pageSize)
    {
        CurrentPage = currentPage;
        PageSize = pageSize;
    }

    public int CurrentPage { get; set; } = 1;
    public int PageSize { get; set; } = 1;

    [BindNever]
    public int Skip => (CurrentPage - 1) * PageSize;
}