using System;
using System.Collections.Generic;
using System.Text;

namespace $safeprojectname$.Attributes {
    /// <summary>
    /// 標定EFCore Model預設排序
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class DefaultOrderAttribute : Attribute {
    /// <summary>
    /// 排序屬性(以`,`分割，如需遞減則在屬性開頭加上`-`)
    /// </summary>
    public string[] Properties { get; set; }

    public DefaultOrderAttribute(string properties) {
        this.Properties = properties.Split('-');
    }
}
}
