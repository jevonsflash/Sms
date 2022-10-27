using System;
using System.Collections.Generic;
using System.Text;

namespace Sms.Interfaces
{
    /// <summary>
    /// 短信发送明细
    /// </summary>
    public interface IQuerySendDetail
    {
        public int SendStatus { get; set; }

        public string ReceiveDate { get; set; }

        public string PhoneNum { get; set; }
    }
}
