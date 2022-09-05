Serve.Run(RunOptions.Default,"https://localhost:8080");//注释掉 提示 程序不包含入口点的静态方法
//现在只能用 RunOptions.Default 帮助注册的furion是干净的
//还有GenericOptions.Default
//LegacyRunOptions 。。。。现在只知道默认不写会注册一些其怪的服务 不好修改 ??泛型主机 通用主机 =.=web

[DynamicApiController]//特性标签 或者IDynamicApicontroller接口
public class FirstFurion
{
    public string Say()
    {
        return "hello";
    }
    public string hello()
    {
        var brother = App.GetConfig<MyBrotherOptions>("MyBrother", true);
        Console.WriteLine(brother.Name + "\t" + brother.Age + "\t");
        return JsonSerializer.Serialize(brother);
    }
}
