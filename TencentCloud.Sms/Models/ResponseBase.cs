using System;
using System.Collections.Generic;
using System.Text;

namespace TencentCloud.Sms.Models
{
    /// <summary>
    /// 腾讯云请求响应实体
    /// </summary>
    public class ResponseBase
    {
        public string RequestId { get; set; }

        public ErrorModel Error { get; set; }
    }

    public class ErrorModel
    {
        public string Code { get; set; }

        public string Message { get; set; }
    }
}
