using System.ComponentModel.DataAnnotations;

namespace TencentCloud.Sms.Sdks
{
    public class SdkSendSmsRequest : SdkRequestBase
    {
        public SdkSendSmsRequest(
            string[] phoneNumberSet,
            string templateId,
            string smsSdkAppid,
            string sign = null,
            string[] templateParamSet = null,
            string extendCode = null,
            string sessionContext = null,
            string senderId = null)
        {
            SetAction("SendSms");
            SetVersion("2019-07-11");

            SetRequestBody(new
            {
                PhoneNumberSet = phoneNumberSet,
                TemplateID = templateId,
                SmsSdkAppid = smsSdkAppid,
                Sign = sign,
                TemplateParamSet = templateParamSet,
                ExtendCode = extendCode,
                SessionContext = sessionContext,
                SenderId = senderId
            });
        }
    }
}