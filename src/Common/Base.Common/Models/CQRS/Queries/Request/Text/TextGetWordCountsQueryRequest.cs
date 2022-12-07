using Base.Common.Models.CQRS.Queries.Response;
using Base.Common.Models.Pagination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Common.Models.CQRS.Queries.Request.Text;

public class TextGetWordCountsQueryRequest : PaginationRequest, IRequest<PaginationResponse<TextGetWordCountsQueryResponse>>
{
    public TextGetWordCountsQueryRequest()
    {

    }

    public TextGetWordCountsQueryRequest(int currentPage, int pageSize) : base(currentPage, pageSize)
    {
    }

    public string Url { get; set; }
}
