using newsProject.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace newsProject.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class newsProjectController : AbpControllerBase
{
    protected newsProjectController()
    {
        LocalizationResource = typeof(newsProjectResource);
    }
}
