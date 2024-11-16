using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace ServerCore.Server
{
    public class RelayAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //ToDo Исправить права на актуальные
            context.CreatePermission(PermissionNames.ManageUsers, L("Users"));
            context.CreatePermission(PermissionNames.ManageRoles, L("Roles"));
            context.CreatePermission(PermissionNames.SendMessage);
            context.CreatePermission(PermissionNames.GetMessage);
            context.CreatePermission(PermissionNames.ServerAdmin, L("Tenants"),
                multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.TenantAdmin, L("Tenants"),
                multiTenancySides: MultiTenancySides.Tenant);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, RelayConsts.LocalizationSourceName);
        }
    }
}