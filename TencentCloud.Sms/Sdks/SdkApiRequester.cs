using Abp.Dependency;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TencentCloud.Sms.Models;

namespace TencentCloud.Sms.Sdks
{
    public class SdkApiRequester : ITransientDependency
    {
        protected HttpClient HttpClient { get; }
        protected IHttpClientFactory HttpClientFactory { get; }


        public SdkApiRequester(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
            HttpClient = httpClientFactory.CreateClient("DefaultTencentCloud");
        }


        public virtual async Task<TResponse> SendRequestAsync<TResponse>(SdkRequestBase request, string endpoint,
            SdkOptions options)
        {
            request.SetEndpoint(endpoint);
            request.SetAuthorization(options.SecretId, options.SecretKey);

            using var response = await HttpClient.SendAsync(request.HttpRequestMessage);

            var result = await response.Content.ReadAsStringAsync();

            return string.IsNullOrEmpty(request.ResultRoot)
                ? JObject.Parse(result).ToObject<TResponse>()
                : JObject.Parse(result).SelectToken($"$.{request.ResultRoot}").ToObject<TResponse>();
        }
    }
}
