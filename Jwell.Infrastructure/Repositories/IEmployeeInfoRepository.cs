using Jwell.Domain.Entities;
using Jwell.Framework.Domain.Repositories;
using System.Collections.Generic;

namespace Jwell.Repository.Repositories
{
    public interface IEmployeeInfoRepository: IRepository<EmployeeInfo, long>
    {
        /// <summary>
        /// 获取员工信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<EmployeeInfo> GetEmployeeInfos();
    }
}
