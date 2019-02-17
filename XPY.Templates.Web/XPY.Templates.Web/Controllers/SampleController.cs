using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using $safeprojectname$.Base.Authorization;
using $safeprojectname$.Base.Mvc;
using $safeprojectname$.Logic;
using $safeprojectname$.Models.EF;
using $safeprojectname$.Configuration;
using XWidget.Web.Jwt;

namespace $safeprojectname$.Controllers {
    public class SampleController : BaseController<$lastnamespace$Manager, $lastnamespace$Context> {
    public SampleController(
        $lastnamespace$Manager manager,
        ILogger<SampleController> logger) : base(manager, logger) {

    }

    /// <summary>
    /// 產生JWT
    /// </summary>
    /// <param name="userId">使用者唯一識別號</param>
    /// <returns>JWT</returns>
    private string BuildToken(string userId) {
        var tokenModel = new $lastnamespace$Token() {
            Header = new DefaultJwtHeader() {
                Algorithm = SecurityAlgorithms.HmacSha256
            },
                Payload = new MvcIdentityPayload() {
                    Actor = userId,
                    Issuer = $lastnamespace$Configuration.Instance.JWT.Issuer,
                    Audience = $lastnamespace$Configuration.Instance.JWT.Audience,
                    Name = userId,
                    Role = $lastnamespace$Token.Roles.Default,
                    Subject = $lastnamespace$Token.Subjects.Login,
                    IssuedAt = DateTime.Now,
                    Expires = DateTime.Now.AddSeconds($lastnamespace$Configuration.Instance.JWT.Expires)
                }
            };

        var key = new SymmetricSecurityKey(
            $lastnamespace$Configuration.Instance.JWT.SecureKey.ToHash<MD5>()
        );

        return tokenModel.Sign(key);
    }
}
}
