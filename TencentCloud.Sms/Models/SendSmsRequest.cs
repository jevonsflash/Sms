using Sms.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace TencentCloud.Sms.Models
{
    public class SendSmsRequest: ISendSmsRequest
    {

        [Required]
        public string[] PhoneNumbers { get; set; }
        [Required]
        public string TemplateCode { get; set; }

        [Required]
        public string TemplateParam { get; set; }

        [Required]
        public string SignName { get; set; }

        public string SmsUpExtendCode { get; set; }
        public string OutId { get; set; }

    }
}
