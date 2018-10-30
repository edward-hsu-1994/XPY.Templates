using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using NSwag.SwaggerGeneration.Processors;
using NSwag.SwaggerGeneration.Processors.Contexts;

namespace $safeprojectname$.Utilities.Swagger {
    /// <summary>
    /// Swagger Authorize操作過濾器
    /// </summary>
    public class AuthorizeOperationProcessor : IOperationProcessor {

    public async Task<bool> ProcessAsync(OperationProcessorContext context) {
        if ((context.MethodInfo.GetCustomAttributes<AuthorizeAttribute>().Count() > 0 ||
            context.MethodInfo.DeclaringType.GetCustomAttributes<AuthorizeAttribute>().Count() > 0) &&
            context.MethodInfo.GetCustomAttributes<AllowAnonymousAttribute>().Count() == 0 &&
            context.MethodInfo.DeclaringType.GetCustomAttributes<AllowAnonymousAttribute>().Count() == 0) {
            // nothing
        } else {
            context.OperationDescription.Operation.Security.Clear();
        }
        return true;
    }
}
}
