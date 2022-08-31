using AbpBlazorServer.Localization;
using Volo.Abp.AspNetCore.Components;

namespace AbpBlazorServer.Blazor;

public abstract class AbpBlazorServerComponentBase : AbpComponentBase
{
    protected AbpBlazorServerComponentBase()
    {
        LocalizationResource = typeof(AbpBlazorServerResource);
    }
}
