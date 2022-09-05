namespace ConsulWebApi.Options;
// "ConsulServer":"http://localhost:8500",
//   "DataCenter":"图书管理",
//   "APIAddress":"http://localhost",
//   "APIPort":"5081",
//   "ApiName":"api/WeatherForecast",
//   "HealthPort":"https://localhost:7024",
//   "APICheckAddress":"api/healthcheck"
public class MyConsul
{

    //Consul 所在的地址
    public string? ConsulServer { get; set; }
    //数据中心
    public string? DataCenter { get; set; }
    //api的地址
    public string? APIAddress { get; set; }
    //api所在的端口号
    public string? APIPort { get; set; }
    public string[]? ApiName { get; set; }
    public string? HealthPort { get; set; }
    public string? APICheckAddress { get; set; }


}