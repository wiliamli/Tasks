using Jwell.Framework.Application.Service;

namespace Jwell.Application.Services
{
    public interface IGateWayCacheSyncService : IApplicationService
    {
        void GatewayCacheInfoSync();

        void GatewayInvokeCacheInfoSync();
    }
}
