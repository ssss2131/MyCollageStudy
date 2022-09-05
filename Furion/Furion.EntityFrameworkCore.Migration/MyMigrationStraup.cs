
using Furion.Core.Locator;
using Furion.Core.Model;
using Furion.Core.Model.Furion.TypeBuilder;
using Furion.DatabaseAccessor;
using Furion.DynamicApiController;
using System.Text.Json;

Serve.Run();
/// <summary>
/// sqllite一定要设置为始终复制狙     
/// </summary>
public class Apis : IDynamicApiController
{
    private readonly IRepository<User> _repository;
    public Apis(IRepository<User> repository)
    {
        _repository = repository;
      
    }
    public void Set()
    {
        var user = new User
        {
            CreatedTime = DateTime.Now,
            Id = 1,
            Name = "nAME",
            TenantId = Guid.NewGuid(),
            UpdatedTime = DateTime.Now

        };
        _repository.Insert(user);
    }
    public string Get()
    {
        return JsonSerializer.Serialize(_repository.Entities.ToList());
    }
    
}

[DynamicApiController]
public class SqlServerApis
{
    private readonly IRepository<TestSqlServer, SqlServerDbContextLocator> _repositoryTest;

    public SqlServerApis(IRepository<TestSqlServer, SqlServerDbContextLocator> repositoryTest)
    {
        _repositoryTest = repositoryTest;
    }
            
    public void SetSql()
    {
        TestSqlServer test = new TestSqlServer()
        {
            Age = 10,
            DateTime = DateTime.Now,
            Name = "Name",
            TenantId = Guid.NewGuid()
        };

        _repositoryTest.Insert(test);
    }
    public string GetSql()
    {
        return JsonSerializer.Serialize(_repositoryTest.Entities.ToList());
    }


}