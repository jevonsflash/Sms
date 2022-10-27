using System.ComponentModel.DataAnnotations;

namespace Sms.Interfaces
{
    public interface ISendSmsRequest
    {
        public string PhoneNumbers { get; set; }

        public string TemplateCode { get; set; }

        public string TemplateParam { get; set; }

        public string SignName { get; set; }

        public string SmsUpExtendCode { get; set; }

        public string OutId { get; set; }

    }
}
