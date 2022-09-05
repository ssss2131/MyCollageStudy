using Furion.Application.Core.Dto;


namespace Furion.Application.Core.Apis;
/// <summary>
/// 
/// </summary>
 [ApiDescriptionSettings(Tag = "分组二")]
public class ValidateApi:IDynamicApiController
{
    /// <summary>
    /// Oops.Oh
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetException(int id)
    {
        if (id < 3)
            throw Oops.Oh(ErrorCodes.z1000, id, 3);

        return id;
    }
    /// <summary>
    /// Dto Validation
    /// </summary>
    /// <param name="testDto"></param>
    /// <returns></returns>
    [HttpPost]
    public string PostTestDto([FromBody]TestDto testDto)
    {
       
        return JsonSerializer.Serialize(testDto); 
    }

}

