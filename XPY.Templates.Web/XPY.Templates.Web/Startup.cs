using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using $safeprojectname$.Base.Utilities;
using $safeprojectname$.Base.Utilities.Swagger;
using $safeprojectname$.Logic;
using $safeprojectname$.Models.EF;

namespace $safeprojectname$ {
    /// <summary>
    /// 啟動類別
    /// </summary>
    public class Startup {
    public Startup(IConfiguration configuration) {
        Configuration = configuration;
    }

    /// <summary>
    /// 設定值
    /// </summary>
    public static IConfiguration Configuration { get; private set; }

    /// <summary>
    /// 服務設定方法，這個方法用以設定新增服務至服務容器
    /// </summary>
    /// <param name="services">服務容器</param>
    public void ConfigureServices(IServiceCollection services) {
        // 加入邏輯控制器
        services.AddLogic <$lastnamespace$Manager, $lastnamespace$Context > ()
             .AddFromDbContext("Id");

        // 使用認證
        services.AddJwtAuthentication(
            secureKey: Configuration.GetSection("JWT:SecureKey").Value,
            issuer: Configuration.GetSection("JWT:Issuer").Value,
            audience: Configuration.GetSection("JWT:Audience").Value);

        // 使用MVC服務
        services.AddMvc()
            .AddJsonOptions(options => { // 設定JSON格式化選項
                                         // 使用忽略LazyLoader屬性
                options.SerializerSettings.ContractResolver = new IgnoreLazyLoaderContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

        // 註冊Swagger產生器
        services.AddSwaggerGen(
            name: Configuration.GetSection("Swagger:Name").Value,
            title: Configuration.GetSection("Swagger:Title").Value,
            description: Configuration.GetSection("Swagger:Description").Value,
            version: Configuration.GetSection("Swagger:Version").Value);

        // 設定SPA根目錄
        services.AddSpaStaticFiles(options => {
            options.RootPath = "./wwwroot";
        });
    }

    /// <summary>
    /// 執行階段管線，這個方法用以設定HTTP Request管線流程
    /// </summary>
    /// <param name="app">應用程式建構器</param>
    /// <param name="env">環境資訊</param>
    public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
        if (env.IsDevelopment()) {
            app.UseDeveloperExceptionPage();
        }

        // 使用認證
        app.UseAuthentication();

        // 使用MVC
        app.UseMvc();

        // 使用Swagger
        app.UseSwagger();

        // 使用Swagger UI
        app.UseSwaggerUI(c => {
            c.SwaggerEndpoint(
                $"/swagger/{Configuration.GetSection("Swagger:Name").Value}/swagger.json",
                Configuration.GetSection("Swagger:Title").Value);
        });

        // 使用靜態檔案
        app.UseStaticFiles();

        // 使用SPA
        app.UseSpaStaticFiles();

        // SPA例外處理
        app.Use(async (context, next) => {
            try {
                await next();
            } catch (Exception e) {
                if (e is InvalidOperationException && e.Message.Contains("/index.html")) {
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                }
            }
        });

        // SPA設定
        app.UseSpa(c => { });
    }
}
}
