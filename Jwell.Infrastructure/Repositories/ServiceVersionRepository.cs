using Jwell.Domain.Entities;
using Jwell.Modules.EntityFramework.Repositories;
using Jwell.Modules.EntityFramework.Uow;
using Jwell.Repository.Context;

namespace Jwell.Repository.Repositories
{
    public class ServiceVersionRepository : RepositoryBase<ServiceVersion, JwellDbContext, long>, IServiceVersionRepository
    {
        public ServiceVersionRepository(IDbContextResolver dbContextResolver) : base(dbContextResolver)
        {

        }
    }
}
