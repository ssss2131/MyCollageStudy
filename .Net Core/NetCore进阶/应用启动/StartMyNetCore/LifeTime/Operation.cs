namespace StartMyNetCore.LifeTime;

public class Operation:IOperationScoped,IOperationSingleton,IOperationTransient
{
    public Operation()
    {
        OperationId = Guid.NewGuid().ToString()[^4..];
    }
   public string OperationId {get;}
}
