using Abp.Configuration.Startup;

namespace Aliyun.Sms.Configuration
{
    public static class AliyunSmsConfigurationExtensions
    {
        /// <summary>
        ///     Used to configure ABP AliyunSms module.
        /// </summary>
        public static IAliyunSmsConfiguration AliyunSms(this IModuleConfigurations configurations)
        {
            return configurations.AbpConfiguration.Get<IAliyunSmsConfiguration>();
        }
    }
}
