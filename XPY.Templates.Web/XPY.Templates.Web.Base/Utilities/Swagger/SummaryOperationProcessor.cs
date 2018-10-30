using NSwag.SwaggerGeneration.Processors;
using NSwag.SwaggerGeneration.Processors.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.Utilities.Swagger {
    /// <summary>
    /// Swagger API敘述操作過濾器基礎，用以實現在Summary標記API
    /// </summary>
    public abstract class SummaryOperationProcessor : IOperationProcessor {
    /// <summary>
    /// 標記
    /// </summary>
    public string Tag { get; private set; }

    public SummaryOperationProcessor(string tag) {
        this.Tag = tag;
    }


    /// <summary>
    /// 標記條件
    /// </summary>
    /// <param name="context">操作內容</param>
    /// <returns>是否符合條件</returns>
    public abstract bool Condition(OperationProcessorContext context);


    public async Task<bool> ProcessAsync(OperationProcessorContext context) {
        if (Condition(context)) {
            context.OperationDescription.Operation.Summary = this.Tag + context.OperationDescription.Operation.Summary;
            return true;
        }
        return true;
    }
}
}
