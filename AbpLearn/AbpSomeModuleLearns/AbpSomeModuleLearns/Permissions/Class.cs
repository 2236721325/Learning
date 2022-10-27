using Volo.Abp.Authorization.Permissions;

namespace AbpSomeModuleLearns.Permissions
{
    public class AppPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup("App");

            myGroup.AddPermission("AppCreate");
        }
    }
}
