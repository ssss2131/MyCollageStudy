namespace PuroVoteSystem.Mvc.Utils.Filters
{
    public class TransactionScopeFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            bool hasNotTransactionAttribute = false;
            if (context.ActionDescriptor is ControllerActionDescriptor)
            {
                var actionDesc = (ControllerActionDescriptor)context.ActionDescriptor;
                hasNotTransactionAttribute = actionDesc.MethodInfo.IsDefined(typeof(NotTransactionAttribute), false);
            }
            if (hasNotTransactionAttribute)
            {
                await next();
                return;
            }
            using var txscope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var result = await next();
            if (result.Exception == null)
            {
                txscope.Complete();
            }

        }
    }
}
