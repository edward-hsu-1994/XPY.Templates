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
    /// 常用ConsumesTypes常數
    /// </summary>
    public static class ConsumesTypes {
    public const string X3wFormUrlEncoded = "application/x-www-form-urlencoded";
    public const string FormData = "multipart/form-data";
}
}
