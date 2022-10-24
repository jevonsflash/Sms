namespace Aliyun.Sms.Configuration
{
    public class AliyumSmsConfiguration : IAliyumSmsConfiguration
    {
        public string RegionId { get; set; }
        public string AccessKey { get; set; }
        public string AccessKeySecret { get; set; }
        public string DefaultPassword { get; set; }
    }
}