using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Authentication.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name,"myName"),
            new Claim(ClaimTypes.Email,"Name@qq.com"),
            new Claim("MyClaim","yes")
        };
        var myIdentity = new ClaimsIdentity(claims, "My Idnetity");
        var userPrincipal = new ClaimsPrincipal(new[] { myIdentity });
        HttpContext.SignInAsync(userPrincipal);

    }
}
