using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwell.Application.Services.Dtos
{
    public class GatewayCacheInfoDto
    {
        public string SVID { get; set; }

        public string ServiceSign { get; set; }

        public string VersionNumber { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public string Domain { get; set; }

        public string HttpOption { get; set; }

        public string ParamInfo { get; set; }

        public string ServiceNumber { get; set; }
    }
}
