using Abp.Modules;
using Aliyun.Sms.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Abp.Reflection.Extensions;
using System.Reflection;

namespace Aliyun.Sms
{
    public class AliyunSmsModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;
        public AliyunSmsModule(IHostEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(
    typeof(AliyunSmsModule).GetAssembly().GetDirectoryPathOrNull(), env.EnvironmentName, env.IsDevelopment()
);
        }
        public override void PreInitialize()
        {
            IocManager.Register<IAliyumSmsConfiguration, AliyumSmsConfiguration>();
            Configuration.Modules.RocketChat().RegionId = _appConfiguration["Sms:RegionId"];
            Configuration.Modules.RocketChat().AccessKey = _appConfiguration["Sms:AccessKey"];
            Configuration.Modules.RocketChat().AccessKeySecret = _appConfiguration["Sms:AccessKeySecret"];
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
