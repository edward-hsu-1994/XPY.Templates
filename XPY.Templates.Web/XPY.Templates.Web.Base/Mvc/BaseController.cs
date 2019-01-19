using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using XWidget.EFLogic;
using XWidget.Web.Exceptions;
using XWidget.Web.Jwt;

namespace $safeprojectname$.Mvc {
    /// <summary>
    /// 基礎控制器
    /// </summary>
    [Route("api/[controller]")]
[Produces("application/json")]
[ApiController]
public class BaseController<TManager, TContext> : Controller
        where TManager : LogicManagerBase<TContext>
        where TContext : DbContext {

    /// <summary>
    /// 邏輯管理器
    /// </summary>
    public TManager Manager { get; private set; }

    /// <summary>
    /// 日誌紀錄器
    /// </summary>
    public ILogger Logger { get; private set; }

    /// <summary>
    /// 初始化基礎控制器
    /// </summary>
    /// <param name="manager">邏輯管理器實例</param>
    /// <param name="logger">日誌紀錄器</param>
    public BaseController(TManager manager, ILogger logger) {
        this.Manager = manager;
        this.Logger = logger;
    }

    /// <summary>
    /// API例外處理
    /// </summary>
    /// <param name="context">Action執行結果</param>
    public override void OnActionExecuted(ActionExecutedContext context) {
        if (context.Exception != null) {
            if (context.Exception is ExceptionBase ex) {
                var result = Json(ex);
                result.StatusCode = ex.StatusCode;
                context.Result = result;
                context.ExceptionHandled = true;
            } else {
                var result = Json(new UnknowException(context.Exception.Message + "," + context.Exception.InnerException?.Message));
                result.StatusCode = 500;
                context.Result = result;
                context.ExceptionHandled = true;
            }
        }
        base.OnActionExecuted(context);
    }

    /// <summary>
    /// 取得Authorization中的JWT資訊
    /// </summary>
    /// <typeparam name="TToken">JWT類型</typeparam>
    /// <typeparam name="TJwtHeader">JWT標頭</typeparam>
    /// <typeparam name="TJwtPayload">JWT酬載</typeparam>
    /// <returns>JWT資訊</returns>
    public TToken GetJwtToken<TToken, TJwtHeader, TJwtPayload>()
        where TToken : class, IJwtToken<TJwtHeader, TJwtPayload>
        where TJwtHeader : IJwtHeader {
        if (Request.Headers.TryGetValue("Authorization", out StringValues tokenString)) {
            if (JwtTokenConvert.Verify<TToken, TJwtHeader, TJwtPayload>(tokenString, default(TokenValidationParameters), out var token)) {
                return token;
            }
            return default(TToken);
        }
        return default(TToken);
    }
}
}
