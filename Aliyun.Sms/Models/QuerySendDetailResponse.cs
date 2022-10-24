using System;
using System.Collections.Generic;
using System.Text;

namespace Aliyun.Sms.Models
{
    /// <summary>
    /// 发送记录查询
    /// </summary>
    public class QuerySendDetailResponse : ResponseBase
    {
        /// <summary>
        /// 短信发送明细集合。
        /// </summary>
        public QuerySendDetailList SmsSendDetailDTOs { get; set; }

        /// <summary>
        /// 短信发送总条数。
        /// </summary>
        public int TotalCount { get; set; }
    }
}
