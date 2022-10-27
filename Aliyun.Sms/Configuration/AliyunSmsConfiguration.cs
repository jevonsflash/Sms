namespace Aliyun.Sms.Configuration
{
    public class AliyunSmsConfiguration : IAliyunSmsConfiguration
    {
        public string RegionId { get; set; }
        public string AccessKey { get; set; }
        public string AccessKeySecret { get; set; }
    }
}