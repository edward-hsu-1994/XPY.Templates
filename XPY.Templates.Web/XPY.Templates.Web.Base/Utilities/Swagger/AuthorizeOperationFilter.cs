using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace $safeprojectname$.Utilities.Swagger {
    /// <summary>
    /// Swagger Authorize操作過濾器
    /// </summary>
    public class AuthorizeOperationFilter : SummaryOperationFilterBase {
        public AuthorizeOperationFilter() : base("🔐") { }

        public override bool Condition(Operation operation, OperationFilterContext context) {
            return (context.MethodInfo.GetCustomAttributes<AuthorizeAttribute>().Count() > 0 ||
                context.MethodInfo.DeclaringType.GetCustomAttributes<AuthorizeAttribute>().Count() > 0) &&
                context.MethodInfo.GetCustomAttributes<AllowAnonymousAttribute>().Count() == 0 &&
                context.MethodInfo.DeclaringType.GetCustomAttributes<AllowAnonymousAttribute>().Count() == 0;
        }
    }
}
