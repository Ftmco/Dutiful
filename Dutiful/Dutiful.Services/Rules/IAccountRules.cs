using Dutiful.ViewModels.User;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dutiful.Services.Rules;

public interface IAccountRules : IAsyncDisposable
{
    Task<UserViewModel?> GetUserAsync(HttpContext httpContext);
}
