using Furion.Application.Core.Dto;
using Furion.DynamicApiController;

namespace Furion.Application.Core.Apis;
/// <summary>
/// 
/// </summary>
public class MyApi : IDynamicApiController
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [ApiDescriptionSettings(Tag = "分组一")]
    public string GetMyApi()
    {
        return "这是Api1";
    }

    /// <summary>
    /// 这是Get请求
    /// </summary>
    /// <returns></returns>
    public string Get()
    {
        return $"Hello {nameof(Furion)}";
    }
    //get head 请求不支持frombody 因此 fromquery
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Myclass"></param>
    /// <returns></returns>
    public string GetSome([FromQuery] MyClass Myclass)//框架会自动将其设置为restfullApi
    {
        return JsonSerializer.Serialize(Myclass);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string Getall()//通过配置设置httpMethod
    {
        return "All";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    //多种谓词
    [HttpPost, HttpGet, AcceptVerbs("PUT", "DELETE")]
    public string GetVersion()
    {
        return "1.0.0";
    }
   
}

