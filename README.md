# Sms

适用于AbpBoilerplate的短信服务(Short Message Service，SMS)模块，通过简单配置即可使用，仅更改一处代码即可切换短信服务提供商。


Aliyun.Sms由阿里云Sms提供服务(https://www.aliyun.com/product/sms)

Tencent.Sms由腾讯云Sms提供服务(https://cloud.tencent.com/product/sms)




## 快速开始

### 使用阿里云Sms服务提供商
在项目中引用[AbpBoilerplate.Aliyun.Sms]( https://www.nuget.org/packages/AbpBoilerplate.Aliyun.Sms)


```
dotnet add package AbpBoilerplate.Aliyun.Sms
```

添加AliyunSmsModule模块依赖
```
[DependsOn(typeof(AliyunSmsModule))]
public class CoreModule : AbpModule

```

appsettings.json配置文件中，添加服务相关配置
```
"AliyunSms": {
    "RegionId": "cn-hangzhou",
    "AccessKey": "",
    "AccessKeySecret": ""
}
...
```
### 使用腾讯云Sms服务提供商
在项目中引用[AbpBoilerplate.TencentCloud.Sms]( https://www.nuget.org/packages/AbpBoilerplate.TencentCloud.Sms)


```
dotnet add package AbpBoilerplate.TencentCloud.Sms
```

添加TencentCloudSmsModule模块依赖
```
[DependsOn(typeof(TencentCloudSmsModule))]
public class CoreModule : AbpModule

```

appsettings.json配置文件中，添加服务相关配置
```
"TencentCloudSms": {
    "SmsSdkAppId": "",
    "SecretId": "",
    "SecretKey": ""
}
...
```



## 使用帮助

在Service层中注入ISmsService服务即可

发送短信示例
```
public class CaptchaManager : DomainService
{
    private readonly ISmsService smsService;

    public CaptchaManager(ISmsService smsService)
    {
        this.smsService=smsService;
    }

    public async Task SendCaptchaAsync(string phoneNumber)
    {

        var captcha = CommonHelper.GetRandomCaptchaNumber();
        var model = new SendSmsRequest();
        model.PhoneNumbers= phoneNumber;
        model.SignName="MatoApp";   //阿里云或腾讯云后台签名管理中设置应用名称
        model.TemplateCode="SMS_255330989";  //阿里云或腾讯云后台模板管理中设置模板
        model.TemplateParam="{'code':'"+captcha+"'}";
        await smsService.SendSmsAsync(model);
    }
}
```

<b>注意！不同服务商所传参数有可能不同，如腾讯的短信模板参数为字符串数组，而阿里云为键值对</b>
```
//for aliyun
model.TemplateParam= JsonConvert.SerializeObject(new { code = captcha });

//for tencent-cloud
model.TemplateParam= JsonConvert.SerializeObject(new string[] {captcha});
```


## 作者信息

作者：林小

邮箱：jevonsflash@qq.com



## License

The MIT License (MIT)
