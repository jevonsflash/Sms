namespace Aliyun.Sms.Configuration
{
    public interface IAliyunSmsConfiguration
    {
        string RegionId { get; set; }
        public string AccessKey { get; set; }
        public string AccessKeySecret { get; set; }
    }
}