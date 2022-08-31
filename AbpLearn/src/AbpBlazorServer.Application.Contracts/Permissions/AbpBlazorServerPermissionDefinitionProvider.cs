using AbpBlazorServer.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AbpBlazorServer.Permissions;

public class AbpBlazorServerPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AbpBlazorServerPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AbpBlazorServerPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AbpBlazorServerResource>(name);
    }
}
