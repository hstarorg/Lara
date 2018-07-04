using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Routing;
using System;
using System.Threading.Tasks;

namespace Hstar.Lara.WebAPI.Extensions
{
    public static class IApplicationBuilderExtension
    {
        public static IApplicationBuilder UseSimpleExceptionHandler(this IApplicationBuilder app, IHostingEnvironment env, Func<IExceptionHandlerPathFeature, ObjectResult> globalExceptionHandler = null)
        {
            return app.UseExceptionHandler("/error").UseRouter(builder =>
            {
                builder.MapRoute("error", ctx => HandleError(ctx, env, globalExceptionHandler));
            });
        }

        private async static Task HandleError(HttpContext ctx, IHostingEnvironment env, Func<IExceptionHandlerPathFeature, ObjectResult> globalExceptionHandler)
        {
            var data = ctx.Features.Get<IExceptionHandlerPathFeature>();
            var actionContext = new ActionContext(ctx, ctx.GetRouteData(), new ActionDescriptor());
            var result = globalExceptionHandler?.Invoke(data) ?? data.Error.ToInternalServerResult(env);
            await result.ExecuteResultAsync(actionContext);
        }

        private static ObjectResult ToInternalServerResult(this Exception ex, IHostingEnvironment env)
        {
            return new ObjectResult(new
            {
                StatusCode = 500,
                ex.Message,
                StackTrace = env.IsDevelopment() ? ex.StackTrace : null
            });
        }
    }
}
