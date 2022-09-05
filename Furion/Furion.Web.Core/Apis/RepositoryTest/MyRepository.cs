using Furion.Core.Locator;
using Furion.Core.Model;
using Furion.DatabaseAccessor;


namespace Furion.Web.Core.Apis.RepositoryTest
{
    /// <summary>
    /// 
    /// </summary>
    public class MyRepository : IDynamicApiController
    {
        private readonly IRepository<TestSqlServer, SqlServerDbContextLocator> _testRepsitory;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="testRepsitory"></param>
        public MyRepository(IRepository<TestSqlServer, SqlServerDbContextLocator> testRepsitory)
        {
            _testRepsitory = testRepsitory;
        }
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="test"></param>
        [HttpPost]
        public string CreateUser([FromQuery] TestSqlServer test)
        {
            _testRepsitory.Insert(test);
            return JsonSerializer.Serialize(test);
        }
        /// <summary>
        /// 全部更新 除了Id
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        public string UpdateUser([FromBody] TestSqlServer test)
        {
            _testRepsitory.Update(test);
            var res =  _testRepsitory.FirstOrDefault(c => c.Id == test.Id);
            return JsonSerializer.Serialize(res);
        }
        /// <summary>
        /// 部分更新 只允许修改Name和DateTime属性 不是立即提交
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        public string UpdatePart([FromBody] TestSqlServer test)
        {
            var entity = _testRepsitory.FirstOrDefault(c => c.Id == test.Id);
            _testRepsitory.UpdateExclude(entity, new[] { nameof(test.Name), nameof(test.DateTime) });
            var res = _testRepsitory.FirstOrDefault(c=>c.Id == test.Id);
            return JsonSerializer.Serialize(res);
        }
        /// <summary>
        /// 通过Id删除一个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Delete([FromQuery] int id)
        {
            var entity = _testRepsitory.FirstOrDefault(c => c.Id == id);
            var res = _testRepsitory.Delete(entity);
            return "ok";
        }
    }
}
