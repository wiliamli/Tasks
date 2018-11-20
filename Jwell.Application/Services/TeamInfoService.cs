using Jwell.Application.Services.Constant;
using Jwell.Application.Services.Dtos;
using Jwell.Framework.Application.Service;
using Jwell.Modules.Cache;
using Jwell.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jwell.Application.Services
{
    public class TeamInfoService : ApplicationService, ITeamInfoService
    {
        private readonly ICacheClient _cacheClientTeamInfo;

        //private readonly ICacheClient _cacheClientEmployeeInfo;

        private readonly IServiceRepository _serviceRepository;

        private readonly IEmployeeInfoRepository _employeeInfoRepository;

        //private List<EmployeeInfoDto> _employeeInfoDtos;
     

        public TeamInfoService(IServiceRepository serviceRepository,
            IEmployeeInfoRepository employeeInfoRepository,
            ICacheClient cacheClientTeamInfo)
            //ICacheClient cacheClientEmployeeInfo)
        {
            _serviceRepository = serviceRepository;
            _employeeInfoRepository = employeeInfoRepository;
            _cacheClientTeamInfo = cacheClientTeamInfo;
            //_cacheClientEmployeeInfo = cacheClientTeamInfo;
            //_employeeInfoDtos = GetEmployeeInfo();
        }

        //private List<EmployeeInfoDto> GetEmployeeInfo()
        //{
        //    _cacheClientEmployeeInfo.DB = ApplicationConstant.EMPLOYEECACHEDB;
        //    if (_cacheClientEmployeeInfo.IsExist(ApplicationConstant.EMPLOYEEKEY))
        //    {
        //        return _cacheClientEmployeeInfo.GetCache<List<EmployeeInfoDto>>(ApplicationConstant.EMPLOYEEKEY);
        //    }
        //    return new List<EmployeeInfoDto>();
        //}


        private EmployeeInfoDto GetEmployeeInfoDto(string employeeId)
        {
            //foreach (var employeeInfoDto in _employeeInfoDtos)
            //{
            //    if (employeeInfoDto.EmployeeID == employeeId)
            //        return employeeInfoDto;
            //}

            foreach (var employeeInfoDto in _employeeInfoRepository.GetEmployeeInfos().ToDtos())
            {
                if (employeeInfoDto.EmployeeID == employeeId)
                    return employeeInfoDto;
            }

            return null;
        }

        public void TeamInfoServiceInit()
        {
            try
            {
                _cacheClientTeamInfo.DB = ApplicationConstant.TEAMINFOCACHEDB;               
                if (_cacheClientTeamInfo.IsExist(ApplicationConstant.TEAMINFOKEY))
                    _cacheClientTeamInfo.RemoveCache(ApplicationConstant.TEAMINFOKEY);

                var teamInfoDtos = _serviceRepository.Queryable().ToDtos();
                //Task.Run(() =>
                //{
                    foreach (var teamInfoDto in teamInfoDtos)
                    {
                        var employeeInfoDto = GetEmployeeInfoDto(teamInfoDto.LeaderId);

                        if (employeeInfoDto != null)
                        {
                            teamInfoDto.LeaderName = employeeInfoDto.UserName;
                        }

                        foreach (var serviceInfoDto in teamInfoDto.ServiceInfoes)
                        {
                            var ownerInfoDto = GetEmployeeInfoDto(serviceInfoDto.OwnerId);
                            var creatorInfoDto = GetEmployeeInfoDto(serviceInfoDto.CreatedBy);
                            var modifiedInfoDto = GetEmployeeInfoDto(serviceInfoDto.ModifiedBy);
                            if (ownerInfoDto != null)
                            {
                                serviceInfoDto.OwnerName = ownerInfoDto.UserName;
                            }
                        }
                    }
                    _cacheClientTeamInfo.SetCache(ApplicationConstant.TEAMINFOKEY, teamInfoDtos, 3600 * 24);
                //});
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
