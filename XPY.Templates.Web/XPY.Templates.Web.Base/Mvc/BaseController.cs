using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using XWidget.EFLogic;
using XWidget.Web.Exceptions;

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
}
}
