using Abp.Modules;
using Aliyun.Sms.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Abp.Reflection.Extensions;
using System.Reflection;
using Sms.Configuration;

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
            IocManager.Register<IAliyunSmsConfiguration, AliyunSmsConfiguration>();
            Configuration.Modules.AliyunSms().RegionId = _appConfiguration["AliyunSms:RegionId"];
            Configuration.Modules.AliyunSms().AccessKey = _appConfiguration["AliyunSms:AccessKey"];
            Configuration.Modules.AliyunSms().AccessKeySecret = _appConfiguration["AliyunSms:AccessKeySecret"];
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
