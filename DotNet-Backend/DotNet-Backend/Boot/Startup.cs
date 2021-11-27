using DotNet_Backend.Data.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DotNet_Backend.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using DotNet_Backend.Data.Contracts.Interfaces;
using DotNet_Backend.Data.Repositories;
using DotNet_Backend.Data.Settings.Interfaces;
using DotNet_Backend.Services;
using DotNet_Backend.Services.Interfaces;

namespace DotNet_Backend
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DotNet_Backend", Version = "v1" });
            });

            var connectionStrings = this.Configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>();

            services.AddDbContext<BlogContext>(options =>
                options.UseNpgsql(connectionStrings.BlogDbContext,
                    b => b.MigrationsHistoryTable("__EFMigrationsHistory", connectionStrings.DefaultSchema)));

            services.AddCors(o => o.AddPolicy("AllowOrigin", builder =>
            {
                builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .SetIsOriginAllowed(host => true)
                    .AllowCredentials();
            }));

            AddSwagger(services);
            AddAutoMapper(services);

            services.AddHealthChecks();

            DependencyInjections(services);
        }

        private void AddSwagger(IServiceCollection services)
        {
            //services.AddSwaggerGen(options =>
            //{
            //    var groupName = "v1";

            //    options.SwaggerDoc(groupName, new OpenApiInfo
            //    {
            //        Title = $"Blog {groupName}",
            //        Version = groupName,
            //        Description = "Blog API"
            //    });

            //    // Set the comments path for the Swagger JSON and UI.
            //    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            //    //options.IncludeXmlComments(xmlPath);
            //});
        }

        private void AddAutoMapper(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapping());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public void DependencyInjections(IServiceCollection services)
        {
            var connectionStrings = Configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>();
            services.AddSingleton<IConnectionStrings>(connectionStrings);

            services.AddScoped<IBlogContext, BlogContext>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DotNet_Backend v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });

            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetRequiredService<BlogContext>())
                {

                    context.Database.Migrate();
                }
            }


        }
    }
}
