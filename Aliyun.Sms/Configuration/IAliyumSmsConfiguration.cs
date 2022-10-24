namespace Aliyun.Sms.Configuration
{
    public interface IAliyumSmsConfiguration
    {
        string RegionId { get; set; }
        public string AccessKey { get; set; }
        public string AccessKeySecret { get; set; }
        string DefaultPassword { get; set; }
    }
}