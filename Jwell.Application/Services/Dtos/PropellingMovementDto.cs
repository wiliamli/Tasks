﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwell.Application.Services.Dtos
{
    public class PropellingMovementDto
    {
        /// <summary>
        /// 主推编号
        /// </summary>
        public string ServiceNumber { get; set; }

        /// <summary>
        /// 主推标识
        /// </summary>
        public string ServiceSign { get; set; }

        /// <summary>
        ///  频道
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        /// 主推接口信息
        /// </summary>
        public string InterfaceUrl { get; set; }

        /// <summary>
        /// 环境
        /// </summary>
        public string Environment { get; set; }
    }
}
