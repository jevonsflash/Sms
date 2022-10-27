using Aliyun.Sms.Models;
using Sms;
using Sms.Interfaces;
using System.Threading.Tasks;

namespace Aliyun.Sms.Services
{
    public interface IAliyunSmsService: ISmsService
    {
        public Task<QuerySendDetailResponse> QuerySendDetailsAsync(QuerySendDetailRequest req);
    }
}