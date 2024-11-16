using Abp.Authorization;
using ServerCore.Server.Roles;
using ServerCore.Server.Users;

namespace ServerCore.Server
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}