using HelloRedis.Domain;
using HelloRedis.Repository;
using HelloRedis.RepositoryImp;
using Microsoft.Extensions.DependencyInjection;
using Presntation.Domain;
using Presntation.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;
using Tools.RabbitMQ;
using Tools.Service;

namespace Infrastracture.stratup
{
    static public class ServiceExtension
    {
        static public IServiceCollection Myservices(this IServiceCollection services)
        {
            #region 基础设施
            //实例化SqlServier数据库连接串 和 fluentApi
            services.AddScoped<SqlServerDbContext>();
            //services.AddScoped<AbsDbcontext,AppDbCont ext>();
            //实例化AbsContent
            services.AddScoped<AbsDbcontext, SqlServerDbContext>();
            #endregion

            #region 注册业务
            //实例化IBookService,IAuthorService 和 IStockService 服务
            services.AddScoped<IBaseService<Stock>, BaseSerivceImp<Stock>>();
            services.AddScoped<IBaseService<Book>, BaseSerivceImp<Book>>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IStockService, StockService>();
            services.AddScoped<IAuthorService, AuthorService>();
            #endregion

            #region 实例化 RabbitMq服务
            //services.AddScoped<IRabbitHelper, RabbitMQHelper>();
            services.AddSingleton<AbsRabbitMQ, RabbitMQHelper>();
            //services.AddScoped<IRabbitHelper, RabbitMqPub_Subs>();
            //services.AddScoped<AbsRabbitMQ, RabbitMqPub_Subs>();
            #endregion
            return services;
        }
        

    }
}
