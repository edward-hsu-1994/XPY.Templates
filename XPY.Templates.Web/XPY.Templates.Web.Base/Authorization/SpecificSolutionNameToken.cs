using System;
using System.Collections.Generic;
using System.Text;
using XWidget.Web.Jwt;

namespace $safeprojectname$.Authorization {
    /// <summary>
    /// 存取權杖格式
    /// </summary>
    public class $lastnamespace$Token : IJwtToken<DefaultJwtHeader, MvcIdentityPayload> {
        /// <summary>
        /// 主題
        /// </summary>
        public static class Subjects {
    /// <summary>
    /// 登入
    /// </summary>
    public const string Login = "Login";
}

/// <summary>
/// 角色
/// </summary>
public static class Roles {
    /// <summary>
    /// 系統管理員
    /// </summary>
    public const string Administrator = "Administrator";
}

public DefaultJwtHeader Header { get; set; }
public MvcIdentityPayload Payload { get; set; }
}
}
