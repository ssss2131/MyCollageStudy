

namespace Furion.Application.Core.Dto;



public class TestDto: IValidatableObject
{
    [Range(10, 20, ErrorMessage = "Id 只能在 10-20 区间取值")]
    public int Id { get; set; }

    [Required(ErrorMessage = "必填"), MinLength(3, ErrorMessage = "字符串长度不能少于3位")]
    public string Name { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var service = validationContext.GetService(typeof(string));
        if (Name.StartsWith("Furion"))
        {
            yield return new ValidationResult(
                "不能以 Furion 开头"
                , new[] { nameof(Name) }
            );
        }
    }
}

