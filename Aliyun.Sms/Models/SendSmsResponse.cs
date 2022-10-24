using System;
using System.Collections.Generic;
using System.Text;

namespace Aliyun.Sms.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class SendSmsResponse : ResponseBase
    {
        /// <summary>
        /// 发送回执ID，可根据该ID在接口QuerySendDetails中查询具体的发送状态。
        /// </summary>
        public string BizId { get; set; }
    }
}
