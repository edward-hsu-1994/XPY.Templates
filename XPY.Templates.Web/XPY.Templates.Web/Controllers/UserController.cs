using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using $safeprojectname$.Base.Authorization;
using $safeprojectname$.Base.Mvc;
using $safeprojectname$.Logic;
using $safeprojectname$.Models.EF;
using XWidget.Web.Jwt;

namespace $safeprojectname$.Controllers {
    public class UserController : BaseController<$safeprojectname$Manager, $safeprojectname$Context> {
        public UserController($safeprojectname$Manager manager) : base(manager) {

        }

        /// <summary>
        /// 產生JWT範例
        /// </summary>
        /// <param name="userId">使用者唯一識別號</param>
        /// <returns>JWT</returns>
        private string BuildTokenSample(string userId) {
            var tokenModel = new $safeprojectname$Token() {
                Header = new DefaultJwtHeader() {
                    Algorithm = SecurityAlgorithms.HmacSha256
                },
                Payload = new MvcIdentityPayload() {
                    Actor = userId,
                    Issuer = Startup.Configuration.GetSection("JWT:Issuer").Value,
                    Audience = Startup.Configuration.GetSection("JWT:Audience").Value,
                    Name = userId,
                    Role = $safeprojectname$Token.Roles.Administrator,
                    Subject = $safeprojectname$Token.Subjects.Login,
                    IssuedAt = DateTime.Now,
                    Expires = DateTime.Now.AddHours(12)
                }
            };

            var key = new SymmetricSecurityKey(Startup.Configuration.GetSection("JWT:SecureKey")
                .Value.ToHash<MD5>()
            );

            return tokenModel.Sign(key);
        }
    }
}
