using newsProject.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace newsProject.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class newsProjectPageModel : AbpPageModel
{
    protected newsProjectPageModel()
    {
        LocalizationResourceType = typeof(newsProjectResource);
    }
}
