using Sms.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms
{
    public interface ISmsService
    {
        public Task<ISendSmsResponse> SendSmsAsync(ISendSmsRequest req);

    }
}
