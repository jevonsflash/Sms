using Aliyun.Sms.Models;
using System.Threading.Tasks;

namespace Aliyun.Sms.Services
{
    public interface IAliyunSmsService
    {
        public Task<SendSmsResponse> SendSmsAsync(SendSmsRequest req);
        public Task<QuerySendDetailResponse> QuerySendDetailsAsync(QuerySendDetailRequest req);
    }
}