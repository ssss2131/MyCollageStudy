using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OptionsBuilder.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuration;
        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public void OnGet()
        {           
            //这就是选项模式
            var optionsbuilder = new optionClass();
            _configuration.GetSection("optionClass").Bind(optionsbuilder);

            var name = optionsbuilder.Name;
            var age = optionsbuilder.Age;
            var n = "";
         
        }
    }
}