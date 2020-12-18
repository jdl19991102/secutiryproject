using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSecurity.Interface;
using WebSecurity.Interface.Extend;
using WebSecurity.Service;

using System.Reflection;
using System.IO;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;

namespace WebSecurity
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //组测服务
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IArticleService, ArticleService>();
            services.AddSingleton(serviceProvider =>
            {
                var server = serviceProvider.GetRequiredService<IServer>();
                return server.Features.Get<IServerAddressesFeature>();
            });




            services.AddResponseCaching();
            services.Configure<DBConnectionOption>(Configuration.GetSection("ConnectionStrings"));
            services.AddCors(ac => ac.AddPolicy("any", ap => ap.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
            #region 添加Swagger

            //services.AddSwaggerGen(options =>
            //{
            //    options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            //    // 获取xml文件名
            //    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //    // 获取xml文件路径
            //    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            //    // 添加控制器层注释，true表示显示控制器注释
            //    options.IncludeXmlComments(xmlPath, true);
            //});
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            
            app.UseRouting();
            app.UseAuthorization();
            app.UseStaticFiles();

            app.UseCors();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // 添加Swagger有关中间件
            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Demo v1");
            //});
        }
    }
}
