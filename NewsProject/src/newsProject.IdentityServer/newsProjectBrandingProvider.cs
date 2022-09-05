using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace newsProject;

[Dependency(ReplaceServices = true)]
public class newsProjectBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "newsProject";
}
