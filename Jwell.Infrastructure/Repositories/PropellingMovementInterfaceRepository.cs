using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jwell.Domain.Entities;
using Jwell.Modules.EntityFramework.Repositories;
using Jwell.Modules.EntityFramework.Uow;
using Jwell.Repository.Context;

namespace Jwell.Repository.Repositories
{
    public class PropellingMovementInterfaceRepository : RepositoryBase<PropellingMovementInterface, JwellSignalRDbContext, long>, IPropellingMovementInterfaceRepository
    {
        public PropellingMovementInterfaceRepository(IDbContextResolver dbContextResolver) : base(dbContextResolver)
        {
        }
    }
}
