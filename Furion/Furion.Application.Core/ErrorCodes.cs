
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furion.Application.Core
{
    [ErrorCodeType]
    public enum ErrorCodes
    {
        [ErrorCodeItemMetadata("{0} 不能小于 {1}")]
        z1000,
        [ErrorCodeItemMetadata("数据不存在")]
        x1000,
        [ErrorCodeItemMetadata("{0} 发现 {1} 个异常", "百小僧", 2)]
        x1001,
        [ErrorCodeItemMetadata("服务器运行异常", ErrorCode = "Error")]
        SERVER_ERROR
    }
    [ErrorCodeType]
    public enum UserErrorCodes
    {
        [ErrorCodeItemMetadata("用户数据不存在")]
        u1000,
        [ErrorCodeItemMetadata("其他异常")]
        u1001
    }
}
