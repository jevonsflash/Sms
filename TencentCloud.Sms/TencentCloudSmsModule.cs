using Abp.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Abp.Reflection.Extensions;
using System.Reflection;
using Sms.Configuration;
using TencentCloud.Sms.Configuration;

namespace TencentCloud.Sms
{
    public class TencentCloudSmsModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;
        public TencentCloudSmsModule(IHostEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(
    typeof(TencentCloudSmsModule).GetAssembly().GetDirectoryPathOrNull(), env.EnvironmentName, env.IsDevelopment()
);
        }
        public override void PreInitialize()
        {
            IocManager.Register<ITencentCloudSmsConfiguration, TencentCloudSmsConfiguration>();
            Configuration.Modules.TencentCloudSms().SmsSdkAppId = _appConfiguration["TencentCloudSms:SmsSdkAppId"];
            Configuration.Modules.TencentCloudSms().SecretId = _appConfiguration["TencentCloudSms:SecretId"];
            Configuration.Modules.TencentCloudSms().SecretKey = _appConfiguration["TencentCloudSms:SecretKey"];
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
