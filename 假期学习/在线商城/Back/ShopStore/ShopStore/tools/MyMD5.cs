using System.Security.Cryptography;
using System.Text;

namespace ShopStore.tools
{
    public class MyMD5
    {
        public string EncryptPasswordMD5(string password)
        {
            using var md5 = MD5.Create();
            var result = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            var pwdMd5 = BitConverter.ToString(result);
            return pwdMd5.Replace("-", "");
        }
    }
}
