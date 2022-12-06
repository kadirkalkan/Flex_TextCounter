using Base.Common.Models.CQRS.Queries.Request.Text;
using Base.Common.Models.CQRS.Queries.Response;
using Base.Common.Models.Pagination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Api.Application.Features.CQRS.Handlers.Queries;

public class TextGetWordCountsQueryHandler : IRequestHandler<TextGetWordCountsQueryRequest, PaginationResponse<TextGetWordCountsQueryResponse>>
{
    public Task<PaginationResponse<TextGetWordCountsQueryResponse>> Handle(TextGetWordCountsQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    #region Result Method
    public static PaginationResponse<TextGetWordCountsQueryResponse> SetResult(IList<TextGetWordCountsQueryResponse> results, int currentPage, int pageSize, int totalRowCount)
    {
        var page = new Page(currentPage, pageSize, totalRowCount);
        var response = new PaginationResponse<TextGetWordCountsQueryResponse>(results, page);

        return response;
    }
    #endregion
}
