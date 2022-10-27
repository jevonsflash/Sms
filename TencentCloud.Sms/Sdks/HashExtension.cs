using System.Security.Cryptography;
using System.Text;

namespace TencentCloud.Sms.Sdks
{
    public static class HashExtension
    {
        public static string ToMd5(this string str)
        {
            var md5Bytes = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(str));
            var stringBuilder = new StringBuilder();
            foreach (var @byte in md5Bytes)
            {
                stringBuilder.Append(@byte.ToString("x2"));
            }

            return stringBuilder.ToString();
        }

        public static string ToSHA256(this string str)
        {

            var md5Bytes = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(str));
            var stringBuilder = new StringBuilder();
            foreach (var @byte in md5Bytes)
            {
                stringBuilder.Append(@byte.ToString("x2"));
            }
            return stringBuilder.ToString();
        }

    }
}