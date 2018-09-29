using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using $safeprojectname$.Utilities.Swagger;

namespace Microsoft.Extensions.DependencyInjection {
    public static class SwaggerCustomExtension {
        public static void AddSwaggerGen(
            this IServiceCollection services,
            string name,
            string title,
            string description,
            string version) {
            // 註冊Swagger產生器
            services.AddSwaggerGen(options => {
                options.SwaggerDoc(
                    name,
                    new Info {
                        Title = title,
                        Description = description,
                        Version = version
                    });

                options.AddSecurityDefinition(
                   "bearer",
                   new ApiKeyScheme() {
                       In = "header",
                       Description = "請輸入Bearer類型的JWT在此欄位",
                       Name = "Authorization",
                       Type = "apiKey",
                   });

                options.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>() {
                    ["bearer"] = new string[] { },
                    ["basic"] = new string[] { }
                });
                foreach (var file in Directory.GetFiles(
                    PlatformServices.Default.Application.ApplicationBasePath,
                    "*.xml")) {
                    options.IncludeXmlComments(file);
                }

                options.OperationFilter<FormFileOperationFilter>();
                options.OperationFilter<AuthorizeOperationFilter>();
            });
        }
    }
}
