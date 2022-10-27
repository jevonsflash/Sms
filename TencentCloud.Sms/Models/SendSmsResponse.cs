using Sms.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TencentCloud.Sms.Models
{

    public class SendSmsResponse : ISendSmsResponse
    {
        public string Message { get; set; }
        public string RequestId { get; set; }
        public string Code { get; set; }
        public string BizId { get; set; }
    }
}
