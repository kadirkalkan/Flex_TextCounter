using Base.Api.Application.Interfaces;
using Base.Common.Infrastructure.Exceptions;
using Base.Common.Models.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Base.Api.Application.Services;

public class HttpService : IHttpService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HttpService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<string> SendGetAsync(string url)
    {
        var client = _httpClientFactory.CreateClient(HttpConstants.TextApiClientName);

        // Port -1 is the default port for the scheme.
        var uriBuilder = new UriBuilder(url) { Scheme = Uri.UriSchemeHttps, Port = -1 };

        var uri = uriBuilder.Uri;

        var response = await client.GetAsync(uri);

        if (!response.IsSuccessStatusCode)
            throw new CustomException(ExceptionConstants.DataCouldNotFetchFromUrl);
        

        return await response.Content.ReadAsStringAsync();
    }
}
