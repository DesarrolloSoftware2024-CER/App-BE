using Watchly.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Watchly.Permissions;

public class WatchlyPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(WatchlyPermissions.GroupName);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(WatchlyPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<WatchlyResource>(name);
    }
}
