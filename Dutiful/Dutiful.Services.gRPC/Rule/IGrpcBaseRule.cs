using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dutiful.Services.gRPC.Rule;

public interface IGrpcBaseRule : IAsyncDisposable
{
    Task CreateChannelAsync(string address);
}
