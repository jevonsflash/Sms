namespace TencentCloud.Sms.Configuration
{
    public class TencentCloudSmsConfiguration : ITencentCloudSmsConfiguration
    {
        public string SmsSdkAppId { get; set; }
        public string SecretId { get; set; }
        public string SecretKey { get; set; }
    }
}