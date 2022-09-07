using System;
using System.Collections.Generic;
using System.Text;
using LearnAbp.Localization;
using Volo.Abp.Application.Services;

namespace LearnAbp;

/* Inherit your application services from this class.
 */
public abstract class LearnAbpAppService : ApplicationService
{
    protected LearnAbpAppService()
    {
        LocalizationResource = typeof(LearnAbpResource);
    }
}
