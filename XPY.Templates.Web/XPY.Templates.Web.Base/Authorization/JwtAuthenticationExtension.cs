using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Microsoft.Extensions.DependencyInjection {
    public static class SwaggerExtension {
        public static void AddJwtAuthentication(
            this IServiceCollection services,
            string secureKey,
            string issuer,
            string audience) {
            // 使用認證
            services.AddAuthentication(options => {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
                options.IncludeErrorDetails = true;
                options.SaveToken = true;

                options.TokenValidationParameters = new TokenValidationParameters() {
                    IssuerSigningKey = new SymmetricSecurityKey(secureKey.ToHash<MD5>()),
                    ValidIssuer = issuer, // 驗證的發行者
                    ValidAudience = audience, // 驗證的TOKEN接受者

                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true, // 檢查TOKEN發行者
                    ValidateAudience = true, // 檢查該TOKEN是否發給本服務
                    ValidateLifetime = true // 檢查TOKEN是否有效
                };
            });
        }
    }
}
