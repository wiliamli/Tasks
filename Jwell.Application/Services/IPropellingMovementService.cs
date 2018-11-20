using Jwell.Application.Services.Dtos;
using Jwell.Framework.Application.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwell.Application.Services
{
    public interface IPropellingMovementService : IApplicationService
    {
        /// <summary>
        /// 根据服务编号获取相关主推信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<PropellingMovementDto> GetPropellingMovementDtos();

    }
}
