using System;
using System.Collections.Generic;
using System.Text;
using AbpBlazorServer.Localization;
using Volo.Abp.Application.Services;

namespace AbpBlazorServer;

/* Inherit your application services from this class.
 */
public abstract class AbpBlazorServerAppService : ApplicationService
{
    protected AbpBlazorServerAppService()
    {
        LocalizationResource = typeof(AbpBlazorServerResource);
    }
}
