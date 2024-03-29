﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TencentCloud.Sms.Sdks
{

    public abstract class SdkRequestBase
    {
        public virtual string ResultRoot { get; } = "Response";

        public HttpRequestMessage HttpRequestMessage { get; }

        protected string Endpoint { get; private set; }

        protected string Scheme { get; private set; }

        protected string ApiPath { get; private set; }

        protected string RequestBody { get; private set; }

        protected Dictionary<string, object> RequestParamsRecord { get; private set; } = new();

        protected string ServiceName
        {
            get
            {
                if (string.IsNullOrEmpty(Endpoint)) throw new ArgumentNullException(nameof(Endpoint), "终端点地址不能够为空。");
                var data = Endpoint.Split('.');
                if (data.Length <= 0) throw new ArgumentOutOfRangeException(nameof(Endpoint), "终端点地址不正确。");
                return data[0];
            }
        }

        protected long Timestamp { get; }

        public SdkRequestBase(string apiPath = null, string scheme = "https")
        {
            ApiPath = apiPath;

            Scheme = scheme;

            Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            HttpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
            };
            HttpRequestMessage.Headers.Add("X-TC-Timestamp", Timestamp.ToString());
        }

        public virtual void SetAction(string action) => HttpRequestMessage.Headers.Add("X-TC-Action", action);

        public virtual void SetRegion(string region) => HttpRequestMessage.Headers.Add("X-TC-Region", region);

        public virtual void SetVersion(string version) => HttpRequestMessage.Headers.Add("X-TC-Version", version);

        public virtual void SetToken(string token) => HttpRequestMessage.Headers.Add("X-TC-Token", token);

        public virtual void SetEndpoint(string endpoint)
        {
            Endpoint = endpoint;

            HttpRequestMessage.RequestUri = new Uri($"{Scheme}://{Endpoint}/{ApiPath}");
        }

        protected virtual string BuildPayloadSign() => RequestBody.ToSHA256();

        /// <summary>
        /// 获得凭证范围字符串。
        /// </summary>
        protected virtual string GetCredentialScopeString(long timestamp) => new StringBuilder()
            .Append(GetUtcDate(timestamp).ToString("yyyy-MM-dd")).Append('/')
            .Append(ServiceName).Append('/')
            .Append("tc3_request")
            .ToString();

        /// <summary>
        /// 获得需要签名的头部信息。
        /// </summary>
        /// <returns></returns>
        protected virtual string GetSignedHeaders() => "content-type;host";

        /// <summary>
        /// 拼接规范请求字符串。
        /// </summary>
        protected virtual string BuildCanonicalRequest()
        {
            if (HttpRequestMessage.Method != HttpMethod.Post)
            {
                throw new InvalidOperationException("目前本 SDK 仅支持 POST 请求方式。");
            }

            var sb = new StringBuilder();
            sb.Append("POST").Append('\n')
                .Append('/').Append('\n').Append('\n')
                // .Append("content-type:").Append("application/json; ").Append("charset=utf-8").Append('\n')
                .Append("content-type:").Append("application/json").Append('\n')
                .Append("host:").Append(Endpoint).Append('\n').Append('\n')
                .Append(GetSignedHeaders()).Append('\n')
                .Append(BuildPayloadSign());

            return sb.ToString();
        }

        /// <summary>
        /// 拼接待签名字符串。
        /// </summary>
        protected virtual string BuildWaitSignatureString()
        {
            return new StringBuilder()
                .Append("TC3-HMAC-SHA256").Append('\n')
                .Append(Timestamp.ToString()).Append('\n')
                .Append(GetCredentialScopeString(Timestamp)).Append('\n')
                .Append(BuildCanonicalRequest().ToSHA256())
                .ToString();
        }

        /// <summary>
        /// 构建签名字符串。
        /// </summary>
        /// <param name="key">需要的 Secret Key。</param>
        protected virtual string BuildSignature(string key)
        {
            var tc3SecretKey = Encoding.UTF8.GetBytes($"TC3{key}");

            var secretDate = HmacSha256(tc3SecretKey, GetUtcDate(Timestamp).ToString("yyyy-MM-dd"));
            var secretService = HmacSha256(secretDate, ServiceName);
            var secretSigning = HmacSha256(secretService, "tc3_request");
            var signatureBytes = HmacSha256(secretSigning, BuildWaitSignatureString());

            return BitConverter.ToString(signatureBytes).Replace("-", "").ToLower();
        }

        public virtual void SetAuthorization(string id, string key)
        {
            var sb = new StringBuilder();
            sb.Append("TC3-HMAC-SHA256").Append(" ")
                .Append("Credential=").Append(id).Append('/').Append(GetCredentialScopeString(Timestamp)).Append(", ")
                .Append("SignedHeaders=").Append(GetSignedHeaders()).Append(", ")
                .Append("Signature=").Append(BuildSignature(key));

            HttpRequestMessage.Headers.TryAddWithoutValidation("Authorization", sb.ToString());
        }

        protected void SetRequestBody(object paramsObj)
        {
            RequestBody = JsonConvert.SerializeObject(paramsObj, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            RequestParamsRecord = JsonConvert.DeserializeObject<Dictionary<string, object>>(RequestBody);

            HttpRequestMessage.Content = new StringContent(RequestBody);
            HttpRequestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            HttpRequestMessage.Content.Headers.Add("charset", "utf-8");
        }

        public byte[] HmacSha256(byte[] key, string data)
        {
            using (var hmac256 = new HMACSHA256(key))
            {
                return hmac256.ComputeHash(Encoding.UTF8.GetBytes(data));
            }
        }
        public DateTime GetUtcDate(long unixTimestamp) => new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTimestamp);
    }
}
