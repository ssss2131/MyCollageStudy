using Filters.Attribute;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Filters
{
    public class TransactionScopeFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            bool hasNotTransactionAttribute = false;
            if(context.ActionDescriptor is ControllerActionDescriptor)
            {
                var actionDesc = (ControllerActionDescriptor)context.ActionDescriptor;
                hasNotTransactionAttribute = actionDesc.MethodInfo.IsDefined(typeof(NotTransactionAttribute),false);
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
