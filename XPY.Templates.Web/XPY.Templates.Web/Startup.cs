using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using NSwag.AspNetCore;
using NJsonSchema;
using NSwag.SwaggerGeneration.Processors.Security;
using XWidget.Utilities;
using XWidget.Web;
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
        services.AddLogic <$lastnamespace$Manager, $lastnamespace$Context > (options => {
            options.UseLazyLoadingProxies();
            // 此處選擇使用個別專案的資料庫連線提供者
            $if$ ( $efProvider$ == PostgreSQL )
             options.UseNpgsql(Configuration.GetConnectionString("default"));
            $endif$
            $if$ ( $efProvider$ == MSSQL )
             options.UseSqlServer(Configuration.GetConnectionString("default"));
            $endif$
        }).AddFromDbContext("Id");

        // 使用認證
        services.AddJwtAuthentication(
            secureKey: Configuration.GetSection("JWT:SecureKey").Value,
            issuer: Configuration.GetSection("JWT:Issuer").Value,
            audience: Configuration.GetSection("JWT:Audience").Value);

        // 使用MVC服務
        services.AddMvc()
            .AddJsonOptions(options => {
                // 設定JSON格式化選項，使用忽略LazyLoader屬性
                options.SerializerSettings.ContractResolver = new CommonContractResolver();
                // JSON序列化忽略循環問題
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

        // 註冊Swagger產生器
        services.AddSwaggerDocument(config => {
            config.Title = Configuration.GetSection("Swagger:Name").Value;
            config.Description = Configuration.GetSection("Swagger:Description").Value;
            config.Version = Assembly.GetEntryAssembly().GetName().Version.ToString();

            // ref: https://github.com/RSuter/NSwag/issues/869
            config.OperationProcessors.Add(new OperationSecurityScopeProcessor("apiKey"));
            config.OperationProcessors.Add(new AuthorizeOperationProcessor());
            config.OperationProcessors.Add(new OptionParamProcessor());
            config.OperationProcessors.Add(new ConsumesAttributeProcessor());
            config.DocumentProcessors.Add(new SecurityDefinitionAppender("apiKey", new NSwag.SwaggerSecurityScheme() {
                Type = NSwag.SwaggerSecuritySchemeType.ApiKey,
                Name = "Authorization",
                In = NSwag.SwaggerSecurityApiKeyLocation.Header,
                Description = "JWT(Bearer) 存取權杖"
            }));
        });

        // 日誌紀錄器
        services.AddLogging();

        // 設定SPA根目錄
        services.AddSpaStaticFiles(options => {
            options.RootPath = "./wwwroot";
        });

        // 設定MultipartBody最大長度
        /*
        services.Configure<FormOptions>(options => {
            options.MultipartBodyLengthLimit = 500 * ByteUtility.MiB;
        });
        */
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

        #region Adding security headers
        var policyCollection = new HeaderPolicyCollection()
            .AddFrameOptionsDeny()
            .AddXssProtectionBlock()
            .AddContentTypeOptionsNoSniff()
            .AddReferrerPolicyStrictOriginWhenCrossOrigin()
            .RemoveServerHeader();
        //.AddStrictTransportSecurityMaxAgeIncludeSubDomains(maxAgeInSeconds: 60 * 60 * 24 * 365)
        //.AddContentSecurityPolicy(builder => {
        //    builder.AddObjectSrc().None();
        //    builder.AddFormAction().Self();
        //    builder.AddFrameAncestors().None();
        //});

        app.UseSecurityHeaders(policyCollection);
        #endregion

        // 使用認證
        app.UseAuthentication();

        // 使用MVC
        app.UseMvc();

        #region Swagger UI
        // 使用Swagger UI並搭配API探索器
        app.UseSwagger();
        app.UseSwaggerUi3();
        #endregion

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
