using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteSystem.Application.Utils.UserTools
{
    public static class PassWordHash
    {
        public static string encrypt(string password)
        {
            var md5 = System.Security.Cryptography.MD5.Create();
            var result = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            var strResult = BitConverter.ToString(result);
            string result3 = strResult.Replace("-", ""); 
            return strResult;
        }
    }
}
