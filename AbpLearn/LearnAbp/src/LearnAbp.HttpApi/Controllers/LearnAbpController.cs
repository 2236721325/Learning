using LearnAbp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace LearnAbp.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class LearnAbpController : AbpControllerBase
{
    protected LearnAbpController()
    {
        LocalizationResource = typeof(LearnAbpResource);
    }
}
