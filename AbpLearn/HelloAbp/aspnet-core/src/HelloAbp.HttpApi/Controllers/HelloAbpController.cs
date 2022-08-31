using HelloAbp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace HelloAbp.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class HelloAbpController : AbpControllerBase
{
    protected HelloAbpController()
    {
        LocalizationResource = typeof(HelloAbpResource);
    }
}
