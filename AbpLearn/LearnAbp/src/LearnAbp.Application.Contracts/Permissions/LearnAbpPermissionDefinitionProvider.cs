using LearnAbp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace LearnAbp.Permissions;

public class LearnAbpPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(LearnAbpPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(LearnAbpPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<LearnAbpResource>(name);
    }
}
