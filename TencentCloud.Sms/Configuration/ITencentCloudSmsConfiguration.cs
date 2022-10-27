namespace TencentCloud.Sms.Configuration
{
    public interface ITencentCloudSmsConfiguration
    {
        string SmsSdkAppId { get; set; }
        public string SecretId { get; set; }
        public string SecretKey { get; set; }
    }
}