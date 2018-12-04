using NSwag.SwaggerGeneration.Processors;
using NSwag.SwaggerGeneration.Processors.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.Utilities.Swagger {
    /// <summary>
    /// 複寫Swagger Consumes操作過濾器
    /// </summary>
    internal class ConsumesOperationProcessor : IOperationProcessor {
    private readonly string[] _comsues;

    public ConsumesOperationProcessor(params string[] comsues) {
        this._comsues = comsues;
    }

    public async Task<bool> ProcessAsync(OperationProcessorContext context) {
        var currentConsumes = context.OperationDescription.Operation.Consumes;

        if (currentConsumes == null) {
            currentConsumes = new List<string>();
            context.OperationDescription.Operation.Consumes = currentConsumes;
        }

        _comsues.ToList().ForEach(
        comsue => {
            currentConsumes.Add(comsue);
        });


        return true;
    }
}
}
