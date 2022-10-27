using Sms.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Aliyun.Sms.Models
{
    public class SendSmsRequest: ISendSmsRequest
    {

        /// <summary>
        /// 国内短信：11位手机号码，例如15951955195。
        /// 国际/港澳台消息：国际区号+号码，例如85200000000。
        /// 支持对多个手机号码发送短信，手机号码之间以英文逗号（,）分隔。上限为1000个手机号码。批量调用相对于单条调用及时性稍有延迟。
        /// </summary>
        /// <value>The phone numbers.</value>
        [Required]
        public string PhoneNumbers { get; set; }

        /// <summary>
        /// 短信模板ID。请在控制台模板管理页面模板CODE一列查看。
        /// 必须是已添加、并通过审核的短信签名；且发送国际/港澳台消息时，请使用国际/港澳台短信模版。
        /// </summary>
        [Required]
        public string TemplateCode { get; set; }

        /// <summary>
        /// 短信模板变量对应的实际值，JSON格式。
        /// 如果JSON中需要带换行符，请参照标准的JSON协议处理。
        /// </summary>
        [Required]
        public string TemplateParam { get; set; }

        /// <summary>
        /// 短信签名名称。请在控制台签名管理页面签名名称一列查看。
        /// 必须是已添加、并通过审核的短信签名。
        /// </summary>
        [Required]
        public string SignName { get; set; }

        /// <summary>
        /// 上行短信扩展码，无特殊需要此字段的用户请忽略此字段。
        /// </summary>
        /// <value>The Sms up extend code.</value>
        public string SmsUpExtendCode { get; set; }

        /// <summary>
        /// 外部流水扩展字段。
        /// </summary>
        /// <value>The out identifier.</value>
        public string OutId { get; set; }

    }
}
