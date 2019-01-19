using Lara.DI;
using Lara.Swagger;
using Lara.WebAPI.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SampleApp1.Models;
using System;

namespace SampleApp1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwagger(new ApiInfo { Name = "SampleApp1", Version = "v1", Description = "测试APP" }, true);
            return services.ToAutofacProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            var corsPolicy = new Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy();
            corsPolicy.Origins.Add("*");
            app.UseSimpleExceptionHandler(env, exHandlerPathFeature =>
            {
                if (exHandlerPathFeature.Error is BusinessException bizEx)
                {
                    return new ObjectResult(new
                    {
                        StatusCode = bizEx.StatusCode,
                        bizEx.Message,
                        StackTrace = env.IsDevelopment() ? bizEx.StackTrace : null
                    });
                }
                return null;
            }, corsPolicy);

            app.UseCors(c => c.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader().AllowCredentials());
            app.UseSwaggerAndUI();
            app.UseMvc();
        }
    }
}