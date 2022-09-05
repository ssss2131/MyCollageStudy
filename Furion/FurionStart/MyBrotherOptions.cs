namespace FurionStart;
//选项模式
//要求:类名 Options结尾
//      实现Iconfigurable接口 或者其子类接口、
//需要去 IServiceCollection key value 中注册AddConfigurableOptions<T>()服务
// 调用:App.GetConfig("",true) 第一个参数是json文件的对象名 第二个参数 是否在运行时动态加载参数


public class MyBrotherOptions: IConfigurableOptionsListener<MyBrotherOptions>
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public string[]? Parents { get; set; }
    public void OnListener(MyBrotherOptions options, IConfiguration configuration)
    {
        var name = options.Name;  // 实时的最新值
        var age = options.Age;  // 实时的最新值
    }
    //选项后期配
    public void PostConfigure(MyBrotherOptions options, IConfiguration configuration)
    {
        options.Name ??= "Bob";

        options.Parents ??= new string[] { "Papa","Mom"};
    }
}

