using Abp.Configuration.Startup;

namespace TencentCloud.Sms.Configuration
{
    public static class TencentCloudSmsConfigurationExtensions
    {
        /// <summary>
        ///     Used to configure ABP TencentCloudSms module.
        /// </summary>
        public static ITencentCloudSmsConfiguration TencentCloudSms(this IModuleConfigurations configurations)
        {
            return configurations.AbpConfiguration.Get<ITencentCloudSmsConfiguration>();
        }
    }
}
