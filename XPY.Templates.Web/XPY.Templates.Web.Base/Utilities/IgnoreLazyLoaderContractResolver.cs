using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using XWidget.Web;

namespace $safeprojectname$.Utilities {
    /// <summary>
    /// JSON序列化略過EntityFrameworkCore中的ILazyLoader項目
    /// </summary>
    public class IgnoreLazyLoaderContractResolver : CamelCasePropertyNamesContractResolver {

    public IgnoreLazyLoaderContractResolver() {
    }

    protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization) {
        return this.CreatePropertiesWithModelMetadataType(type, memberSerialization);
    }

    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization) {
        return this.CreatePropertyWithIgnoreLazyLoader(member, memberSerialization);
    }
}
}
