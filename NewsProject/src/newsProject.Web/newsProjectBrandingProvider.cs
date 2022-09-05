using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace newsProject.Web;

[Dependency(ReplaceServices = true)]
public class newsProjectBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "newsProject";
}
