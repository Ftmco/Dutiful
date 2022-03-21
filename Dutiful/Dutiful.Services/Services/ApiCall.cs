using Dutiful.ViewModels.Api;
using Newtonsoft.Json;
using System.Net.Http.Json;
using Tools.Crypto;

namespace Dutiful.Services.Services;

public class ApiCall : IApiCall
{
    readonly HttpClient _httpClient;

    public ApiCall(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);
        return ValueTask.CompletedTask;
    }

    public async Task<TResponse?> PostAsync<TResponse>(string url, object data)
    {
        HttpResponseMessage? request = await _httpClient.PostAsJsonAsync(url, data);
        if (request.IsSuccessStatusCode)
        {
            TResponse? response = await request.Content.ReadFromJsonAsync<TResponse>();
            return response;
        }
        return default;
    }

    public async Task<TResponse?> PostEncAsync<TResponse>(string url, object data)
    {
        var key = url.KeyMaker();
        string? encData = JsonConvert.SerializeObject(data).Encrypt(key);
        ApiRequest? request = await PostAsync<ApiRequest>(url, new { Data = encData });
        TResponse? response = JsonConvert.DeserializeObject<TResponse>(request?.Data.Decrypt(key) ?? "");
        return response;
    }

    public Task SetBaseUrlAsync(string baseUrl)
    {
        _httpClient.BaseAddress = new Uri(baseUrl);
        return Task.CompletedTask;
    }
}
