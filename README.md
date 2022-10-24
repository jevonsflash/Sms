# Aliyun.Sms

适用于AbpBoilerplate的阿里云短信服务(https://www.aliyun.com/product/sms)

## 快速开始

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
"Sms": {
"RegionId": "cn-hangzhou",
"AccessKey": "",
"AccessKeySecret": ""
}
...
```

## 使用帮助

在Service层中注入IAliyunSmsService服务即可

发送短信示例
```
public class CaptchaManager : DomainService
{
    private readonly IAliyunSmsService aliyunSmsService;

    public CaptchaManager(IAliyunSmsService aliyunSmsService)
    {
        this.aliyunSmsService=aliyunSmsService;
    }

    public async Task SendCaptchaAsync(string phoneNumber)
    {

        var captcha = CommonHelper.GetRandomCaptchaNumber();
        var model = new SendSmsRequest();
        model.PhoneNumbers= phoneNumber;
        model.SignName="MatoApp";   //阿里云后台签名管理中设置应用名称
        model.TemplateCode="SMS_255330989";  //阿里云后台模板管理中设置模板
        model.TemplateParam="{'code':'"+captcha+"'}";
        await aliyunSmsService.SendSmsAsync(model);
    }
}
```

查询发送情况示例
```
public async Task<QuerySendDetailResponse> GetSendDetai(string phoneNumber, DateTime sendDate)
{
    var model = new QuerySendDetailRequest();
    model.PhoneNumbers= phoneNumber;
    model.SendDate=sendDate;          
    var result = await aliyunSmsService.QuerySendDetailsAsync(model);
    return result;
}

```

## 作者信息

作者：林小

邮箱：jevonsflash@qq.com



## License

The MIT License (MIT)
