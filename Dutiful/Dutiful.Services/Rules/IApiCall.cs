using Dutiful.ViewModels.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dutiful.Services.Rules;

public interface IApiCall : IAsyncDisposable
{
    Task<TResponse?> PostAsync<TResponse>(string url, object data);

    Task<TResponse?> PostEncAsync<TResponse>(string url, object data);

    Task SetBaseUrlAsync(string baseUrl);
}
