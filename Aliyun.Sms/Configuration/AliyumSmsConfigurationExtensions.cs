using Abp.Configuration.Startup;

namespace Aliyun.Sms.Configuration
{
    public static class AliyumSmsConfigurationExtensions
    {
        /// <summary>
        ///     Used to configure ABP RocketChat module.
        /// </summary>
        public static IAliyumSmsConfiguration RocketChat(this IModuleConfigurations configurations)
        {
            return configurations.AbpConfiguration.Get<IAliyumSmsConfiguration>();
        }
    }
}
