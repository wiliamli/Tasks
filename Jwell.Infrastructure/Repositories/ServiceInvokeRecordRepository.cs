using Jwell.Domain.Entities;
using Jwell.Modules.EntityFramework.Repositories;
using Jwell.Modules.EntityFramework.Uow;
using Jwell.Repository.Context;

namespace Jwell.Repository.Repositories
{
    public class ServiceInvokeRecordRepository : RepositoryBase<ServiceInvokeRecord, JwellDbContext, long>, IServiceInvokeRecordRepository
    {
        public ServiceInvokeRecordRepository(IDbContextResolver dbContextResolver) : base(dbContextResolver)
        {
        }
    }
}
