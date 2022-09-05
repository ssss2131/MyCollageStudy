using System.Net.Http;
using ConsulConsumer;
IService service = new ServiceImp();
 

System.Console.WriteLine(await service.InvokeService());


