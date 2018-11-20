using Jwell.Domain;
using Jwell.Domain.Entities;
using Jwell.Repository.Context;
using Jwell.Modules.EntityFramework.Repositories;
using Jwell.Modules.EntityFramework.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwell.Repository.Repositories
{
    public class EmployeeInfoRepository : RepositoryBase<EmployeeInfo, JwellKpiDbContext, long>, IEmployeeInfoRepository
    {
        public EmployeeInfoRepository(IDbContextResolver dbContextResolver) : base(dbContextResolver)
        {
        }
       
        public IEnumerable<EmployeeInfo> GetEmployeeInfos()
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(" SELECT ");
            sql.Append(" \"a\".USER_CODE AS \"EmployeeID\", ");
            sql.Append(" \"a\".USER_NAME AS \"UserName\", ");
            sql.Append(" \"a\".\"PASSWORD\" AS \"Password\", ");
            sql.Append(" \"b\".NAME AS \"Department\", ");
            sql.Append(" \"b\".CODE AS \"DepartmentCode\", ");
            sql.Append(" \"a\".\"ID\" ");
            sql.Append(" FROM ");
            sql.Append(" \"JWWLKPILOCAL\".\"AUTH_USER\" \"a\" ");
            sql.Append(" LEFT JOIN ");
            sql.Append(" \"JWWLKPILOCAL\".\"AUTH_ORGANIZATION\" \"b\" ");
            sql.Append(" ON \"a\".ORG_ID = \"b\".\"ID\" ");

            return base.SqlQuery<EmployeeInfo>(sql.ToString()).ToList();
        }
    }
}
