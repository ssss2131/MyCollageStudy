using System;
using System.Net.Http;
using Polly;
using System.Threading;
using System.Threading.Tasks;
using Polly.Timeout;

namespace PollyTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //Policy policy= Policy
            //    .Handle<ArgumentException>()//故障
            //    .Fallback(()=>//动作：  降级
            //    {
            //        Console.WriteLine("执行出错");
            //    });
            //policy.Execute(() =>
            //{
            //    //这里是可能产生问题的业务系统代码
            //    Console.WriteLine("开始任务");
            //    throw new ArgumentException("Hello world!");
            //    Console.WriteLine("完成任务");

            //});
            //**************************************************************************
            //Policy policy = Policy
            //    .Handle<ArgumentException>()//故障
            //    .Fallback(() =>//动作：  降级
            //    {
            //        Console.WriteLine("执行出错");
            //    }, ex =>
            //    {
            //        Console.WriteLine($"详细异常对象：{ex.Message}");//可以得到具体的错误信息
            //    });
            //policy.Execute(() =>
            //{
            //    //这里是可能产生问题的业务系统代码
            //    Console.WriteLine("开始任务");
            //    throw new ArgumentException("Hello world!");
            //    Console.WriteLine("完成任务");

            //});
            //**************************************************************************
            //// 如果Execute中的代码是带返回值的，那么就要使用带泛型的Policy<T>
            //Policy<string> policy = Policy<string>
            //    .Handle<ArgumentException>()//故障
            //    .Fallback(() =>//动作：  降级
            //    {
            //        Console.WriteLine("执行出错");
            //        return "降级的值";
            //    }, ex =>
            //    {
            //        Console.WriteLine("详细异常对象"+ex);//可以得到具体的错误信息
            //    });
            //string value=policy.Execute(() =>
            //{
            //    //这里是可能产生问题的业务系统代码
            //    Console.WriteLine("开始任务");
            //    throw new ArgumentException("Hello world!");
            //    Console.WriteLine("完成任务");
            //    return "正常的值";

            //});
            //Console.WriteLine("返回值:" + value);

            //**************************************************************************
            //异常中可以使用Lambda表达式对异常判断“满是XXX条件的异常我才处理”
            //Policy<string> policy = Policy<string>
            //    .Handle<Exception>(ex=>ex.Message=="数据错误")//特定的错误信息进行处理
            //    .Fallback(() =>//动作：  降级
            //    {
            //        Console.WriteLine("执行出错");
            //        return "降级的值";
            //    }, ex =>
            //    {
            //        Console.WriteLine("详细异常对象" + ex);//可以得到具体的错误信息
            //    });
            //string value = policy.Execute(() =>
            //{
            //    //这里是可能产生问题的业务系统代码
            //    Console.WriteLine("开始任务");
            //    throw new ArgumentException("Hello world!");
            //    Console.WriteLine("完成任务");
            //    return "正常的值";

            //});
            //Console.WriteLine("返回值:" + value);

            //**************************************************************************
            //重试处理
            //Policy policy = Policy
            //    .Handle<Exception>() //处理错误
            //    .WaitAndRetry(100, i => TimeSpan.FromSeconds(1));
            //    //重试100次，每次间隔1秒
            //   // .RetryForever();//一直重试,直到成功
            //policy.Execute(() =>
            //{
            //    //这里是可能产生问题的业务系统代码
            //    Console.WriteLine("开始任务");
            //    if (DateTime.Now.Second % 10 != 0)
            //    {
            //        throw new Exception("出错");
            //    }

            //    Console.WriteLine("完成任务");
            //});
            ////**********************************************************
            //Policy policy = Policy
            //    .Handle<Exception>() //处理错误
            //    .CircuitBreaker(6, TimeSpan.FromSeconds(5));
            ////连续出现6次错误之后，熔断5秒，不会再去尝试执行业务代码
            //while (true)
            //{
            //    Console.WriteLine("开始Execute");
            //    try
            //    {
            //        policy.Execute(() =>
            //        {
            //            //这里是可能产生问题的业务系统代码
            //            Console.WriteLine("开始任务");
            //            throw new Exception("出错");
            //            Console.WriteLine("完成任务");
            //        });
            //    }
            //    catch
            //    {
            //        Console.WriteLine("Execute出错");
            //    }
            //    Thread.Sleep(500);
            //}



            //**********************************************************
            //Policy policyRetry = Policy.Handle<Exception>().Retry(3);
            //Policy policyFallback = Policy.Handle<Exception>()
            //    .Fallback(() =>
            //    {
            //        Console.WriteLine("降级");
            //    });
            ////Wrap: retry出故障了，再把故障抛给Fallback
            //Policy policy = policyFallback.Wrap(policyRetry);
            //policy.Execute(() =>
            //{
            //    //这里是可能产生问题的业务系统代码
            //    Console.WriteLine("开始任务");
            //    throw new Exception("Hello world!");
            //    Console.WriteLine("完成任务");
            //});

            //**********************************************************
            //Policy policyTimeout = Policy.Timeout(3, Polly.Timeout.TimeoutStrategy.Pessimistic);
            ////创建一个3秒钟的超时策略
            //Policy policy = Policy.Handle<TimeoutRejectedException>()
            //    .Fallback(() => { Console.WriteLine("降级"); });

            ////Wrap: retry出故障了，再把故障抛给Fallback
            ////policy.
            //policy = policy.Wrap(policyTimeout);
            //policy.Execute(() =>
            //{
            //    //这里是可能产生问题的业务系统代码
            //    Console.WriteLine("开始任务");
            //    Thread.Sleep(5000);
            //    Console.WriteLine("完成任务");
            //});

            Test1().Wait();


            Console.ReadKey();
        }

        // ***************异步带返回值*********************************
        static async Task Test1()
        {
            AsyncPolicy<byte[]> policy = Policy<byte[]>
                .Handle<Exception>()
                .FallbackAsync(async c =>
                    {
                        Console.WriteLine("执行出错");
                        return new byte[0];
                    }, async r =>
                    {
                        Console.WriteLine(r.Exception);
                    }
                );
            policy.WrapAsync(Policy.TimeoutAsync(2, TimeoutStrategy.Pessimistic, async (context, timespan, task) =>
               {
                   Console.WriteLine("Timeout");
               }));
            var bytes = await policy.ExecuteAsync(async () =>
            {
                Console.WriteLine("开始任务");
                HttpClient client = new HttpClient();
                var result = await client.GetByteArrayAsync("http://www.baidu.com");
                Console.WriteLine("完成任务");
                return result;
            });
            Console.WriteLine("bytes长度" + bytes.Length);
        }

        // ***************异步不带返回值*********************************
        static async Task Test2()
        {
            AsyncPolicy policy = Policy
                .Handle<Exception>()
                .FallbackAsync(async c =>
                    {
                        Console.WriteLine("执行出错");
                    }, async r =>
                    {
                        Console.WriteLine(r);//对于没有返回值的，这个参数直接是异常
                    }
                );
            policy.WrapAsync(Policy.TimeoutAsync(2, TimeoutStrategy.Pessimistic, async (context, timespan, task) =>
            {
                Console.WriteLine("Timeout");
            }));
           await policy.ExecuteAsync(async () =>
            {
                Console.WriteLine("开始任务");
                await Task.Delay(5000);//异步不能用Sleep
                Console.WriteLine("完成任务");
                
            });
        }

    }
}
