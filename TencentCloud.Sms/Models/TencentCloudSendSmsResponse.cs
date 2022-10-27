using System;
using System.Collections.Generic;
using System.Text;

namespace TencentCloud.Sms.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class TencentCloudSendSmsResponse : ResponseBase
    {
        public List<SendStatusSet> SendStatusSet { get; set; }
    }

    public class SendStatusSet
    {
        public string SerialNo { get; set; }

        public string PhoneNumber { get; set; }

        public int Fee { get; set; }

        public string SessionContext { get; set; }

        public string Code { get; set; }

        public string Message { get; set; }

        public string IsoCode { get; set; }
    }
}
