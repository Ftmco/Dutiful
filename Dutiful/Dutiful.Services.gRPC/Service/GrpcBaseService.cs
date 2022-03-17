using Dutiful.Services.gRPC.Rule;
using Grpc.Net.Client;
using IdentityProto;


namespace Dutiful.Services.gRPC.Service;

public class GrpcBaseService : IGrpcBaseRule
{
    public Task CreateChannelAsync(string address)
    {
        var channel = GrpcChannel.ForAddress(address);
        return Task.CompletedTask;
    }

    public ValueTask DisposeAsync()
    {
        throw new NotImplementedException();
    }
}
