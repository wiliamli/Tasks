using Jwell.Domain.Entities;
using Jwell.Repository.Context;
using Jwell.Modules.EntityFramework.Repositories;
using Jwell.Modules.EntityFramework.Uow;
using Jwell.Framework.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Jwell.Repository.Repositories
{
    public class ServiceRepository : RepositoryBase<Service, JwellDbContext, long>, IServiceRepository
    {
        public ServiceRepository(IDbContextResolver dbContextResolver) : base(dbContextResolver)
        {
        }      
    }
}
