using LearnAbp.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace LearnAbp.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class LearnAbpPageModel : AbpPageModel
{
    protected LearnAbpPageModel()
    {
        LocalizationResourceType = typeof(LearnAbpResource);
    }
}
