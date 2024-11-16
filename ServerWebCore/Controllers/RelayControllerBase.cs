using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;
using ServerCore;

namespace ServerWebCore.Controllers
{
    public abstract class RelayControllerBase : AbpController
    {
        protected RelayControllerBase()
        {
            LocalizationSourceName = RelayConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}