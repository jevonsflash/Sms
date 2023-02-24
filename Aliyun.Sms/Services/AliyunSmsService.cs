using System.Text.Json;
using System.Threading.Tasks;
using Abp.Dependency;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Http;
using Aliyun.Acs.Core.Profile;
using Aliyun.Sms.Configuration;
using Aliyun.Sms.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sms.Interfaces;

namespace Aliyun.Sms.Services
{
    public class AliyunSmsService : IAliyunSmsService, ISingletonDependency
    {
        private readonly IAliyunSmsConfiguration _aliyumSmsConfiguration;
        private readonly ILogger<AliyunSmsService> _logger;
        private readonly DefaultAcsClient client;

        public AliyunSmsService(IAliyunSmsConfiguration aliyumSmsConfiguration, ILogger<AliyunSmsService> logger)
        {
            _aliyumSmsConfiguration=aliyumSmsConfiguration;
            _logger = logger;
            var profile = DefaultProfile.GetProfile(_aliyumSmsConfiguration.RegionId, _aliyumSmsConfiguration.AccessKey, _aliyumSmsConfiguration.AccessKeySecret);
            client = new DefaultAcsClient(profile);
        }


        public virtual async Task<ISendSmsResponse> SendSmsAsync(ISendSmsRequest req)
        {
            var request = new CommonRequest
            {
                Method = MethodType.POST,
                Domain = "dysmsapi.aliyuncs.com",
                Version = "2017-05-25",
                Action = "SendSms"
            };
            // request.Protocol = ProtocolType.HTTP;
            request.AddQueryParameters("PhoneNumbers", string.Join(",", req.PhoneNumbers));
            request.AddQueryParameters("SignName", req.SignName);
            request.AddQueryParameters("TemplateCode", req.TemplateCode);
            request.AddQueryParameters("TemplateParam", req.TemplateParam);

            var commonRes = client.GetCommonResponse(request);
            _logger.LogInformation("Send Aliyun Sms：req:{@req} res:{@commonRes}", req, commonRes);
            var result = JsonSerializer.Deserialize<SendSmsResponse>(commonRes.Data);
            return await Task.FromResult(result);
        }


        public virtual async Task<QuerySendDetailResponse> QuerySendDetailsAsync(QuerySendDetailRequest req)
        {
            CommonRequest request = new CommonRequest
            {
                Method = MethodType.POST,
                Domain = "dysmsapi.aliyuncs.com",
                Version = "2017-05-25",
                Action = "QuerySendDetails"
            };
            request.AddQueryParameters("PhoneNumber", req.PhoneNumbers);
            request.AddQueryParameters("SendDate", req.SendDate.ToString("yyyyMMdd"));
            request.AddQueryParameters("PageSize", req.PageSize.ToString());
            request.AddQueryParameters("CurrentPage", req.CurrentPage.ToString());
            if (!string.IsNullOrWhiteSpace(req.BizId))
            {
                request.AddQueryParameters("BizId", req.BizId);
            }

            var commonRes = client.GetCommonResponse(request);
            _logger.LogInformation("Query Send Details：req:{@req} res:{@commonRes}", req, commonRes);
            var result = JsonSerializer.Deserialize<QuerySendDetailResponse>(commonRes.Data);
            return await Task.FromResult(result);

        }

    }
}
