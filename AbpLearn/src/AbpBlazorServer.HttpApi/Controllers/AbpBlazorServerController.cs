using AbpBlazorServer.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpBlazorServer.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AbpBlazorServerController : AbpControllerBase
{
    protected AbpBlazorServerController()
    {
        LocalizationResource = typeof(AbpBlazorServerResource);
    }
}
