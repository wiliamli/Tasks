using Jwell.Application.Services;
using Jwell.Framework.Mvc;
using System.Web.Http;

namespace Jwell.ScheduleTask.Controllers
{
    /// <summary>
    /// 任务调度控制器
    /// </summary>
    public class TasksController : BaseApiController
    {
        private readonly IEmployeeInfoService _employeeInfoService;

        private readonly ITeamInfoService _teamInfoService;

        private readonly IGateWayCacheSyncService _gateWayCacheSyncService;

        private readonly IPropellingMovementService _propellingMovementService;
        /// <summary>
        /// 任务调度控制器构造函数
        /// </summary>
        /// <param name="employeeInfoService"></param>
        /// <param name="teamInfoService"></param>
        /// <param name="gateWayCacheSyncService"></param>
        /// <param name="propellingMovementService"></param>
        public TasksController(IEmployeeInfoService employeeInfoService,ITeamInfoService teamInfoService, 
            IGateWayCacheSyncService gateWayCacheSyncService,
            IPropellingMovementService propellingMovementService)
        {
            _employeeInfoService = employeeInfoService;
            _teamInfoService = teamInfoService;
            _gateWayCacheSyncService = gateWayCacheSyncService;
            _propellingMovementService = propellingMovementService;
        }

        /// <summary>
        /// 初始化员工信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public void EmployeeInit()
        {
            _employeeInfoService.EmployeeInfoInit();
        }


        /// <summary>
        /// 初始化组织结构信息
        /// </summary>
        [HttpGet]
        public void TeamInfoInit()
        {
            _teamInfoService.TeamInfoServiceInit();
        }

        /// <summary>
        /// 初始化网关缓存
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public void GatewayCacheInfoSync()
        {
            _gateWayCacheSyncService.GatewayCacheInfoSync();
        }

        /// <summary>
        /// 初始化服务API调用记录缓存
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public void GatewayInvokeCacheInfoSync()
        {
             _gateWayCacheSyncService.GatewayInvokeCacheInfoSync();
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public void PropeMoveInfoInit()
        {
            _propellingMovementService.GetPropellingMovementDtos();
        }
    }
}