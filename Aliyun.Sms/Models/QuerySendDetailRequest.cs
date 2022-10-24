using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Aliyun.Sms.Models
{
    public class QuerySendDetailRequest
    {

        /// <summary>
        /// 国内短信：11位手机号码，例如15951955195。
        /// 国际/港澳台消息：国际区号+号码，例如85200000000。
        /// 支持对多个手机号码发送短信，手机号码之间以英文逗号（,）分隔。上限为1000个手机号码。批量调用相对于单条调用及时性稍有延迟。
        /// </summary>
        [Required]
        public string PhoneNumbers { get; set; }

        /// <summary>
        /// 短信发送日期，支持查询最近30天的记录。
        /// 格式为yyyyMMdd，例如20181225。
        /// </summary>
        [Required]
        public DateTime SendDate { get; set; }

        /// <summary>
        /// 发送回执ID，即发送流水号。调用发送接口SendSms或SendBatchSms发送短信时，返回值中的BizId字段。
        /// </summary>
        public string BizId { get; set; }

        /// <summary>
        /// 分页查看发送记录，指定每页显示的短信记录数量。
        /// 取值范围为1 ~50。
        /// </summary>
        [Required]
        [Range(1, 50)]
        public int PageSize { get; set; } = 20;

        /// <summary>
        ///分页查看发送记录，指定发送记录的当前页码。
        /// </summary>
        [Required]
        [Range(1, int.MaxValue)]
        public int CurrentPage { get; set; } = 1;
    }
}
