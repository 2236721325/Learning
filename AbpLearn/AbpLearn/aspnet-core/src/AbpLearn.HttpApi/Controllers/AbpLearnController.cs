using AbpLearn.Localization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpLearn.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AbpLearnController : AbpControllerBase
{
    protected AbpLearnController()
    {
        LocalizationResource = typeof(AbpLearnResource);
    }

}
