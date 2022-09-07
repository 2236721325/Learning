using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace LearnAbp.Pages;

public class Index_Tests : LearnAbpWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
