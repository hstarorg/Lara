using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Hstar.Lara.Swagger
{
    public static class SwaggerExtension
    {
        private static ApiInfo ApiInfo { get; set; } = new ApiInfo();

        public static IApplicationBuilder UseSwaggerAndUI(this IApplicationBuilder app, Action<SwaggerUIOptions> setupAction = null)
        {
            if (setupAction == null)
            {
                setupAction = c =>
                {
                    c.RoutePrefix = "swagger"; // Config swagger router
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", ApiInfo.Name);
                };
            }
            app.UseSwagger();
            app.UseSwaggerUI(setupAction);
            return app;
        }

        public static void AddSwagger(this IServiceCollection services, ApiInfo apiInfo, bool includeXmlComments = false)
        {
            ApiInfo = apiInfo;
            services.AddSwaggerGen(c =>
            {
                var info = new Info
                {
                    Title = apiInfo.Name,
                    Description = apiInfo.Description,
                    Version = apiInfo.Version
                };

                c.SwaggerDoc(apiInfo.Version, info);
                if (includeXmlComments)
                {
                    // System.Reflection.Assembly.GetExecutingAssembly().GetName().Name also OK.
                    // this.GetType().Assembly.GetName().Name
                    string xmlCommentName = $"{ApiInfo.Name}.xml";
                    string xmlCommentPath = Path.Combine(AppContext.BaseDirectory, xmlCommentName);
                    c.IncludeXmlComments(xmlCommentPath, true);
                }
            });
        }
    }
}
