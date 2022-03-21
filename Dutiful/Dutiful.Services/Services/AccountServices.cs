using Dutiful.ViewModels.Api;
using Dutiful.ViewModels.MicroService;
using Dutiful.ViewModels.User;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Json;
using Tools.Crypto;

namespace Dutiful.Services.Services;

public class AccountServices : IAccountRules
{
    readonly IApiCall _api;

    readonly IConfiguration _configuration;

    public AccountServices(IConfiguration configuration, IApiCall api)
    {
        _configuration = configuration;
        _api = api;
    }

    public ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);
        return ValueTask.CompletedTask;
    }

    public async Task<UserViewModel?> GetUserAsync(HttpContext httpContext)
    {
        await _api.SetBaseUrlAsync(_configuration["MicroService:Identity:Urls:BaseUrl"]);
        string? token = httpContext.Request.Headers["I-Authentication"].ToString();
        if (!string.IsNullOrEmpty(token))
        {
            var application = await GetIdentityApplicationAsync();
            var requestModel = new
            {
                application = new
                {
                    application.ApiKey,
                    application.Password
                },
                token
            };
            string? url = _configuration["MicroService:Identity:Urls:GetUserByToken"];
            ApiModel? request = await _api.PostEncAsync<ApiModel>(url, requestModel);
            if (request?.Status ?? false)
            {
                JObject result = (JObject)request.Result; 
                UserViewModel? user = JsonConvert.DeserializeObject<UserViewModel>(result["User"].ToString());
                return user;
            }
            return default;
        }
        return default;
    }

    Task<Application> GetIdentityApplicationAsync()
    {
        string? apiKey = _configuration["MicroService:Identity:Application:ApiKey"];
        string? password = _configuration["MicroService:Identity:Application:Password"];
        return Task.FromResult(new Application(apiKey, password));
    }
}
