using System;
using System.Collections.Generic;
using System.Text;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace $safeprojectname$.Utilities.Swagger {
    /// <summary>
    /// Swagger API敘述操作過濾器基礎，用以實現在Summary標記API
    /// </summary>
    public abstract class SummaryOperationFilterBase : IOperationFilter {
        /// <summary>
        /// 標記
        /// </summary>
        public string Tag { get; private set; }

        public SummaryOperationFilterBase(string tag) {
            this.Tag = tag;
        }

        /// <summary>
        /// 標記條件
        /// </summary>
        /// <param name="operation">操作</param>
        /// <param name="context">內容</param>
        /// <returns>是否符合條件</returns>
        public abstract bool Condition(Operation operation, OperationFilterContext context);


        /// <summary>
        /// Swagger過濾邏輯
        /// </summary>
        /// <param name="operation">操作</param>
        /// <param name="context">內容</param>
        public void Apply(Operation operation, OperationFilterContext context) {
            if (Condition(operation, context)) {
                operation.Summary = this.Tag + operation.Summary;
            }
        }
    }
}
