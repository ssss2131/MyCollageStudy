using Microsoft.AspNetCore.Mvc;


namespace PuroVoteSystem.Mvc.Controllers.VueTest
{
    public class VueTestController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public VueTestController(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Table()
        {
            var list = _context.SystemActivity.ToList();
            var targets = _mapper.Map<List<SystemActivity>, List<ActivityIndexViewModel>>(list);
            return View(targets);
        }
    }
}
