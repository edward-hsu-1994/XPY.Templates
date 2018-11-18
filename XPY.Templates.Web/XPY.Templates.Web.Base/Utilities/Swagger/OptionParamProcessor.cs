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
    /// Swagger 可選參數操作過濾器
    /// </summary>
    public class OptionParamProcessor : IOperationProcessor {

    public async Task<bool> ProcessAsync(OperationProcessorContext context) {
        foreach (var param in context.Parameters.Values.ToList()) {
            var paramInfo = context.MethodInfo.GetParameters().Single(x => x.Position == param.Position - 1);

            if (paramInfo.HasDefaultValue &&
                param.IsRequired &&
                param.ActualParameter.Kind == NSwag.SwaggerParameterKind.Path &&
                !context.OperationDescription.Path.Contains(param.Name)) {
                param.IsRequired = false;
            }
        }
        return true;
    }
}
}
