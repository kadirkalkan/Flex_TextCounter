using Base.Api.Application.Interfaces;
using Base.Common.Models.CQRS.Queries.Request.Text;
using Base.Common.Models.CQRS.Queries.Response;
using Base.Common.Models.Pagination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Base.Api.Application.Features.CQRS.Handlers.Queries;

public class TextGetWordCountsQueryHandler : IRequestHandler<TextGetWordCountsQueryRequest, PaginationResponse<TextGetWordCountsQueryResponse>>
{
    private readonly IHttpService _httpService;

    public TextGetWordCountsQueryHandler(IHttpService httpService)
    {
        _httpService = httpService;
    }

    public async Task<PaginationResponse<TextGetWordCountsQueryResponse>> Handle(TextGetWordCountsQueryRequest request, CancellationToken cancellationToken)
    {
        var content = await _httpService.SendGetAsync(request.Url);

        var regex = new Regex("[^a-zA-Z0-9]");
        var plainText = regex.Replace(content, " ");
                

        var listOfWords = plainText.Split(" ").ToList();
        listOfWords.RemoveAll(word => string.IsNullOrEmpty(word));

        var response = listOfWords.GroupBy(x => x)
                                .Select(x => new TextGetWordCountsQueryResponse()
                                             {
                                                 Word = x.Key,
                                                 Count = x.Count()
                                             })
                                .OrderByDescending(x=> x.Count)
                                .ToList();

        int totalCount = response.Count;

        response = response.Skip(request.Skip)
                           .Take(request.PageSize)
                           .ToList();

        return SetResult(response, request.CurrentPage, request.PageSize, totalCount);
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
