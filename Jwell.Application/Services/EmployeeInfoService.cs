using Jwell.Application.Services;
using Jwell.Application.Services.Dtos;
using Jwell.Framework.Application.Service;
using Jwell.Modules.Cache;
using Jwell.Repository.Repositories;
using Jwell.Application.Services.Constant;
using System;
using System.Collections.Generic;

namespace Jwell.Application
{
    public class EmployeeInfoService : ApplicationService, IEmployeeInfoService
    {
        private IEmployeeInfoRepository Repository { get; set; }
        private ICacheClient CacheClient { get; set; }

        public EmployeeInfoService(IEmployeeInfoRepository repository,ICacheClient cacheClient)
        {
            Repository = repository;
            CacheClient = cacheClient;
        }

        public void EmployeeInfoInit()
        {
            try
            {
                CacheClient.DB = ApplicationConstant.EMPLOYEECACHEDB;

                if (CacheClient.IsExist(ApplicationConstant.EMPLOYEEKEY))
                    CacheClient.RemoveCache(ApplicationConstant.EMPLOYEEKEY);

                IEnumerable<EmployeeInfoDto> employees = Repository.GetEmployeeInfos().ToDtos();

                System.Threading.Tasks.Task.Run(() =>
                {
                    //缓存24小时
                    CacheClient.SetCache(ApplicationConstant.EMPLOYEEKEY, employees, 3600 * 24);
                });
            }
            catch (Exception ex)
            {
                //TODO：写入日志
                throw ex;
            }
        }
    }
}
