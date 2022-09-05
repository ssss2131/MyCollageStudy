实体状态
数据库上下文会随时跟踪内存中的实体是否已与其在数据库中的对应行进行同步。 此跟踪信息可确定调用 SaveChangesAsync 后的行为。 例如，将新实体传递到 AddAsync 方法时，该实体的状态设置为 Added。 调用 SaveChangesAsync 时，数据库上下文会发出 SQL INSERT 命令。

实体可能处于以下状态之一：

Added：数据库中尚不存在实体。 SaveChanges 方法发出 INSERT 语句。

Unchanged：无需保存对该实体所做的任何更改。 从数据库中读取实体时，该实体具有此状态。

Modified：已修改实体的部分或全部属性值。 SaveChanges 方法发出 UPDATE 语句。

Deleted：已标记该实体进行删除。 SaveChanges 方法发出 DELETE 语句。

Detached：数据库上下文未跟踪该实体。

在桌面应用中，通常会自动设置状态更改。 读取实体并执行更改后，实体状态自动更改为 Modified。 调用 SaveChanges 会生成仅更新已更改属性的 SQL UPDATE 语句。

在 Web 应用中，读取实体并显示数据的 DbContext 将在页面呈现后进行处理。 调用页面 OnPostAsync 方法时，将发出具有 DbContext 的新实例的 Web 请求。 如果在这个新的上下文中重新读取实体，则会模拟桌面处理。

例如新增
    var entry = _context.Add(new Student()); //Added
    entry.CurrentValues.SetValues(StudentVM);//Modified Added
    await _context.SaveChangesAsync();//Saved


安全 方面:防止多次发布 hacker 通过抓包,js等方式 修改不应该修改的字段
    .net 措施:使用 
    if (await TryUpdateModelAsync<Student>(
        studentToUpdate,
        "student",
        s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
    {
        await _context.SaveChangesAsync();
        return RedirectToPage("./Index");
    }
    这样确保只能新增这三个字段