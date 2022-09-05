using System;
using System.Collections.Generic;
using System.Text;
using newsProject.Localization;
using Volo.Abp.Application.Services;

namespace newsProject;

/* Inherit your application services from this class.
 */
public abstract class newsProjectAppService : ApplicationService
{
    protected newsProjectAppService()
    {
        LocalizationResource = typeof(newsProjectResource);
    }
}
