using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jwell.Application.Services.Constant;
using Jwell.Application.Services.Dtos;
using Jwell.Framework.Application.Service;
using Jwell.Modules.Cache;
using Jwell.Repository.Repositories;

namespace Jwell.Application.Services
{
    public class PropellingMovementService : ApplicationService, IPropellingMovementService
    {
        private IPropellingMovementInterfaceRepository PropellingMovementInterfaceRepository { get; set; }

        private IPropellingMovementManagerRepository PropellingMovementManagerRepository { get; set; }

        private ICacheClient CacheClient { get; set; }

        public PropellingMovementService(IPropellingMovementInterfaceRepository propellingMovementInterfaceRepository,
            IPropellingMovementManagerRepository propellingMovementManagerRepository,
            ICacheClient cacheClient)
            {
            this.PropellingMovementInterfaceRepository = propellingMovementInterfaceRepository;
            this.PropellingMovementManagerRepository = propellingMovementManagerRepository;
            this.CacheClient = cacheClient;
        }

        public IEnumerable<PropellingMovementDto> GetPropellingMovementDtos()
        {

            CacheClient.DB = ApplicationConstant.PROEMOVEINFODB;

            if (CacheClient.IsExist(ApplicationConstant.PROEMOVEINFO))
                CacheClient.RemoveCache(ApplicationConstant.PROEMOVEINFO);

            IEnumerable<PropellingMovementDto> query = (from a in PropellingMovementManagerRepository.Queryable()
                         join b in PropellingMovementInterfaceRepository.Queryable() on a.PropeMoveID equals b.PropeMoveID into temp
                         from t in temp.DefaultIfEmpty()
                         select new PropellingMovementDto()
                         {
                             ServiceSign = a.ServiceSign,
                             Environment = t != null ? t.Environment : "",
                             Channel = t != null ? t.Channel : "",
                             InterfaceUrl = t != null ? t.InterfaceUrl : "",
                             ServiceNumber = a.ServiceNumber
                         }).ToList();

            Task.Run(() =>
            {
                //缓存24小时
                CacheClient.SetCache(ApplicationConstant.PROEMOVEINFO, query, 3600 * 24);
            });
            return query;

        }
    }
}
