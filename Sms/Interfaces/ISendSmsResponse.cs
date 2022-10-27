using System;
using System.Collections.Generic;
using System.Text;

namespace Sms.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISendSmsResponse 
    {

        public string Message { get; set; }
        public string RequestId { get; set; }
        public string Code { get; set; }
        public string BizId { get; set; }
    }
}
