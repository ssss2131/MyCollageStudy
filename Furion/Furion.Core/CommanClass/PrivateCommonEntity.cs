using Furion.DatabaseAccessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furion.Core.CommanClass;

/// <summary>
/// 自定义公共类
/// </summary>
/// <typeparam name="TKey"></typeparam>
//public abstract class CommonEntity : CommonEntity<int, MasterDbContextLocator>
//{
//}
public abstract class PrivateCommonEntity<TKey> : IPrivateEntity
{
    // 注意是在这里定义你的公共实体
    public virtual DateTime CreatedTime { get; set; }
    // 更多属性定义
}

