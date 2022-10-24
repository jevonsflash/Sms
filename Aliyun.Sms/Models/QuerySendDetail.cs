using System;
using System.Collections.Generic;
using System.Text;

namespace Aliyun.Sms.Models
{
    /// <summary>
    /// 短信发送明细
    /// </summary>
    public class QuerySendDetail
    {
        /// <summary>
        /// 短信发送日期和时间。
        /// </summary>
        public string SendDate { get; set; }

        /// <summary>
        /// 短信发送状态【1：等待回执。 2：发送失败。 3：发送成功。】
        /// </summary>
        public int SendStatus { get; set; }

        /// <summary>
        /// 短信接收日期和时间。
        /// </summary>
        public string ReceiveDate { get; set; }

        /// <summary>
        /// 运营商短信状态码。
        /// </summary>
        public string ErrCode { get; set; }

        /// <summary>
        /// 短信模板ID。
        /// </summary>
        public string TemplateCode { get; set; }

        /// <summary>
        /// 短信内容。
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 接收短信的手机号码。
        /// </summary>
        public string PhoneNum { get; set; }
    }
}
