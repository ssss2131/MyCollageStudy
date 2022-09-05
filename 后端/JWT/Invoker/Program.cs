using System.Text.Json;

namespace Invoker
{
    internal class Program
    {
        private static string jwtServer = "https://localhost:7293";
        private static string resource = "https://localhost:7036";
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //var Jwt = JsonSerializer.Deserialize<JWT>(RequestToken());
            CallWebAPI_WithToken();

        }

        private static string RequestToken()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(jwtServer);
            client.DefaultRequestHeaders.Clear();

            string username = "admin";
            string password = "123456";

            var res = client.GetAsync($"Api/Authorize/GetToken?username={username}&password={password}").Result;
            var json = res.Content.ReadAsStringAsync().Result;

            var jwt = JsonSerializer.Deserialize<JWT>(json);

            return jwt.access_token;

        }

        private static void CallWebAPI_WithToken()
        {
            var token = RequestToken();
            Console.WriteLine($"-----------------------------------");
            Console.WriteLine($"JWT Token = {token}");

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(resource);
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");


            Console.WriteLine($"\n-------请求WebAPI-------");
            var resWithToken = client.GetAsync("WeatherForecast").Result;

            Console.WriteLine($"返回结果 : {(int)resWithToken.StatusCode}, {resWithToken.Content.ReadAsStringAsync().Result}");

        }
    }
}