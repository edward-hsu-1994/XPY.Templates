using Microsoft.AspNetCore.Mvc;
using NSwag.SwaggerGeneration.Processors;
using NSwag.SwaggerGeneration.Processors.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.Utilities.Swagger {
/// <summary>
    /// 設定Swagger中的Consumes項目處理
    /// </summary>
    public class ConsumesAttributeProcessor : IOperationProcessor {
    public async Task<bool> ProcessAsync(OperationProcessorContext context) {
        var consumesAttr = context.MethodInfo.GetCustomAttribute<ConsumesAttribute>();
        if (consumesAttr != null) {
            context.OperationDescription.Operation.Consumes = new List<string>();
            context.OperationDescription.Operation.Consumes.AddRange(consumesAttr.ContentTypes);
        }

        return true;
    }
}
}
