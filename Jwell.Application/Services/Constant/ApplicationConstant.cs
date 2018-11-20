using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwell.Application.Services.Constant
{
    /// <summary>
    /// 常量
    /// </summary>
    public static class ApplicationConstant
    {
        public static string EMPLOYEEKEY => "SYNCALLEMPLOYEE";

        public static string TEAMINFOKEY => "SYNCALLTEAMINFO";

        public static byte TEAMINFOCACHEDB => 3;

        /// <summary>
        /// 在第9个数据仓库
        /// </summary>
        public static byte EMPLOYEECACHEDB => 8;

        public static string GATEWAYCACHEKEY = "SYNCGATEWAYCACHE";

        public static byte GATEWAYCACHEDB => 3;

        /// <summary>
        /// 主推
        /// </summary>
        public static string PROEMOVEINFO = "PROPEMOVEINFO";
        /// <summary>
        /// 主推
        /// </summary>
        public static byte PROEMOVEINFODB => 6;
    }
}
