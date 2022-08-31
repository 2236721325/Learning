﻿using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace HelloAbp;

[Dependency(ReplaceServices = true)]
public class HelloAbpBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "HelloAbp";
}
