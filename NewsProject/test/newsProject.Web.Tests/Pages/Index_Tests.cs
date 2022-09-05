using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace newsProject.Pages;

public class Index_Tests : newsProjectWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
