using System;
using System.Collections.Generic;
using System.Text;

namespace Aliyun.Sms.Models
{
    /// <summary>
    /// 短信发送明细。
    /// </summary>
    public class QuerySendDetailList
    {
        /// <summary>
        /// 短信发送明细。
        /// </summary>
        IEnumerable<QuerySendDetail> SmsSendDetailDTO { get; set; }
    }
}
