using System.Net.WebSockets;
using Microsoft.AspNetCore.Mvc;
using  StartMyNetCore.LifeTime;
namespace StartMyNetCore.HomeControlle;
public class HomeController : Controller
{
    private readonly IOperationScoped _osp;
    private readonly IOperationSingleton _ospSgt;
    private readonly IOperationTransient _ospTst;
    public HomeController(IOperationScoped osp,IOperationSingleton ospSgt,IOperationTransient ospTst)
    {
        _osp = osp;
        _ospSgt = ospSgt;
        _ospTst = ospTst;
    } 
    public IActionResult Index([FromServices] IOperationScoped otest,[FromServices] IOperationTransient otest2)
    {
        System.Console.WriteLine("Scoped"+_osp.OperationId);
        System.Console.WriteLine("Singleton:"+_ospSgt.OperationId);
        System.Console.WriteLine("Transient:"+_ospTst.OperationId);
        System.Console.WriteLine("Scoped+++"+otest.OperationId );
        System.Console.WriteLine("Transient+++"+otest2.OperationId );    
        return View();

        // Scoped22af
        // Singleton:b7e3
        // Transient:bb71
        // Scoped+++22af
        // Transient+++651b
    }


    public IActionResult Welcome()
    {
        System.Console.WriteLine(_osp.OperationId);
        System.Console.WriteLine(_ospSgt.OperationId);
        System.Console.WriteLine(_ospTst.OperationId);
        ViewData["Message"] = "Your welcome message";
        return View();
    }
}

