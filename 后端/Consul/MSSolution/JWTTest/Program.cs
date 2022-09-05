using System;
using System.Collections.Generic;
using JWT.Algorithms;
using JWT.Serializers;
using JWT.Exceptions;
using JWT;

namespace JWTTest
{
    class Program
    {
        static void Main(string[] args)
        {
            double exp = (DateTime.UtcNow.AddSeconds(10) - new DateTime(1970, 1, 1)).TotalSeconds;
            /*加密
            var payload = new Dictionary<string, Object>
            {
                {"UserId",123},
                {"UserName","admin"},
                {"exp":exp}//过期时间
            };
            var secret = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNAmD7RTE2dr";
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            var token = encoder.Encode(payload, secret);
            Console.WriteLine(token);
            */
            var token =
                "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJVc2VySWQiOjEyMywiVXNlck5hbWUiOiJhZG1pbiJ9.6vNn83_QxrMo3lguScabi_CvpyHiDKjUVkBmnu4JeCQ";
            var secret = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNAmD7RTE2dr";
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);
                //decoder.DecodeToObject(token);// 没有校验秘钥合法性
                var dicInfo = decoder.DecodeToObject(token, secret, verify: true);
                Console.WriteLine(dicInfo);
            }
            catch (FormatException)
            {
                Console.WriteLine("Token format invalid");
            }
            catch (TokenExpiredException)
            {
                Console.WriteLine("Token has expired");
            }
            catch (SignatureVerificationException)
            {
                Console.WriteLine("Token has invalid signature");
            }
            Console.ReadKey();
        }
    }
}
