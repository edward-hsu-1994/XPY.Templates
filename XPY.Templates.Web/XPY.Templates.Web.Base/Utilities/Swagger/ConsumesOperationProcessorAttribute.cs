using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using NSwag.Annotations;
using NSwag.SwaggerGeneration.Processors;
using NSwag.SwaggerGeneration.Processors.Contexts;

namespace $safeprojectname$.Utilities.Swagger {
    /// <summary>
    /// 複寫Swagger Consumes
    /// </summary>
    public class OperationConsumesAttribute : SwaggerOperationProcessorAttribute {
    public const string FormUrlEncoded = "application/x-www-form-urlencoded";
    public const string FormData = "multipart/form-data";
    public OperationConsumesAttribute(params string[] comsues) : base(typeof(ConsumesOperationProcessor), comsues) {

    }
}
}
