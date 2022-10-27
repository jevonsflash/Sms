using System.Text.Json;
using System.Threading.Tasks;
using Abp.Dependency;
using TencentCloud.Sms.Configuration;
using TencentCloud.Sms.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TencentCloud.Sms.Sdks;
using Sms.Interfaces;

namespace TencentCloud.Sms.Services
{
    public class TencentCloudSmsService : ITencentCloudSmsService, ISingletonDependency
    {
        private readonly ITencentCloudSmsConfiguration tencentCloudSmsConfiguration;
        private readonly SdkApiRequester _requester;

        public TencentCloudSmsService(
            ITencentCloudSmsConfiguration tencentCloudSmsConfiguration,
            SdkApiRequester requester)
        {
            this.tencentCloudSmsConfiguration=tencentCloudSmsConfiguration;
            _requester=requester;
        }

        public virtual async Task<ISendSmsResponse> SendSmsAsync(ISendSmsRequest req)
        {
            var request = new SdkSendSmsRequest(
                new[] {  $"+86{req.PhoneNumbers}", }, req.TemplateCode, tencentCloudSmsConfiguration.SmsSdkAppId, req.SignName, JsonConvert.DeserializeObject<string[]>(req.TemplateParam)

            );

            var commonOptions = new SdkOptions
            {
                SecretId =tencentCloudSmsConfiguration.SecretId,
                SecretKey =tencentCloudSmsConfiguration.SecretKey
            };

            var result = await _requester.SendRequestAsync<TencentCloudSendSmsResponse>(request,
                       "sms.tencentcloudapi.com", commonOptions);
            var ss = result.SendStatusSet.FirstOrDefault();
            if (ss != null)
            {
                return new SendSmsResponse()
                {
                    Code=ss.Code,
                    Message=ss.Message,
                    RequestId=result.RequestId,
                    BizId=ss.SerialNo
                };
            }
            return default;

        }



    }


}
